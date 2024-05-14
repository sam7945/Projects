using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceObserver
{
    public abstract class EtudiantAbstrait
    {
        public Etudiant Etudiant { get; set; }

        public abstract void Update();
    }
}
