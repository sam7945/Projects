#include <iostream>
#include <fstream>
#include <string>
#include <cstdio>
#include <ctime>
#include <set>
#include "pagehandler.h"
#include <Windows.h>
#include <vector>
#include <mutex>
#include <thread>

struct HandlerInfo
{
	PageHandler* handler;
	HMODULE dll;
};

void RechercheUrl(const std::string& url, std::string& html);
const int THREAD_COUNT = 5;
volatile bool running = true;
volatile bool EnCour = false;
typedef std::set<std::string> ListeString;
std::mutex Mutext;
std::vector<HandlerInfo> handlers;
ListeString listeUrl;
ListeString listeUrlComplet;

HandlerInfo LoadPlugin(const std::string& dllName)
{
	HandlerInfo hi;
	hi.dll = LoadLibrary(dllName.c_str());
	typedef PageHandler*(*GetHandlerPtr)();
	GetHandlerPtr GetHandler = (GetHandlerPtr)GetProcAddress(hi.dll, "GetHandler");

	hi.handler = GetHandler();

	return hi;
}
void UnloadPlugin(HandlerInfo hi)
{
	FreeLibrary(hi.dll);
}



std::string ReadCommandOutput(const std::string& command)
{
	std::string result;

	FILE* fp = _popen(command.c_str(), "r");
	if (!fp)
		return result;

	char buffer[4096];
	int len;
	while ((len = fread(buffer, 1, sizeof(buffer) - 1, fp)) != 0)
	{
		buffer[len] = '\0';
		result += buffer;
	}


	_pclose(fp);
	return result;
}


void ExtraireCourriels()
{
	std::string s;
	while (running)
	{
		Mutext.lock();

		if (listeUrl.size() == 0 && EnCour == true)
		{
			running = false;
			EnCour = false;
		}
		else if (listeUrl.size() != 0)
		{
			s = *listeUrl.begin();
			listeUrlComplet.insert(s);
			listeUrl.erase(s);
		}
		Mutext.unlock();

		// Telecharger le contenu du lien et stocker le code HTML dans la variable data
		std::string html = ReadCommandOutput("curl.exe --silent \"" + s + "\"");

		Mutext.lock();
		for (HandlerInfo hi : handlers)
		{
			hi.handler->HandlePage(html);
		}
		Mutext.unlock();
		RechercheUrl(s, html);

	}
}

void RechercheUrl(const std::string& url, std::string& html)
{
	std::string::size_type pos1 = 0;
	while (pos1 != std::string::npos)
	{
		// Chercher pour les liens de type href
		pos1 = html.find("a href=\"", pos1);

		if (pos1 != std::string::npos)
		{
			// Incrémenter la position de la longueur de "a herf="
			pos1 += 8; // len("a href=\"") = 8

			// Trouver la fin du lien href, soit " ou > dépendamment si le HTML est
			// valide ou non
			std::string::size_type pos2 = html.find("\"", pos1);
			std::string::size_type pos3 = html.find(">", pos1);

			// pos2 devient le premier des deux caractère trouvé
			if (pos2 == std::string::npos || pos3 < pos2)
				pos2 = pos3;

			// Si non trouvé, le document HTML est mal formé, skipper
			// ce lien href
			if (pos2 == std::string::npos)
				continue;
			// Extraire le lien avec les positions trouvées
			std::string email = html.substr(pos1, pos2 - pos1);
			if (email.find("html") == std::string::npos || listeUrl.count(url + email) != 0)
			{
				continue;
			}
			std::string s = url;
			while (s.back() != '/')
			{
				s.resize(s.size() - 1);
			}
			if (email.length() != 0)
			{
				Mutext.lock();
				if (listeUrlComplet.count(s + email) == 0)
				{
					// Insérer le lien trouvé dans la liste
					listeUrl.insert(s + email);
					EnCour = true;
				}
				Mutext.unlock();
			}
		}
	}
}


int main()
{
	//Automatique
	HMODULE exe = GetModuleHandle(0);
	char exePathBuffer[MAX_PATH];
	GetModuleFileName(exe, exePathBuffer, MAX_PATH);
	std::string exePath(exePathBuffer);
	exePath = exePath.substr(0, exePath.rfind("\\") + 1);

	std::cout << exePath << std::endl;

	WIN32_FIND_DATA data;
	HANDLE h = FindFirstFile((exePath + "*.dll").c_str(), &data);

	if (h != INVALID_HANDLE_VALUE)
	{
		do
		{
			std::cout << "Chargement de " << data.cFileName << std::endl;
			handlers.push_back(LoadPlugin(data.cFileName));
		} while (FindNextFile(h, &data));
		FindClose(h);
	}


	//Sortie des urls
	std::ifstream courriels("urls.txt");
	if (!courriels.is_open())
	{
		std::cout << "Erreur lors de l'ouverture du fichier de courriels (courriels.txt)" << std::endl;
		system("pause");
		return 1;
	}


	std::string url;
	while (std::getline(courriels, url))
	{
		listeUrl.insert(url);
	}
	courriels.close();

	std::cout << "La liste initiale contient " << listeUrl.size() << " urls..." << std::endl;

	int debut = time(0);

	std::thread t[THREAD_COUNT];
	for (int i = 0; i < THREAD_COUNT; i++)
	{
		t[i] = std::thread(ExtraireCourriels);
		std::cout << "." << std::flush;
	}

	std::cout << std::endl;

	for (int i = 0; i < THREAD_COUNT; i++)
		t[i].join();
	running = false;
	//fin a propos des sorties urls

	//Affichage du contenue
	for (HandlerInfo hi : handlers)
	{
		hi.handler->AfficherResultat();
	}

	system("pause");
}