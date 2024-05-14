#ifndef ARBREBINAIRE_H__
#define ARBREBINAIRE_H__
#include <iostream>

template <class T>
class ArbreBinaire
{
public:
	ArbreBinaire(); // Construit un arbre vide
	~ArbreBinaire(); // Libere toute la memoire allou´ee
	void Ajouter(const T& valeur); // Ajouter un item
	void Enlever(const T& valeur); // Enlever un item
	bool Contient(const T& valeur) const; // Retourne vrai si l ’ arbre contient l ’ item recherch´e
	int Nombre() const; // Retourne le nombre d ’ items dans l ’ arbre
	const T& Minimum() const; // Retourne la plus petite valeur
	const T& Maximum() const; // Retourne la plus grande valeur
	void AfficherCroissant() const; // Affiche le contenu de l ’ arbre en ordre croissant ( avec un espace entre chaque item )
	void AfficherDecroissant() const; // Affiche le contenu de l ’ arbre en ordre d´ecroissant ( avec un espace entre chaque item )
private:
	struct Noeud
	{
		T valeur;
		Noeud* suivantgauchepetit; //Noeud suivent plus petit vers la gauche
		Noeud* suivantdroitegrand; //Noeud suivent vers la droite
	};
	Noeud* m_debut = 0; //Noeud initial
	int m_count = 0;	//Nombre de noeuds
	bool m_valeurajouter = false; //vérification si la valeur a été ajouté

	void Croissant(Noeud* n) const; //Méthode de récursivité croissante
	void Decroissant(Noeud* n) const; //Méthode de récursivité décroissante
};

template<class T>
ArbreBinaire<T>::ArbreBinaire()
{
}

template<class T>
ArbreBinaire<T>::~ArbreBinaire()
{
	Noeud* n = m_debut;
	Noeud* precedant = 0;

	while (n != 0)
	{
		//Identifie le derniers noeuds de l'arbre pour les détruire un après l'autre
		while (n->suivantgauchepetit != 0 || n->suivantdroitegrand != 0)
		{
			if (n->suivantgauchepetit != 0) //pointe vers le noeud de gauche si il en reste.
			{
				precedant = n;
				n = n->suivantgauchepetit;
			}
			else if (n->suivantdroitegrand != 0) //pointe vers le noeud de droite si il en reste et non a gauche
			{
				precedant = n;
				n = n->suivantdroitegrand;
			}
		}
		//condition d'effacement du dernier noeud pointé.
		if (n->suivantdroitegrand == 0 && n->suivantgauchepetit == 0)
		{
			if (precedant->suivantdroitegrand != NULL && precedant->suivantdroitegrand->valeur == n->valeur)//condition requise pour que le pointeur précédent mette à NULL le pointeur actuel.
			{
				delete n;
				precedant->suivantdroitegrand = NULL;
				n = precedant;
				--m_count;
			}
			else if (precedant->suivantgauchepetit != NULL && precedant->suivantgauchepetit->valeur == n->valeur)
			{
				delete n;
				precedant->suivantgauchepetit = NULL;
				n = precedant;
				--m_count;
			}
			else //dans le cas ou il s'agit du premier élément enregistré
			{
				delete n;
				n = NULL;
				--m_count;
			}
		}
	}
}

template<class T>
void ArbreBinaire<T>::Ajouter(const T& valeur)
{
	if (m_debut == NULL) //si il n'y a aucun élément d'entré avant celui-là
	{
		m_debut = new Noeud{ valeur,m_debut,m_debut };
		m_count++;
	}
	else if (m_debut->valeur != valeur) //condition pour parcourir les valeurs des pointeurs et trouver la bonne
	{
		Noeud* n1 = m_debut;
		Noeud* n = new Noeud{ valeur,0,0 };
		m_valeurajouter = false;

		while (m_valeurajouter == false)
		{
			if (valeur > n1->valeur)
			{
				if (n1->suivantdroitegrand == 0)//si il n'y a rien ajoute un pointeur vers le noeud de la valeur
				{
					n1->suivantdroitegrand = n;
					m_count++;
					m_valeurajouter = true;
				}
				else
				{
					n1 = n1->suivantdroitegrand; //continue si la valeur pointeur est dejà occupé
				}
			}
			else if (valeur < n1->valeur)
			{
				if (n1->suivantgauchepetit == 0)//si il n'y a rien ajoute un pointeur vers le noeud de la valeur
				{
					n1->suivantgauchepetit = n;
					m_count++;
					m_valeurajouter = true;

				}
				else
				{
					n1 = n1->suivantgauchepetit;//continue si la valeur pointeur est dejà occupé
				}
			}
			else if (valeur == n1->valeur) // condition au cas ou la valeur existe dejà
			{
				break;
			}
		}
	}
}

