using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Auteur:      samuel dextraze
    /// Description: Interface définissant les méthodes à implémenter dans les produits.
    /// Date:        2018-02-04
    /// </summary>
    public interface IProduit
    {
        string RetournerPays();
    }
}
