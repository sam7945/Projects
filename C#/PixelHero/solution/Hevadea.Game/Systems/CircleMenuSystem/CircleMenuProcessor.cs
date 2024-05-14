using Hevadea.Entities;
using Hevadea.Entities.Components;
using Hevadea.Framework;
using Hevadea.Systems.InventorySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hevadea.Systems.CircleMenuSystem
{
    public class CircleMenuProcessor : EntityUpdateSystem
    {

        public CircleMenuProcessor()
        {
            Filter.AllOf(typeof(CircleMenu), typeof(ComponentInventory));
        }

        public override void Update(Entity entity, GameTime gameTime)
        {


            var menu = entity.GetComponent<CircleMenu>();
            var inventory = entity.GetComponent<ComponentInventory>();

            // si la valeur est plus petite que lancien, on baisse dans linventaire
            if (Rise.Input.ScrollWheelDelta() == true && inventory.Content.GetStackCount() > 0)
            {
                menu.SelectedItem = (menu.SelectedItem - 1) % inventory.Content.GetStackCount();
                if (menu.SelectedItem < 0) menu.SelectedItem = inventory.Content.GetStackCount() - 1;

                menu.Shown();

            }
            // si la valeur est plus grande alors on monte dans linventaire
            else if (Rise.Input.ScrollWheelDelta() == false && inventory.Content.GetStackCount() > 0)
            {
                menu.SelectedItem = (menu.SelectedItem + 1) % inventory.Content.GetStackCount();
                menu.Shown();
            }
            // on egale le state de la valeur de la scrollwheel pour refaire le processus
            entity.HoldItem(inventory.Content.GetStack(menu.SelectedItem));

            if (entity.GetComponent<ComponentItemHolder>()?.HoldedItem?.Name == "Lamp")

                if (entity.GetComponent<ComponentItemHolder>().HoldedItem != null)

                {

                    entity.GetComponent<ComponentLightSource>().Color = Color.LightGoldenrodYellow * 0.75f;
                    entity.GetComponent<ComponentLightSource>().Power = 120;
                }
                else
                {
                    entity.GetComponent<ComponentLightSource>().Color = Color.White * 0.50f;
                    entity.GetComponent<ComponentLightSource>().Power = entity.GameState.LocalPlayer.Entity.Class.LightSourcePower;
                }

            menu.UpdateAnimation(gameTime);
        }
    }
}