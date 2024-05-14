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
    /// Description:Interface de controle utilisateur pour la partie test
    /// Date:       2019-05-11
    /// </summary>
    [Designer(typeof(DesignerUserTest))]
    [Docking(DockingBehavior.Ask)]
    public partial class UserControlTest : UserControl
    {
        private Metier.GestionClassesPerceptrons _gcpAnalyseEcriture;
        private string _fichier = "";
        private double _ConstApprentissage;
        private bool _ModePhrase;


        public delegate void OkButtonClickHandler(object sender, EventArgs e);

        //Emplacement du fichier
        [Category("Configuration")]
        [Description("L'emplacement et le nom du fichier de sauvegarde du fichier")]
        public string EmplacementFichierTest
        {
            get { return _fichier; }
            set { _fichier = value; }
        }
        //Mode phrase pour une concaténation si vrai
        [Category("Configuration")]
        [Description("Est-ce que vous voulez créer un nouveau fichier de sauvegarde?")]
        public bool ModePhraseTest
        {
            get { return _ModePhrase; }
            set { _ModePhrase = value; }
        }
        //Constante d'apprentissage
        [Category("Configuration")]
        [Description("Vitesse d'apprentissage des perceptrons")]
        public double ConstanteApprentissageTest
        {
            get { return _ConstApprentissage; }
            set { _ConstApprentissage = value; }
        }
        //Les coordonnés du dessin 
        [Browsable(false)]
        public ucZoneDessin Dessin
        {
            get => ucDessin;
            set => ucDessin = value;
        }
        //Instance de la gestion des perceptrons
        [Browsable(false)]
        public Metier.GestionClassesPerceptrons AnalyseEcriture
        {
            get { return _gcpAnalyseEcriture; }
        }
        //Résultat à modifier ou afficher
        [Browsable(false)]
        public string Resultat
        {
            get => txtResultat.Text;
            set => txtResultat.Text = value;
        }
        //Constructeur
        public UserControlTest()
        {
            InitializeComponent();
            _gcpAnalyseEcriture = Metier.GestionClassesPerceptrons.Instance();
            ucDessin.Width = CstApplication.TAILLEDESSINX;
            ucDessin.Height = CstApplication.TAILLEDESSINY;
        }

        [Category("Configuration"), Browsable(true), Description("Évènement associer au click du bouton de test")]

        //évènement qui sera appeler par btnOk
        public event OkButtonClickHandler ButtonOkClick;

        /// <summary>
        /// Évènement appelé par le bouton Ok dans le user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ButtonOkClick != null)
            {
                ButtonOkClick(sender, e);
            }
            
        }
    }
}
