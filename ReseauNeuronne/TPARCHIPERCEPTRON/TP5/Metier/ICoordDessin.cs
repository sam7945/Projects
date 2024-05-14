using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP5.Metier
{
    public interface ICoordDessin
    {
        BitArray BitArrayDessin { get; }
        string Reponse { get; set; }
        void AjouterCoordonnees(int x, int y, int tailleX, int tailleY);
    }
}
