using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5.ActionList
{
    /// <summary>
    /// Auteur:     Samuel Dextraze et Raphael Bernatchez-Lemieux
    /// Description:Classe qui définie les actions possible du smart tag correspondant
    /// Date:       2019-05-11
    /// </summary>
    public class UserTestActionList : DesignerActionList
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="component"></param>
        public UserTestActionList(IComponent component) : base(component)
        {
        }
        //Emplacement du fichier
        [Category("Configuration")]
        [Description("L'emplacement et le nom du fichier de sauvegarde du fichier")]
        public string EmplacementFichierTest
        {
            get { return ((UserControlTest)this.Component).EmplacementFichierTest; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["EmplacementFichierTest"];
                prop.SetValue(this.Component, value);
            }
        }
        //Mode phrase(concaténation) oui ou non?
        [Category("Configuration")]
        [Description("Est-ce que vous voulez être en mode phrase?")]
        public bool ModePhraseTest
        {
            get { return ((UserControlTest)this.Component).ModePhraseTest; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["ModePhraseTest"];
                prop.SetValue(this.Component, value);
            }
        }
        //Constante d'apprentissage des perceptrons
        [Category("Configuration")]
        [Description("Vitesse d'apprentissage des perceptrons")]
        public double ConstanteApprentissageTest
        {
            get { return ((UserControlTest)this.Component).ConstanteApprentissageTest; }
            set
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(this.Component)["ConstanteApprentissageTest"];
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
            items.Add(new DesignerActionPropertyItem("EmplacementFichierTest", "Définissez l'emplacement du fichier"));
            items.Add(new DesignerActionPropertyItem("ModePhraseTest", "Définissez si vous voulez être en mode phrase"));
            items.Add(new DesignerActionPropertyItem("ConstanteApprentissageTest", "Définissez la constante d'apprentissage"));
            return items;
        }
    }
}
