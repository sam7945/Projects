using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Auteur: Samuel Dextraze
    /// Description: objet qui gère la création des objet produits
    /// Date:2018-02-04
    /// </summary>
    public class Createur
    {
        /// <summary>
        /// Auteur: Samuel Dextraze
        /// Description: objet qui gère la création des fraises en fonction du mois du l'années
        /// Date:2018-02-04
        /// </summary>
        public IProduit FactoryMethod(int iMois)
        {
            IProduit produit;
            if (iMois >= 6 && iMois <= 9)
                produit = new FraiseQuebecs();
            else if (iMois >= 10 && iMois <= 12)
                produit = new FraiseUSA();
            else
                produit = new FraiseMexique();
            return produit;
        }
    }
}
