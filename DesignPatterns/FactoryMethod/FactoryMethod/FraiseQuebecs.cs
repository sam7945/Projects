using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Auteur:      Samuel dextraze
    /// Description: Fraise du québec
    /// Date:        2018-02-04
    /// </summary>
    public class FraiseQuebecs : IProduit
    {
        public string RetournerPays()
        {
            return "Québec";
        }
    }
}
