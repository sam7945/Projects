using Hevadea.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.ClassesPlayer
{

    public abstract class Class
    {
        public enum Classes
        {
            Archer,
            Mage,
            Guerrier
        }

        public Classes ID { get; protected set; }
        public int Health { get; set; }
        public Player Owner { get; set; }
        public string DefaultSprite { get; protected set; }
        public string LiftingSprite { get; protected set; }
        public int LightSourcePower { get; set; }
        public List<Items.Item> ItemPref { get; protected set; }
        public float CriticalHitWithItem { get; protected set; }
        public float MissHitWithItem { get; protected set; }
        public float CriticalHit { get; protected set; }
        public float MissHit { get; protected set; }
        public int Damage { get; set; }
        public int DamageCritical { get; set; }
        public float GTFO { get; protected set; } = 0.5f; //Probabilité de fuir
        public int Level { get; set; } = 1;
        public float Experience { get; set; }
        public float ExperienceRequired { get; set; } = 100;



        public abstract int Attaquer(Items.Item HoldingItem);

        private void levelUp()
        {
            Level++;
            Experience -= ExperienceRequired;
            IntializeProps(true);
        }
        public void IntializeProps(bool LevelUp = false)
        {
            if (!LevelUp)
                Health += (Level * 5);
            else
                Health += 5;
            Owner.GetComponent<ComponentHealth>().MaxValue = Health;
            if (LevelUp)
                Owner.GetComponent<ComponentHealth>().Value = Health;

            if (LevelUp)
                LightSourcePower += 5;
            else
                LightSourcePower += (Level * 5);
            Owner.GetComponent<ComponentLightSource>().Power = LightSourcePower;
            if (LevelUp)
            {
                Damage += 1;
                DamageCritical += 1;
            }
            else
            {
                Damage += Level;
                DamageCritical += Level;
            }
            ExperienceRequired = 100 * Level;
        }

        public void Exp()
        {
            Experience += 50;

            if (Experience >= ExperienceRequired)
                levelUp();
        }
        public Class GetClassById(Classes PlayerClass, Player player)
        {


            switch (PlayerClass)
            {
                case Classes.Archer:
                    return new Archer(player);
                case Classes.Mage:
                    return new Mage(player);
                case Classes.Guerrier:
                    return new Guerrier(player);
                default:
                    return new Archer(player);
            }

        }
    }
}
