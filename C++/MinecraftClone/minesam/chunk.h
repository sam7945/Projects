#ifndef CHUNK_H__
#define CHUNK_H__
#include "array2d.h"
#include "array3d.h"
#include "vertexbuffer.h"
#include "blockinfo.h"
#include "perlin.h"
#include "vertexbuffer.h"
/*#include "world.h"*/

class Chunk
{
public:
   Chunk(int x, int z) ;
   ~Chunk();

   void RemoveBlock(int x, int y, int z);
   void SetBlock(int x, int y, int z, BlockType type);
   BlockType GetBlock(int x, int y, int z);
   void Render() const;
   bool IsDirty() const;
   void AjouterTerrain();
   void SetIsDirtyTrue();
   void SetIsDirtyFalse();
   void SetSauvegarde();
   bool GetSauvegarde();

    int m_posX;
    int m_posZ;
    VertexBuffer m_vertexBuffer;
private:
   Array3d<BlockType> m_blocks;

   //World m_currentWorld;
   bool m_isDirty = false;
   Perlin perlin;

   bool m_sauvegarder = false;
   //World m_chunks;
};

#endif // CHUNK_H__
