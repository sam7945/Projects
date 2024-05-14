#include <iostream>
#include "arbrebinaire.h"
#include <string>

int main()
{
	std::cout.setf(std::ios::boolalpha);

	ArbreBinaire<int> arbre;
	arbre.Ajouter(5);
	arbre.Ajouter(6);
	arbre.Ajouter(2);
	arbre.Ajouter(10);
	arbre.Ajouter(1);
	arbre.Ajouter(50);
	arbre.Ajouter(30);
	arbre.AfficherCroissant();
	arbre.AfficherDecroissant();
	std::cout << arbre.Maximum() << std::endl;
	std::cout << arbre.Minimum() << std::endl;
	std::cout << arbre.Nombre() << std::endl;

	std::cout << arbre.Contient(3) << std::endl;
	std::cout << arbre.Contient(5) << std::endl;

	std::cout << "-----------------------------------" << std::endl;
	arbre.Enlever(6);
	arbre.Enlever(3);
	std::cout << arbre.Maximum() << std::endl;
	std::cout << arbre.Minimum() << std::endl;
	std::cout << arbre.Nombre() << std::endl;
	arbre.AfficherCroissant();
	arbre.AfficherDecroissant();


	ArbreBinaire<std::string> arbre1;
	arbre1.Ajouter("weed");
	arbre1.Ajouter("cokes");
	arbre1.Ajouter("un");
	arbre1.Ajouter("ZZZ");
	arbre1.Ajouter("aaa");
	arbre1.Ajouter("b");
	arbre1.Ajouter("c");
	arbre1.Ajouter("d");
	arbre1.AfficherCroissant();
	arbre1.AfficherDecroissant();
	std::cout << arbre1.Maximum() << std::endl;
	std::cout << arbre1.Minimum() << std::endl;
	std::cout << arbre1.Nombre() << std::endl;
	std::cout << arbre1.Contient("weed") << std::endl;
	std::cout << arbre1.Contient("deux") << std::endl;

	std::cout << "-----------------------------------" << std::endl;

	ArbreBinaire<char> arbre2;
	arbre2.Ajouter('a');
	arbre2.Ajouter('a');
	arbre2.Ajouter('z');
	arbre2.Ajouter('c');
	arbre2.AfficherCroissant();
	arbre2.AfficherDecroissant();
	std::cout << arbre2.Maximum() << std::endl;
	std::cout << arbre2.Minimum() << std::endl;
	std::cout << arbre2.Nombre() << std::endl;
	std::cout << arbre2.Contient('a') << std::endl;
	std::cout << arbre2.Contient('b') << std::endl;
	system("Pause");
}