template<class T>
void ArbreBinaire<T>::Enlever(const T& valeur)
{
	Noeud* n1 = m_debut;
	Noeud* precedant = n1;

	while (n1 != NULL) //continue jusqu'à ce que la valeur recherchée soit supprimé
	{
		if (valeur > n1->valeur) //va vers la droite tant que la valeur est plus grand que l'actuelle pointeur
		{
			precedant = n1;
			n1 = n1->suivantdroitegrand;
		}
		else if (valeur < n1->valeur)//va vers la gauche tant que la valeur est plus petite que l'actuelle pointeur
		{
			precedant = n1;
			n1 = n1->suivantgauchepetit;
		}
		else if (n1->valeur == valeur) //s'arrête de chercher si le bon pointeur est trouvé
		{
			if (n1->suivantgauchepetit != NULL && n1->suivantdroitegrand != NULL) //condition d'effacement si la valeur correspondante a deux autre pointeur après
			{
				Noeud* n2 = n1->suivantdroitegrand; //Nouveau pointeur avec une valeur supérieure pour décidé quel pointeur va prendre la place de l'autre
				Noeud* precedant2 = n1; //pointeur précédant du n2
				while (n2->suivantgauchepetit != NULL) //parcourir pour trouver le pointeur le plus proche et petit de la branche grande qui va remplacer, va constament vers la gauche
				{
					precedant2 = n2;
					n2 = n2->suivantgauchepetit;
				}
				if (n2->suivantdroitegrand != NULL) //dans le cas ou le pointeur de remplacement en a un autre après(grand, droite)
				{
					precedant2->suivantgauchepetit = n2->suivantdroitegrand; //redirection du pointeur précédent pour que sont suivant soit le suivant de n2
					if (precedant->suivantdroitegrand->valeur == valeur) //Pour savoir si c'est le pointeur de gauche ou de droite qui doit changer
					{
						precedant->suivantdroitegrand = n2;
						n2->suivantgauchepetit = n1->suivantgauchepetit;
						n2->suivantdroitegrand = n1->suivantdroitegrand;
						delete n1;
						m_count--;
						n1 = NULL;
					}
					else if (precedant->suivantgauchepetit->valeur == valeur)//Pour savoir si c'est le pointeur de gauche ou de droite qui doit changer
					{
						precedant->suivantgauchepetit = n2;
						n2->suivantgauchepetit = n1->suivantgauchepetit;
						n2->suivantdroitegrand = n1->suivantdroitegrand;
						delete n1;
						m_count--;
						n1 = NULL;
					}
				}
				else if (n2->suivantdroitegrand == NULL) // dans le cas ou il n'y a pas de pointeur après celui-là
				{
					if (precedant->suivantdroitegrand->valeur == valeur) 
					{
						precedant->suivantdroitegrand = n2;
						precedant2->suivantgauchepetit = NULL;
						n2->suivantdroitegrand = n1->suivantdroitegrand;
						n2->suivantgauchepetit = n1->suivantgauchepetit;
						delete n1;
						m_count--;
						n1 = NULL;
					}
					else if (precedant->suivantgauchepetit->valeur == valeur)
					{
						precedant->suivantgauchepetit = n2;
						precedant2->suivantgauchepetit = NULL;
						n2->suivantgauchepetit = n1->suivantgauchepetit;
						n2->suivantdroitegrand = n1->suivantdroitegrand;
						delete n1;
						m_count--;
						n1 = NULL;
					}
				}
			}
			else if (n1->suivantgauchepetit != NULL && n1->suivantdroitegrand == NULL) //condition si la valeur rechercher n'a qu'une valeur sur la gauche
			{
				if (precedant->suivantdroitegrand->valeur == valeur) 
				{
					precedant->suivantdroitegrand = n1->suivantgauchepetit;
					delete n1;
					m_count--;
					n1 = NULL;
				}
				else if (precedant->suivantgauchepetit->valeur == valeur)
				{
					precedant->suivantgauchepetit = n1->suivantgauchepetit;
					delete n1;
					m_count--;
					n1 = NULL;
				}
			}
			else if (n1->suivantdroitegrand != NULL && n1->suivantgauchepetit == NULL)//condition si la valeur rechercher n'a qu'une valeur sur la droite
			{
				if (precedant->suivantdroitegrand->valeur == valeur)
				{
					precedant->suivantdroitegrand = n1->suivantdroitegrand;
					delete n1;
					m_count--;
					n1 = NULL;
				}
				else if (precedant->suivantgauchepetit->valeur == valeur)
				{
					precedant->suivantgauchepetit = n1->suivantdroitegrand;
					delete n1;
					m_count--;
					n1 = NULL;
				}
			}
			else if (n1->suivantdroitegrand == NULL && n1->suivantgauchepetit == NULL) //dans le cas ou il n'y a pas de Noeud après celui qui va être effacé.
			{
				if (precedant->suivantdroitegrand == n1)
					precedant->suivantdroitegrand = NULL;
				if (precedant->suivantgauchepetit == n1)
					precedant->suivantgauchepetit = NULL;

				delete n1;
				m_count--;
				n1 = NULL;
			}
		}
	}
}

