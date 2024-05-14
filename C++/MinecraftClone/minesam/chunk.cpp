#include "chunk.h"
#include <iostream>
#include "vertexbuffer.h"
#include <cstdlib>
#include <fstream>



Chunk::Chunk( int x1, int z1) : m_blocks(CHUNK_SIZE_X, CHUNK_SIZE_Y, CHUNK_SIZE_Z), perlin(16, 6, 1, 95)
{
	m_posX = x1;
	m_posZ = z1;

	std::string load = "sauvegarde" + std::to_string(m_posX) + "_" + std::to_string(m_posZ);
	std::ifstream entrer(load, std::fstream::binary);

	if (entrer.good())
	{
		//taille fichier
		entrer.seekg(0, std::ios_base::end);
		int size = entrer.tellg();
		entrer.seekg(0, std::ios_base::beg);

		BlockType* donner = new BlockType[size];
		entrer.read((char*)donner, size);
		entrer.close();

		m_blocks.SetTableauInterne((BlockType*)donner);
		m_isDirty = true;
	}
	else
	{

		m_blocks.Reset(BTYPE_AIR);
		int y1 = 0;
		for (int x = 0; x < CHUNK_SIZE_X; ++x)
		{
			for (int z = 0; z < CHUNK_SIZE_Z; ++z)
			{
				// La m´ethode Get accepte deux param^etre ( coordonn´ee en X et Z) et retourne une valeur qui respecte
				// les valeurs utilis´ees lors de la cr´eation de l ’ objet Perlin
				// La valeur retourn´ee est entre 0 et 1
				float val = perlin.Get((float)(m_posX * CHUNK_SIZE_X + x) / 2000.f, (float)(m_posZ * CHUNK_SIZE_Z + z) / 2000.f);
				// Utiliser val pour d´eterminer la hauteur du terrain `a la position x , z
				// Vous devez vous assurer que la hauteur ne d´epasse pas CHUNK_SIZE_Y
				// Remplir les blocs du bas du terrain jusqu ’ `a la hauteur calcul´ee .
				// N ’ h´esitez pas `a jouer avec la valeur retourn´ee pour obtenir un r´esultat qui vous semble satisfaisant
				y1 = 32 + (val * 64);

				if (y1 >= 30)
				{
					SetBlock(x, y1, z, BTYPE_SNOW);
				}
				else if (y1 <= 16)
				{
					SetBlock(x, y1, z, BTYPE_SAND);

				}
				else
				{
					SetBlock(x, y1, z, BTYPE_GRASS);

				}

			}
		}
		for (int x = 0; x < CHUNK_SIZE_X; ++x)
		{
			for (int z = 0; z < CHUNK_SIZE_Z; ++z)
			{
				for (int y = (CHUNK_SIZE_Y - 4); y > 0; --y)
				{
					//r = (std::rand() % 7) + 1;
					if (GetBlock(x, y + 1, z) == BTYPE_GRASS || GetBlock(x, y + 2, z) == BTYPE_GRASS || GetBlock(x, y + 3, z) == BTYPE_GRASS)
					{
						SetBlock(x, y, z, BTYPE_DIRT);
					}
					if (GetBlock(x, y + 1, z) == BTYPE_SNOW || GetBlock(x, y + 2, z) == BTYPE_SNOW || GetBlock(x, y + 3, z) == BTYPE_SNOW)
					{
						SetBlock(x, y, z, BTYPE_DIRT);
					}
					if (GetBlock(x, y + 1, z) == BTYPE_SAND || GetBlock(x, y + 2, z) == BTYPE_SAND || GetBlock(x, y + 3, z) == BTYPE_SAND)
					{
						SetBlock(x, y, z, BTYPE_DIRT);
					}
				}
			}
		}
		for (int x = 0; x < CHUNK_SIZE_X; ++x)
		{
			for (int z = 0; z < CHUNK_SIZE_Z; z++)
			{
				int y = 0;
				while (GetBlock(x, y, z) != BTYPE_DIRT)
				{
					SetBlock(x, y, z, BTYPE_COBBLESTONE);
					++y;
				}
			}
		}
	}
}


Chunk::~Chunk()
{
	if (m_sauvegarder)
	{
		std::string s = "sauvegarde" + std::to_string(m_posX) + "_" + std::to_string(m_posZ);
		std::ofstream sauvegarde(s, std::fstream::binary);
		sauvegarde.write((char*)m_blocks.GetTableauInterne(), (CHUNK_SIZE_X*CHUNK_SIZE_Y*CHUNK_SIZE_Z));
		sauvegarde.close();
	}
}

void Chunk::RemoveBlock(int x, int y, int z)
{
	m_isDirty = true;
	m_blocks.Set(x, y, z, BTYPE_AIR);

}

void Chunk::SetBlock(int x, int y, int z, BlockType type)
{

	m_isDirty = true;
	m_blocks.Set(x, y, z, type);

}

BlockType Chunk::GetBlock(int x, int y, int z)
{
	return m_blocks.Get(x, y, z);
}


void Chunk::AjouterTerrain()
{
	//porte
	SetBlock(12, 3, 1, BTYPE_CRAFT);
	SetBlock(12, 4, 1, BTYPE_CRAFT);
	SetBlock(12, 5, 1, BTYPE_CRAFT);
	SetBlock(12, 5, 2, BTYPE_CRAFT);
	SetBlock(12, 5, 3, BTYPE_CRAFT);
	SetBlock(12, 4, 3, BTYPE_CRAFT);
	SetBlock(12, 3, 3, BTYPE_CRAFT);

	//escalier
	SetBlock(6, 3, 8, BTYPE_CRAFT);
	SetBlock(7, 4, 8, BTYPE_CRAFT);
	SetBlock(8, 5, 8, BTYPE_CRAFT);
	SetBlock(9, 6, 8, BTYPE_CRAFT);

	//mur1
	for (size_t y = 3; y < 6; y++)
	{
		for (size_t z = 11; z < 15; z++)
		{
			SetBlock(5, y, z, BTYPE_CRAFT);
		}
	}

	//mur2
	for (size_t x = 8; x < 12; x++)
	{
		for (size_t y = 3; y < 6; y++)
		{
			SetBlock(x, y, 11, BTYPE_CRAFT);
		}
	}

}
void Chunk::SetIsDirtyTrue()
{
	m_isDirty = true;
}
void Chunk::SetIsDirtyFalse()
{
    m_isDirty = false;
}

void Chunk::SetSauvegarde()
{
	m_sauvegarder = true;
}

bool Chunk::GetSauvegarde()
{
	return m_sauvegarder;
}

void Chunk::Render() const
{
	m_vertexBuffer.Render();
};
bool Chunk::IsDirty() const
{
	return m_isDirty;
};

