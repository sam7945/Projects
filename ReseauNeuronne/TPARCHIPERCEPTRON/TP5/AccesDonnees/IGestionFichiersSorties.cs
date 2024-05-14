using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP5.Metier;

namespace TP5.AccesDonnees
{
    public interface IGestionFichiersSorties
    {
        List<Metier.ICoordDessin> ChargerCoordonnees(string fichier);
        int SauvegarderCoordonnees(string fichier, List<Metier.ICoordDessin> lstCoord);
    }
}