template<class T>
bool ArbreBinaire<T>::Contient(const T& valeur) const
{
	Noeud* n1 = m_debut;

	while (n1->valeur != valeur) //continue tant que la valeur n'est pas trouvé
	{
		if (valeur > n1->valeur) //envoie vers la droite de l'arbre si la valeur demandé est plus grosse 
		{
			if (n1->suivantdroitegrand == 0) //retourne faux si la valeur n'est pas trouvable
				return false;
			else
				n1 = n1->suivantdroitegrand; //continue si la valeur n'est pas la bonne
		}
		else if (valeur < n1->valeur) //envoie vers la droite de l'arbre si la valeur demandé est plus petite
		{
			if (n1->suivantgauchepetit == 0)//retourne faux si la valeur n'est pas trouvable
				return false;
			else
				n1 = n1->suivantgauchepetit;// continue si la valeur n'est pas la bonne
		}
	}
	return true;
}

template<class T>
int ArbreBinaire<T>::Nombre() const
{
	return m_count; //renvoie le nombre de Noeud dans l'arbre
}

template<class T>
const T& ArbreBinaire<T>::Minimum() const
{
	Noeud* n1 = m_debut;

	while (n1->suivantgauchepetit != 0) //va vers la gauche(valeur petite) de l'arbre jusqu'au plus petit
	{
		n1 = n1->suivantgauchepetit;
	}

	T& min = n1->valeur;

	return min;
}

template<class T>
const T& ArbreBinaire<T>::Maximum() const
{
	Noeud* n1 = m_debut;

	while (n1->suivantdroitegrand != 0) //va vers la droite(valeur grande) de l'arbre jusqu'au plus grand
	{
		n1 = n1->suivantdroitegrand;
	}
	T& max = n1->valeur;
	return max;
}

template<class T>
void ArbreBinaire<T>::AfficherCroissant() const
{
	Noeud* n = m_debut;
	Croissant(n); //méthode récursive pour renvoyer les valeurs
}

template<class T>
void ArbreBinaire<T>::AfficherDecroissant() const
{
	Noeud* n = m_debut;
	Decroissant(n);//méthode récursive pour renvoyer les valeurs
}
template<class T>
void ArbreBinaire<T>::Croissant(Noeud* n) const
{
	if (n != NULL) //continue jusqu'à ce que le dernier noeud soit atteint
	{
		Croissant(n->suivantgauchepetit);
		std::cout << n->valeur << std::endl;
		Croissant(n->suivantdroitegrand);
	}
}
template<class T>
void ArbreBinaire<T>::Decroissant(Noeud * n) const
{
	if (n != NULL)//continue jusqu'à ce que le dernier noeud soit atteint
	{
		Decroissant(n->suivantdroitegrand);
		std::cout << n->valeur << std::endl;
		Decroissant(n->suivantgauchepetit);
	}

}
#endif	