using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP5.Metier
{
    public interface IGestionClassesPerceptrons
    {
        void ChargerCoordonnees(string fichier);
        string Entrainement(ICoordDessin coordo, string reponse);
        string TesterPerceptron(ICoordDessin coord);
        int SauvegarderCoordonnees(string fichier);
    }
}
