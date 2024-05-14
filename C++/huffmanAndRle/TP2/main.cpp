#include <iostream>
#include <string>
#include "huffman.h"
#include "rle.h"

int main()
{
	std::cout << "Algo		" << "Original	" << "	Compress	" << "Ratio		" << std::endl;
	std::cout << "-------------------------------------------------------------------------------" << std::endl;
	Huffman* h = new Huffman();
	RLE* r = new RLE();
	//std::string s1 = h->Compresser("01.txt");
	//std::string s2 = h->Compresser("02.html");
	//std::string s3 = h->Compresser("03.bmp");
	//std::string s4 = h->Compresser("04.jpg");
	//std::string s5 = h->Compresser("05.exe");
	//std::string s6 = h->Compresser("06.zip");
	//std::string s7 = h->Compresser("07.bin");
	//std::string s8 = h->Compresser("08.bin");
	//std::string s9 = h->Compresser("09.bin");
	//
	//std::string s1_1 = r->Compresser("01.txt");
	//std::string s2_2 = r->Compresser("02.html");
	//std::string s3_3 = r->Compresser("03.bmp");
	//std::string s4_4 = r->Compresser("04.jpg");
	//std::string s5_5 = r->Compresser("05.exe");
	//std::string s6_6 = r->Compresser("06.zip");
	//std::string s7_7 = r->Compresser("07.bin");
	//std::string s8_8 = r->Compresser("08.bin");
	//std::string s9_9 = r->Compresser("09.bin");


	//std::string s1 = h->Decompresser(h->Compresser("et patati et patata petite patate tant pis pour toi"));
	std::string s1 = h->Decompresser(h->Compresser("01.txt"));
	std::string s2 = h->Decompresser(h->Compresser("02.html"));
	std::string s3 = h->Decompresser(h->Compresser("03.bmp"));
	std::string s4 = h->Decompresser(h->Compresser("04.jpg"));
	std::string s5 = h->Decompresser(h->Compresser("05.exe"));
	std::string s6 = h->Decompresser(h->Compresser("06.zip"));
	std::string s7 = h->Decompresser(h->Compresser("07.bin"));
	std::string s8 = h->Decompresser(h->Compresser("08.bin"));
	std::string s9 = h->Decompresser(h->Compresser("09.bin"));
	std::string d1 = r->Decompresser(r->Compresser("01.txt"));
	std::string d2 = r->Decompresser(r->Compresser("02.html"));
	std::string d3 = r->Decompresser(r->Compresser("03.bmp"));
	std::string d4 = r->Decompresser(r->Compresser("04.jpg"));
	std::string d5 = r->Decompresser(r->Compresser("05.exe"));
	std::string d6 = r->Decompresser(r->Compresser("06.zip"));
	std::string d7 = r->Decompresser(r->Compresser("07.bin"));
	std::string d8 = r->Decompresser(r->Compresser("08.bin"));
	std::string d9 = r->Decompresser(r->Compresser("09.bin"));

	//std::string h1 = h->Decompresser(h->Compresser("et patati et patata petite patate tant pis pour toi"));

	system("Pause");
}
