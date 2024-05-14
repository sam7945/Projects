using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Registry;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;

namespace Hevadea.Scenes.Tabs
{
    public class TabNewWorld : Tab
    {
        public TabNewWorld()
        {
            Icon = new Sprite(Resources.TileIcons, new Point(1, 2));

            var worldNameTextBox = new WidgetTextBox()//Composantes text box pour inscrire le nom du nouveau monde
            {
                Padding = new Spacing(8),
                Text = "new world",
                UnitBound = new Rectangle(0, 0, 256, 36)
            };
           

            var worldSeedtextBox = new WidgetTextBox() //Composantes text box pour inscrire le seed
            {
                Padding = new Spacing(8),
                Text = Rise.Rnd.Next().ToString(),
                UnitBound = new Rectangle(0, 0, 256, 36)
            };
            
            var classTypeList = new WidgetList() { UnitBound = new Rectangle(0, 0, 256, 120) }; //Créer une liste et ajouter les différentes classes
            foreach (var cl in System.Enum.GetValues(typeof(Entities.ClassesPlayer.Class.Classes)))
            {
                classTypeList.AddItem(new ListItemText(cl.ToString()));
            }
            classTypeList.SelectFirst(); //Selectionner le premier de la liste par défaut

            var worldTypeList = new WidgetList() { UnitBound = new Rectangle(0, 0, 256, 96) };//Créer une liste et ajouter les différents type de monde

            foreach (var item in GENERATOR.GENERATORS) worldTypeList.AddItem(new ListItemText(item.Key)); //Populer la liste de type de monde

            worldTypeList.SelectFirst();//Selectionner le premier de la liste par défaut

            var generateButton = new WidgetButton { Text = "Generate", Dock = Dock.Bottom }
                .RegisterMouseClickEvent((s) => Game.New(worldNameTextBox.Text, worldSeedtextBox.Text,
                    GENERATOR.GENERATORS[((ListItemText)worldTypeList.SelectedItem).Text], classeChoisie: ((ListItemText)classTypeList.SelectedItem).Text));

            var worldOptions = new LayoutFlow//Ajouter les composantes au layout ainsi que les différentes labels
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "World name:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    worldNameTextBox,
                    new WidgetLabel {Text = "Seed:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    worldSeedtextBox,
                    new WidgetLabel
                        {Text = "World type:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    worldTypeList,
                    new WidgetLabel
                        {Text = "Class:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    classTypeList
                }
            };

            Content = new LayoutDock() //Ajouter le bouton sous le layout précédent
            {
                Padding = new Spacing(16),
                Children =
                {
                    new WidgetLabel {Text = "New World", Font = Resources.FontAlagard, Dock = Dock.Top},
                    generateButton,
                    worldOptions
                }
            };
        }
    }
}