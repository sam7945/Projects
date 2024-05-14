#ifndef PAGE_HANDLER_H__
#define PAGE_HANDLER_H__

#include <string>

class PageHandler
{
public:
	virtual ~PageHandler() {}
	// M�ethode appel�e pour chaque page , le contenu html de la page est pass� en param�tre
	virtual void HandlePage(std::string & html) = 0;
	// AfficherResultat sera appel�e une seule fois lorsque le crawler aura termin�e de s�ex�cuter et affichera l�information demand�e
	virtual void AfficherResultat() = 0;

};

#endif