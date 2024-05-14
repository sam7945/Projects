#ifndef RLE_H__
#define RLE_H__
#include <iostream>
#include <string>
#include <fstream>
#include <iomanip> 

class RLE
{
public:
	// Accepte des donn´ees non - compress´ees en param`etre et retourne les donn´ees compress´ees
	std::string Compresser(const std::string & data);
	// Accepte des donn´ees compress´ees en param`etre et retourne les donn´ees d´ecompress´ees
	std::string Decompresser(const std::string & data);
	std::string LoadFile(const std::string & filename);
private:
	//struct  Noeud
	//{
	//	char c;
	//	int nb;
	//	Noeud* gauche;
	//	Noeud* droite;
	//};

	//bool operator()(const Noeud* n1, const Noeud* n2)const
	//{
	//	return n1->nb > n2->nb;
	//}
};


#endif		
