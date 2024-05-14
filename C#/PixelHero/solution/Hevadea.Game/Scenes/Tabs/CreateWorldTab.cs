using Hevadea.Entities;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Models;
using Hevadea.Registry;
using Hevadea.Scenes.Menus;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hevadea.Entities.ClassesPlayer.Class;

namespace Hevadea.Scenes.Tabs
{
    class CreateWorldTab : Tab
    {
        public WidgetTextBox worldNameTextbox = new WidgetTextBox();
        WidgetList worldTypeList = new WidgetList() { UnitBound = new Rectangle(0, 0, 256, 96) };//Créer une liste et ajouter les différents type de monde

        public WidgetButton confirmButton = new WidgetButton();
        private WidgetLabel label = new WidgetLabel { Text = "New world", Font = Resources.FontAlagard, Dock = Dock.Top };
        public CreateWorldTab(Player player, Account account, IQueryable<WorldPlayer> worldPlayers)
        {
            WidgetLabel seedLabel = new WidgetLabel { Text = "Seed:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left };
            WidgetTextBox worldSeedtextBox = new WidgetTextBox() //Composantes text box pour inscrire le seed
            {
                Padding = new Spacing(8),
                Text = Rise.Rnd.Next().ToString(),
                UnitBound = new Rectangle(0, 0, 256, 36)
            };

            Icon = new Sprite(Resources.TileIcons, new Point(1, 3));

            worldNameTextbox.Padding = new Spacing(8);
            worldNameTextbox.Text = "";
            worldNameTextbox.UnitBound = new Rectangle(0, 0, 256, 36);


            confirmButton.Text = "Create";
            confirmButton.Dock = Dock.Bottom;
            confirmButton.RegisterMouseClickEvent(OnClickConfirmation);
            WidgetLabel worldTypesLabel = new WidgetLabel
            { Text = "World type:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left };

            foreach (var item in GENERATOR.GENERATORS) worldTypeList.AddItem(new ListItemText(item.Key)); //Populer la liste de type de monde

            worldTypeList.SelectFirst();//Selectionner le premier de la liste par défaut
            WidgetBackButton backBtn = new WidgetBackButton((sender) =>
            {
                Rise.Scene.Switch(new MenuChoisirMonde(worldPlayers,account));
            });


            void OnClickConfirmation()
            {
                if (worldNameTextbox.Text != "" && !REGISTRY.Context.Worlds.Any(x => x.Name == worldNameTextbox.Text))
                {
                    Game.New(worldNameTextbox.Text, worldSeedtextBox.Text,
                        GENERATOR.GENERATORS[((ListItemText)worldTypeList.SelectedItem).Text], true);
                }
                else
                {
                    label.Text = "Already Exists";
                }
            }


            var persoOptions = new LayoutFlow//Ajouter les composantes au layout ainsi que les différentes labels
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {                    
                    new WidgetLabel
                        {Text = "World name:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    worldNameTextbox,
                    seedLabel,
                    worldSeedtextBox,
                    worldTypesLabel,
                    worldTypeList,
                }
            };
            Content = new LayoutDock() //Ajouter le bouton sous le layout précédent
            {
                Padding = new Spacing(16),
                Children =
                {
                    backBtn,
                    label,
                    confirmButton,
                    persoOptions
                }
            };
        }
    }
}
