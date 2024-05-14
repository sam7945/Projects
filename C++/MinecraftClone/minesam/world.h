#ifndef WORLD_H__
#define WORLD_H__
#include "chunk.h"
#include "array2d.h"
#include "array3d.h"
#include "vector3.h"
#include "blockinfo.h"
#include "player.h"




class World
{
public:
	World(Vector3f* m_currentBlock, Vector3f* m_currentFaceNormal, Vector3f* m_posPrecedent, Player* player);
	~World();



	Array2d<Chunk*> getChunks() const;
	void setChunks(int x, int y);

	void GetBlocAtCursor(int Width, int Height, bool m_click);
	void Craft();
	template<class T>
	Chunk* ChunkAt(T x, T y, T z) ;
	template<class T>
	Chunk* ChunkAt(const Vector3<T>& pos) ;
	template<class T>
	BlockType BlockAt(T x, T y, T z) ;
	template<class T>
	bool EqualWithEpsilon(const T& v1, const T& v2, T epsilon);
	template<class T>
	bool InRangeWithEpsilon(const T& v, const T& vinf, const T& vsup, T epsilon);
    void AddBlockToMesh(VertexBuffer::VertexData* vd, int & count, BlockType bt, int x, int y, int z, float u, float v, float w);
    void Update(BlockInfo* blockinfo[], int x1, int z1);

private:
	Array2d<Chunk*> m_chunks;
	Vector3f* m_currentBlock;
	Vector3f* m_currentFaceNormal;
	Vector3f* m_posPrecedent;
	Player* m_player;


};
template <class T>
Chunk* World::ChunkAt(T x, T y, T z)
{
	int cx = (int)x / CHUNK_SIZE_X;
	int cz = (int)z / CHUNK_SIZE_Z;
	// validation...

	if (cx < 0 || cz < 0 || cx >= CHUNK_SIZE_X || cz >= CHUNK_SIZE_Z)
		return NULL;

	return getChunks().Get(cx, cz);
}

template <class T>
Chunk* World::ChunkAt(const Vector3<T>& pos)
{
	return ChunkAt(pos.x, pos.y, pos.z);
}

template <class T>
BlockType World::BlockAt(T x, T y, T z)
{
	Chunk* c = this->ChunkAt(x, y, z);

	if (!c)
		return BTYPE_AIR;

	int bx = (int)x % CHUNK_SIZE_X;
	int by = (int)y % CHUNK_SIZE_Y;
	int bz = (int)z % CHUNK_SIZE_Z;

	return c->GetBlock(bx, by, bz);
}
template <class T>
bool World::EqualWithEpsilon(const T& v1, const T& v2, T epsilon)
{
	return (fabs(v2 - v1) < epsilon);
}

template <class T>
bool World::InRangeWithEpsilon(const T& v, const T& vinf, const T& vsup, T epsilon)
{
	return (v >= vinf - epsilon && v <= vsup + epsilon);
}





#endif // WORLD_H_

