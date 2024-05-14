using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.ClassesPlayer
{
    class Guerrier : Class
    {
        public Guerrier(Player player)
        {
            ID = Classes.Guerrier;
            Owner = player;
            Health = 125;
            LightSourcePower = 64;
            DefaultSprite = "entity/player";
            LiftingSprite = "entity/player_lifting";
            CriticalHit = 0.1f;
            MissHit = 0.08f;
            ExperienceRequired = 100 * Level;
            Damage = 10;
            DamageCritical = 15;
            ItemPref = new List<Items.Item> { Registry.ITEMS.STONE_SWORD, Registry.ITEMS.IRON_SWORD, Registry.ITEMS.GOLD_SWORD, Registry.ITEMS.WOOD_SWORD };
            MissHitWithItem = 0.0f;
            CriticalHitWithItem = 0.17f;
            GTFO = 0.5f;

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
