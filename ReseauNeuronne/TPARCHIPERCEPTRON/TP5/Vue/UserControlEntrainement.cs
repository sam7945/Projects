using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP5.Designer;

namespace TP5
{
    /// <summary>
    /// Auteur:     Samuel Dextraze et Raphael Bernatchez-Lemieux
    /// Description:Interface de controle utilisateur pour la partie Entrainement
    /// Date:       2019-05-11
    /// </summary>
    [Designer(typeof(DesignerUserEntrainement))]
    [Docking(DockingBehavior.Ask)]
    public partial class UserControlEntrainement : UserControl
    {
        private Metier.GestionClassesPerceptrons _gcpAnalyseEcriture;
        private string _fichier = "";
        private double _ConstApprentissage ;
        private bool _NouvFichier;

        public delegate void TrainButtonClickHandler(object sender, EventArgs e);
        public delegate void EraseButtonClickHandler(object sender, EventArgs e);

        //Emplacement du fichier d'entrainement
        [Category("Configuration")]
        [Description("L'emplacement et le nom du fichier de sauvegarde du fichier")]
        public string EmplacementFichierEntrainement
        {
            get { return _fichier; }
            set { _fichier = value; }
        }

        //Créer un nouveau fichier d'entrainement ou non?
        [Category("Configuration")]
        [Description("Est-ce que vous voulez créer un nouveau fichier de sauvegarde?")]
        public bool NouveauFichierEntrainement
        {
            get{ return _NouvFichier; }
            set { _NouvFichier = value; }
        }
        //La constante d'apprentissage 
        [Category("Configuration")]
        [Description("Vitesse d'apprentissage des perceptrons")]
        public double ConstanteApprentissageEntrainement
        {
            get { return _ConstApprentissage; }
            set { _ConstApprentissage = value; }
        }
        //Le dessin dessiner dans l'interface d'entrainement
        [Browsable(false)]
        public ucZoneDessin Dessin
        {
            get => ucDessin;
            set => ucDessin = value;
        }
        //La valeur entrainer dans le perceptron
        [Browsable(false)]
        public string Valeur
        {
            get => txtValeurEntrainee.Text;
        }
        //L'instance de la gestion des perceptrons
        [Browsable(false)]
        public Metier.GestionClassesPerceptrons AnalyseEcriture
        {
            get { return _gcpAnalyseEcriture; }
        }

        //Constructeur
        public UserControlEntrainement()
        {
            InitializeComponent();
            _gcpAnalyseEcriture = Metier.GestionClassesPerceptrons.Instance();
            ucDessin.Width = CstApplication.TAILLEDESSINX;
            ucDessin.Height = CstApplication.TAILLEDESSINY;
        }

        [Category("Configuration"), Browsable(true), Description("Évènement associer au click du bouton de validation")]
        public event TrainButtonClickHandler ButtonTrainClick;
        [Category("Configuration"), Browsable(true), Description("Évènement associer au click du bouton de validation")]
        public event EraseButtonClickHandler ButtonEraseClick;

        /// <summary>
        /// Le bouton appelant l'évènement qui déclanche l'entrainement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrainement_Click(object sender, EventArgs e)
        {
            if (ButtonTrainClick != null)
            {
                ButtonTrainClick(sender, e);
            }
        }
        /// <summary>
        /// Le bouton appelant l'évènement qui déclanche l'effacement du dessin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEffacer_Click(object sender, EventArgs e)
        {

            if (ButtonEraseClick != null)
            {
                ButtonEraseClick(sender, e);
            }

            ucDessin.EffacerDessin();
        }
    }
}
