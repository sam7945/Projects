#ifndef ENGINE_H__
#define ENGINE_H__

#include "openglcontext.h"
#include "texture.h"
#include "player.h"
#include "shader.h"
#include "textureatlas.h"
#include "blockinfo.h"
#include "array2d.h"
#include "world.h"

class Engine : public OpenglContext
{
public:
	Engine();
	virtual ~Engine();
	virtual void Init();
	virtual void DeInit();
	virtual void LoadResource();
	virtual void UnloadResource();
	virtual void Render(float elapsedTime);
	virtual void KeyPressEvent(unsigned char key);
	virtual void KeyReleaseEvent(unsigned char key);
	virtual void MouseMoveEvent(int x, int y);
	virtual void MousePressEvent(const MOUSE_BUTTON &button, int x, int y);
	virtual void MouseReleaseEvent(const MOUSE_BUTTON &button, int x, int y);
	virtual void DrawHud();
	virtual void PrintText(unsigned int x, unsigned int y, const std::string & t);
	virtual int GetFps();



private:
	bool LoadTexture(Texture& texture, const std::string& filename, bool stopOnError = true);

private:
	bool m_wireframe = false;

	Texture m_textureFont;
	Texture m_textureCrosshair;
	Player m_player;
	World m_world;
	Shader m_shader01;
	TextureAtlas m_textureAtlas;
	BlockInfo* m_blockinfo[BTYPE_LAST];

	Vector3f m_currentBlock;
	Vector3f m_currentFaceNormal;
	Vector3f m_posPrecedent;

	Texture m_textureDirt;
	Texture m_textureCobble;
	Texture m_textureGrass;
	Texture m_texturetable;
	Texture m_textureHUD;
	Texture m_textureObsidian;
	Texture m_textureWood;
	Texture m_textureLeaf;
	Texture m_texturePlank;


	//VertexBuffer::VertexData* vd = new VertexBuffer::VertexData[8];

	bool m_keyW = false;
	bool m_keyA = false;
	bool m_keyS = false;
	bool m_keyD = false;
	bool m_KeySpace = false;
	bool m_Keyshift = false;

	float m_ET;
	float m_vueCol = 0.5f;

	bool m_collisionY = false;
	
	bool m_click = false;

	int m_choixHUDX = 190;
	int m_choixHUDY = 65;
	int m_choix = 1;
};

#endif // ENGINE_H__
