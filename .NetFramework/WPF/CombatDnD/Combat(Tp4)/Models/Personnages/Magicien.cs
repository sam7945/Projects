using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combat_Tp4_.Models.Personnages
{
    public class Magicien : Personnage
    {
        public string Potions { get; set; }

        public string Sorts { get; set; }

        public int Nombre_Potion { get; set; }
    }
}