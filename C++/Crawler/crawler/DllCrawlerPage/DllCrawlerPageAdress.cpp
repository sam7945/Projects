// DllCrawlerPage.cpp : Définit les fonctions exportées pour l'application DLL.
//

#include "stdafx.h"
#include "../crawler/pagehandler.h"
#include <iostream>
#include <set>
#include <list>
#include <cmath>

class DllCrawlerPageAdress : public PageHandler 
{
public:
	typedef std::set<std::string> ListeString ;
	ListeString listeCourriel;

	virtual void HandlePage(std::string & html) 
	{
		std::string::size_type pos1 = 0;
		while (pos1 != std::string::npos)
		{
			// Chercher pour les liens de type mailto
			pos1 = html.find("mailto:", pos1);

			if (pos1 != std::string::npos)
			{
				// Incrémenter la position de la longueur de "mailto:"
				pos1 += 7; // len("mailto:") = 7

				// Trouver la fin du lien mailto, soit " ou > dépendamment si le HTML est
				// valide ou non
				std::string::size_type pos2 = html.find("\"", pos1);
				std::string::size_type pos3 = html.find(">", pos1);

				// pos2 devient le premier des deux caractère trouvé
				if (pos2 == std::string::npos || pos3 < pos2)
					pos2 = pos3;

				// Si non trouvé, le document HTML est mal formé, skipper
				// ce lien mailto
				if (pos2 == std::string::npos)
					continue;

				// Extraire le courriel avec les positions trouvées
				std::string email = html.substr(pos1, pos2 - pos1);

				// Enlever les parametres a la fin du lien mailto (?Subject=....)
				pos2 = email.find("?");
				if (pos2 != std::string::npos)
					email = email.substr(0, pos2);

				if (email.length() != 0)
				{
					// Insérer le courriel trouvé dans la liste
					listeCourriel.insert(email);
				}
			}
		}
	};

	virtual void AfficherResultat() 
	{
		for (std::string s : listeCourriel)
		{
			std::cout << s << std::endl;
		}
		std::cout << "Nombre de courriel uniques: " << listeCourriel.size() << std::endl;
	};
};

DllCrawlerPageAdress handler;

extern "C"
{
	__declspec(dllexport) PageHandler* GetHandler()
	{
		return &handler;
	}
}
