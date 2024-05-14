using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceObserver
{
    public class Etudiant : Manager
    {
        private string _prenom;
        private string _Nom;
        private bool _tempete;

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                base.Notifier();
            }
        }
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
                base.Notifier();
            }
        }
        public bool Tempete
        {
            get { return _tempete; }
            set
            {
                _tempete = value;
                base.Notifier();
            }
        }
    }
}
