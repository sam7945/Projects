#include "rle.h"

std::string RLE::Compresser(const std::string & data)
{
	std::string s = LoadFile(data);
	std::string sRetour = "";
	int longueur = s.length();
	for (int i = 0; i < longueur; i++)
	{
		int count = 1;
		while (i < longueur - 1 && s[i] == s[i + 1])
		{
			if (count == 255)
			{
				sRetour += count;
				sRetour += s[i];
				count = 0;
				count++;
				i++;
			}
			else
			{
				count++;
				i++;
			}
		}
		sRetour += count;
		sRetour += s[i];
	}
	std::cout << "rle(" << data << "):	" << s.length() << "    \t\t" << sRetour.size() << "      \t" << std::setprecision(3) << ((double)s.length() / (double)(sRetour.size())) << "    \tOK" << std::endl;
	return sRetour;
}

std::string RLE::Decompresser(const std::string & data)
{
	std::string sRetour = "";
	int longueur = data.length();
	for (int i = 0; i < longueur; i += 2)
	{
		for (int i1 = 0; i1 < (unsigned char)data[i]; i1++)
		{
			sRetour += data[i + 1];
		}
	}
	std::cout << "rle(Decompresse):	" << sRetour.size() << "		OK" << std::endl;
	return sRetour;
}

std::string RLE::LoadFile(const std::string & filename)
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
