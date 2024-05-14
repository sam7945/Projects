using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using TP5.ActionList;

namespace TP5.Designer
{
    /// <summary>
    /// Auteur:     Samuel Dextraze et Raphael Bernatchez-Lemieux
    /// Description:Classe qui Override du designer action list par défaut de windows form avec d'autre action
    /// Date:       2019-05-11
    /// </summary>
    public class DesignerUserEntrainement : ControlDesigner
    {
        /// <summary>
        /// Override du designer action list
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection collection = new DesignerActionListCollection();
                UserEntrainementActionList actionList = new UserEntrainementActionList(this.Control);
                collection.Add(actionList);
                return collection;
            }

        }
    }
}
