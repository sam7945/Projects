using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP5.Metier
{
    public interface IPerceptron
    {
        string Entrainement(List<ICoordDessin> lstCoord);

        int ValeurEstime(double[] vecteurSyn, BitArray entree);
        bool TesterNeurone(ICoordDessin coord);
        string Reponse { get; }
    }
}
