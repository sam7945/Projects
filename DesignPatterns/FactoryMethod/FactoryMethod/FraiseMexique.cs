using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Auteur:      Samuel dextraze
    /// Description: Fraise du Mexique
    /// Date:        2018-02-04
    /// </summary>
    public class FraiseMexique : IProduit
    {
        public string RetournerPays()
        {
            return "Fraise du Mexique, miam des pesticides pi d'la coke!!";
        }
    }
}
