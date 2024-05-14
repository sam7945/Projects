using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonExercice
{
    public class Adresse
    {
        private static Adresse _instance;

        public Dictionary<string, string> adresses { get; set; } = new Dictionary<string,string>();

        protected Adresse()
        {

        }

        public static Adresse Instance()
        {
            if (_instance == null)
                _instance = new Adresse();
            return _instance;
        }
    }
}
