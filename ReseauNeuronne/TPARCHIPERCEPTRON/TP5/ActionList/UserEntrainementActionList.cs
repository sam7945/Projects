using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace TP5.ActionList
{
    /// <summary>
    /// Auteur:     Samuel Dextraze et Raphael Bernatchez-Lemieux
    /// Description:Classe qui définie les actions possible du smart tag correspondant
    /// Date:       2019-05-11
    /// </summary>
    public class UserEntrainementActionList : DesignerActionList
    {
        public UserEntrainementActionList(IComponent component) : base(component)
        {
        }
        //Emplacement du fichier d'entrainement
        [Category("Configuration")]
        [Description("L'emplacement et le nom du fichier de sauvegarde du fichier")]
        public string EmplacementFichierEntrainement
        {
            get { return ((UserControlEntrainement)this.Component).EmplacementFichierEntrainement; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["EmplacementFichierEntrainement"];
                prop.SetValue(this.Component, value);
            }
        }
        //Nouveau fichier d'entrainement ou non?
        [Category("Configuration")]
        [Description("Est-ce que vous voulez créer un nouveau fichier de sauvegarde?")]
        public bool NouveauFichierEntrainement
        {
            get { return ((UserControlEntrainement)this.Component).NouveauFichierEntrainement; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["NouveauFichierEntrainement"];
                prop.SetValue(this.Component, value);
            }
        }
        //Constante d'apprentissage des perceptrons
        [Category("Configuration")]
        [Description("Vitesse d'apprentissage des perceptrons")]
        public double ConstanteApprentissageEntrainement
        {
            get { return ((UserControlEntrainement)this.Component).ConstanteApprentissageEntrainement; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["ConstanteApprentissageEntrainement"];
                prop.SetValue(this.Component, value);
            }
        }

        /// <summary>
        /// Definition du menu de smart tag
        /// </summary>
        /// <returns></returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Paramètre"));
            items.Add(new DesignerActionPropertyItem("EmplacementFichierEntrainement", "Définissez l'emplacement du fichier"));
            items.Add(new DesignerActionPropertyItem("NouveauFichierEntrainement", "Définissez si vous voulez créer un nouveau fichier de sauvegarde"));
            items.Add(new DesignerActionPropertyItem("ConstanteApprentissageEntrainement", "Définissez la constante d'apprentissage"));
            return items;
        }
    }
}
