using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.ClassesPlayer
{
    public class Archer : Class
    {
        public Archer(Player player)
        {
            ID = Classes.Archer;
            Owner = player;            
            Health = 100;
            LightSourcePower = 64;
            ExperienceRequired = 100 * Level;
            DefaultSprite = "entity/archer";
            LiftingSprite = "entity/archer_lifting";
            Damage = 17;
            DamageCritical = 27;
            CriticalHit = 0.07f;
            MissHit = 0.15f;
            ItemPref = new List<Items.Item>{Registry.ITEMS.WOOD_BOW, Registry.ITEMS.STONE_BOW, Registry.ITEMS.GOLD_BOW, Registry.ITEMS.IRON_BOW};
            MissHitWithItem = 0.05f;
            CriticalHitWithItem = 0.17f;
            GTFO = 0.75f;
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
