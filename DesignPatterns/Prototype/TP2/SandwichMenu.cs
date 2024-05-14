using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class SandwichMenu
    {
        private Dictionary<string, ISandwichPrototype> _sandwiches = new Dictionary<string, ISandwichPrototype>();

        public ISandwichPrototype this[string name]
        {
            get { return _sandwiches[name]; }
            set { _sandwiches.Add(name, value); }
        }
    }
}
