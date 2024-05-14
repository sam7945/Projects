#include "huffman.h"

std::string Huffman::Compresser(const std::string & data)
{
	std::string s = LoadFile(data);
	//std::string s = data;
	//Battir tableau de frequence
	int freq[256] = { 0 };
	for (int i = 0; i < s.length(); ++i)
	{
		freq[(unsigned char)s[i]]++;
	}

	//afficher tableau de frequence
	//for (int i = 0; i < 256; ++i)
	//{
	//	if (freq[i] != 0)
	//	{
	//		std::cout << "'" << (char)i << "':" << freq[i] << std::endl;
	//	}
	//}

	//Trier les noeuds en ordre croissant de fréquence
	std::priority_queue<Noeud*, std::vector<Noeud*>, Huffman > q;
	for (int i = 0; i < 256; ++i)
	{
		if (freq[i] != 0)
			q.push(new Noeud{ (char)i,freq[i], nullptr,nullptr });
	}

	//Batir arbre de huffman
	while (q.size() != 1)
	{
		Noeud* gauche = q.top();
		q.pop();
		Noeud* droite = q.top();
		q.pop();

		q.push(new Noeud{ 0,gauche->nb + droite->nb, gauche,droite });

	}

	racine = q.top();

	//AfficherArbreConsole(racine);

	//Batir dictionnaire unordered_set
	Dictionnaire dictionnaire;
	GenererDictionnaire(racine, "", dictionnaire);

	//for (const auto& e : dictionnaire)
	//{
	//	std::cout << "'" << e.first << "':" << e.second << std::endl;
	//}

	//compresser:
	BitPacker bp;
	for (char c : s)
		bp << dictionnaire[c];

	std::cout << "huf(" << data << "):	" << s.length() << "    \t\t" << bp.Size() / 8 << "         \t" << ((double)s.length() / (double)(bp.Size() / 8.f)) << "    \tOK" << std::endl;

	auto data1 = bp.Get();
	//std::stringstream buffer;
	std::string s1 = "";
	for (auto v : data1)
	{
		//std::cout << std::hex << std::setw(2) << std::setfill('0') << (unsigned int)v;
		//buffer << std::hex << std::setw(2) << std::setfill('0') << (unsigned int)v;
		s1 += v;
	}
	dico = dictionnaire;
	return s1;
}

std::string Huffman::Decompresser(const std::string & data)
{
	Noeud* n = racine;
	int Nb = n->nb;
	std::string s = data;
	std::string s1 = "";
	std::string sRetour = "";

	for (int i = 0; i < s.length(); i++)
	{
		s1 += std::bitset<8>(s.c_str()[i]).to_string();
	}

	for (int i = 0; i < s1.size(); i++)
	{
		if (s1[i] == '0' && n->gauche != nullptr)
		{
			n = n->gauche;
		}
		else if (s1[i] == '1' && n->droite != nullptr)
		{
			n = n->droite;
		}
		if (n->droite == nullptr && n->gauche == nullptr)
		{
			sRetour += n->c;
			n = racine;
		}
	}
	while (sRetour.length() > Nb)
	{
		std::string s2;
		for (int i = 0; i < sRetour.length()-1; i++)
		{
			s2 += sRetour[i];
		}
		sRetour = s2;
	}
	std::cout << "huf(Decompresse):	" << sRetour.size() << "		OK" << std::endl;
	return sRetour;
}

std::string Huffman::LoadFile(const std::string & filename)
{
	std::ifstream f(filename.c_str(), std::ios::binary);
	if (!f.is_open())
		return "";
	f.seekg(0, std::ios::end);
	unsigned int len = f.tellg();
	f.seekg(0, std::ios::beg);
	char * tmp = new char[len];
	f.read(tmp, len);
	f.close();
	std::string buffer(tmp, len);
	delete[] tmp;
	return buffer;
}

void Huffman::GenererDictionnaire(Noeud* n, std::string code, Dictionnaire& dictionnaire)
{
	if (!n)
		return;
	GenererDictionnaire(n->gauche, code + "0", dictionnaire);
	GenererDictionnaire(n->droite, code + "1", dictionnaire);

	if (!n->gauche && !n->droite)
	{
		//Noeud enfant...

		if (code.length() == 0)
			code = "0";


		//Ajoute le code dans le dictionnaire, c = code
		dictionnaire[n->c] = code;
	}
}
void Huffman::AfficherArbreConsole(const Noeud* n, int level)
{
	if (!n)
		return;
	AfficherArbreConsole(n->droite, level + 1);
	std::cout << std::string(level * 4, ' ');

	if (n->c == 0)
		std::cout << "[" << n->nb << "]" << std::endl;
	else
		std::cout << "[" << n->c << "]" << std::endl;

	AfficherArbreConsole(n->gauche, level + 1);
}
