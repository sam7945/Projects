using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.ClassesPlayer
{
    public class Mage : Class
    {
        public Mage(Player player)
        {
            ID = Classes.Mage;
            Owner = player;
            Health = 90;
            DefaultSprite = "entity/mage";
            LiftingSprite = "entity/mage_lifting";
            LightSourcePower = 84;
            CriticalHit = 0.25f;
            MissHit = 0.25f;
            ItemPref = new List<Items.Item> { Registry.ITEMS.STONE_STAFF, Registry.ITEMS.IRON_STAFF, Registry.ITEMS.GOLD_STAFF, Registry.ITEMS.WOOD_STAFF };
            MissHitWithItem = 0.1f;
            CriticalHitWithItem = CriticalHit;
            ExperienceRequired = 100 * Level;
            GTFO = 0.5f;
            Damage = 10;
            DamageCritical = 35;
        }
        public override int Attaquer(Items.Item HoldingItem)
        {
            Random rnd = new Random();
            var random = rnd.NextDouble();

            if (ItemPref.Contains(HoldingItem))
            {
                if (random < CriticalHitWithItem)
                    return DamageCritical;
                else if (random < CriticalHitWithItem + MissHitWithItem)
                    return 0;
                else
                    return Damage;
            }
            else
            {
                if (random < CriticalHit)
                    return DamageCritical;
                else if (random < CriticalHit + MissHit)
                    return 0;
                else
                    return Damage;
            }
        }

    }
}
