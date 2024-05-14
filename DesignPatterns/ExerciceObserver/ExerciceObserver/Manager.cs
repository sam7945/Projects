using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceObserver
{
    public abstract class Manager
    {
        private List<EtudiantAbstrait> _lstEtu = new List<EtudiantAbstrait>();
        public void Ajouter(EtudiantAbstrait etudiant)
        {
            _lstEtu.Add(etudiant);
        }
        public void Retirer(EtudiantAbstrait etudiant)
        {
            _lstEtu.Remove(etudiant);
        }
        public void Notifier()
        {
            foreach (EtudiantAbstrait e in _lstEtu)
            {
                e.Update();
            }
        }
    }
}
