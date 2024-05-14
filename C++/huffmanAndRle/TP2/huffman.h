#ifndef HUFFMAN_H__
#define HUFFMAN_H__
#include <iostream>
#include <string>
#include <fstream>
#include <queue>
#include <map>
#include <iomanip>
#include "bitpacker.h"
#include <sstream>
#include <bitset>

class Huffman
{
public:
	// Accepte des donn´ees non - compress´ees en param`etre et retourne les donn´ees compress´ees
	std::string Compresser(const std::string & data);
	// Accepte des donn´ees compress´ees en param`etre et retourne les donn´ees d´ecompress´ees
	std::string Decompresser(const std::string & data);
	std::string LoadFile(const std::string & filename);
	struct Noeud
	{
		char c;
		int nb;
		Noeud* gauche;
		Noeud* droite;
	};
	bool operator()(const Noeud* n1, const Noeud* n2)const
	{
		return n1->nb > n2->nb;
	}
	void AfficherArbreConsole(const Noeud* n, int level = 0);
	typedef std::map<char, std::string> Dictionnaire;
	void GenererDictionnaire(Noeud* n, std::string code, Dictionnaire& dictionnaire);
private:
	Noeud* racine = nullptr;
	Dictionnaire dico;
};


#endif		
