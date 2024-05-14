// DllCrawlerPageH1.cpp : Définit les fonctions exportées pour l'application DLL.
//

#include "stdafx.h"
#include "../crawler/pagehandler.h"
#include <iostream>
#include <set>
#include <list>
#include <cmath>
#include <vector>

class DllCrawlerPageH1 : public PageHandler
{
public:
	typedef std::vector<std::string> ListeString;
	ListeString listeH1;

	virtual void HandlePage(std::string & html)
	{
		std::string::size_type pos1 = 0;
		while (pos1 != std::string::npos)
		{
			// Chercher pour les liens de type h1
			pos1 = html.find("<h1>", pos1);

			if (pos1 != std::string::npos)
			{
				// Incrémenter la position de la longueur de "<h1>"
				pos1 += 4; // len("<h1>") = 4

				// Trouver la fin de la braquette </h1>, soit </h1>
				std::string::size_type pos2 = html.find("</h1>", pos1);

				// Si non trouvé, le document HTML est mal formé, skipper
				// ce lien h1
				if (pos2 == std::string::npos)
					continue;

				// Extraire le titre avec les positions trouvées
				std::string titre = html.substr(pos1, pos2 - pos1);

				if (titre.length() != 0)
				{
					// Insérer le titre trouvé dans la liste
					listeH1.push_back(titre);
				}
			}
		}
	};

	virtual void AfficherResultat()
	{
		for (std::string s : listeH1)
		{
			std::cout << s << std::endl;
		}
		std::cout << "Nombre de titre: " << listeH1.size() << std::endl;
	};
};

DllCrawlerPageH1 handler;

extern "C"
{
	__declspec(dllexport) PageHandler* GetHandler()
	{
		return &handler;
	}
}
