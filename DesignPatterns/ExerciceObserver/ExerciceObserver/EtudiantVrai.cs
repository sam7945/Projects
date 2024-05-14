using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceObserver
{
    public class EtudiantVrai : EtudiantAbstrait
    {
        private TextBox _textBox;
        public EtudiantVrai(Etudiant etudiant, TextBox txtResultat)
        {
            _textBox = txtResultat;
            base.Etudiant = etudiant;
        }
        public override void Update()
        {
            _textBox.Text += $"Le prénom de l'etudiant est {base.Etudiant.Prenom}\r\n";
            _textBox.Text += $"Le nom de l'etudiant est {base.Etudiant.Nom}\r\n";
            _textBox.Text += $"Est-ce que la tempête arrive: {base.Etudiant.Tempete}\r\n";
            _textBox.Text += "\r\n";
        }
    }
}
