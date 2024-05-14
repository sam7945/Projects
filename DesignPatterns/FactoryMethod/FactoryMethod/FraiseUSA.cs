using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Auteur:      Samuel dextraze
    /// Description: Fraise des USA
    /// Date:        2018-02-04
    /// </summary>
    public class FraiseUSA : IProduit
    {
        public string RetournerPays()
        {
            return "USA, avec ben des guns";
        }
    }
}
