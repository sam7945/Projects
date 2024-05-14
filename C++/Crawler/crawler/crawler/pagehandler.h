#ifndef PAGE_HANDLER_H__
#define PAGE_HANDLER_H__

#include <string>

class PageHandler
{
public:
	virtual ~PageHandler() {}
	// M´ethode appelée pour chaque page , le contenu html de la page est passé en paramêtre
	virtual void HandlePage(std::string & html) = 0;
	// AfficherResultat sera appelée une seule fois lorsque le crawler aura termin´e de s’exécuter et affichera l’information demandée
	virtual void AfficherResultat() = 0;

};

#endif