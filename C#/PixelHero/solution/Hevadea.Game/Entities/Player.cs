using Hevadea.Entities.Blueprints;
using Hevadea.Entities.ClassesPlayer;
using Hevadea.Entities.Components;
using Hevadea.Framework;
using Hevadea.Items;
using Hevadea.Items.Tags;
using Hevadea.Models;
using Hevadea.Registry;
using Hevadea.Scenes.Menus;
using Hevadea.Scenes.Tabs;
using Hevadea.Storage;
using Hevadea.Systems.CircleMenuSystem;
using Hevadea.Systems.InventorySystem;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using static Hevadea.Entities.ClassesPlayer.Class;

namespace Hevadea.Entities
{
    public class Player : Entity
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public Classes Classe { get; set; }
        [NotMapped]
        public Class Class { get; set; }
        public float Health { get; set; }
        public bool IsInCombat { get; set; }
        [NotMapped]
        public int LastCombat { get; set; }

        [NotMapped]
        public int LastLevel { get; set; }
        public ICollection<WorldPlayer> WorldPlayers { get; set; }
        [NotMapped]
        public Thread MovementThread { get; set; }

        public Player()
        {
            LastLevel = 0;
            AddComponent(new ComponentMove());
            InitializeClass();
            AddComponent(new ComponentFlammable());
            AddComponent(new ComponentItemHolder());

            AddComponent(new ComponentAttack());
            AddComponent(new ComponentCollider(new Rectangle(-2, -2, 4, 4)));
            AddComponent(new ComponentEnergy());
            AddComponent(new ComponentInteract());
            AddComponent(new ComponentInventory(64) { AlowPickUp = true });
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPickup());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentRevealMap());
            AddComponent(new ComponentCastShadow());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentPlayerBody());
            AddComponent(new CircleMenu());
            AddComponent(new ComponentExperience());
            AddComponent(new ComponentRider());

        }
        private void InitializeClass(bool Saved = false)
        {
            string cl = Game.Classe;
            if (cl == "Archer")
                Class = new Archer(this);

            else if (cl == "Mage")
                Class = new Mage(this);

            else if (cl == "Guerrier")
                Class = new Guerrier(this);


            if (Class == null)
                Class = new Archer(this);

            if (!Saved)
            {
                Componenents.RemoveAll(x => x is ComponentHealth);
                var health = new ComponentHealth(Class.Health) { ShowHealthBar = false, NaturalRegeneration = true };
                health.Killed += Health_Killed;
                AddComponent(health);
            }
            Componenents.RemoveAll(x => x is ComponentLightSource);
            AddComponent(new ComponentLightSource { IsOn = true, Color = Color.White * 0.50f, Power = Class.LightSourcePower });

            Componenents.RemoveAll(x => x is RendererCreature);
            AddComponent(new RendererCreature(Resources.Sprites[Class.DefaultSprite], Resources.Sprites[Class.LiftingSprite]));
            DamageTag Tag;
            switch (Class.ID)
            {
                case Classes.Archer:
                    Tag = ITEMS.WOOD_BOW.Tag<DamageTag>();
                    Tag.PerEntityDamage.Clear();
                    Tag.PerEntityDamage.Add(new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 3f));
                    break;
                case Classes.Mage:
                    Tag = ITEMS.WOOD_STAFF.Tag<DamageTag>();
                    Tag.PerEntityDamage.Clear();
                    Tag.PerEntityDamage.Add(new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 3f));
                    break;
                case Classes.Guerrier:
                    Tag = ITEMS.WOOD_SWORD.Tag<DamageTag>();
                    Tag.PerEntityDamage.Clear();
                    Tag.PerEntityDamage.Add(new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 3f));
                    break;
                default:
                    break;
            }
        }

        private void Health_Killed(object sender, System.EventArgs e)
        {
            GameState.CurrentMenu = new MenuPlayerRespawn(GameState);
        }

        public override void OnSave(EntityStorage store)
        {
            store.Value("level", Level?.LevelId ?? -1);
            store.Value("class", (int)Class.ID);
            store.Value("classLevel", Class.Level);
            store.Value("experience", Class.Experience);

        }

        public override void OnLoad(EntityStorage store)
        {
            if (Game.WorldPlayer == null)
            {
                LastLevel = store.ValueOf("level", 0);
                Class = Class.GetClassById((Class.Classes)store.ValueOf("class", 0), this);
                InitializeClass(true);
                Class.Level = store.ValueOf("classLevel", 1);
                Class.Experience = store.ValueOf("experience", 0f);
                Class.IntializeProps();
                var a = this;
            }
            else
            {
                getOnlineModelInfo(Game.WorldPlayer);
            }
        }
        public void getOnlineModelInfo(WorldPlayer worldPlayer)
        {
            PlayerId = worldPlayer.Player.PlayerId;
            Class = Class.GetClassById(worldPlayer.Player.Classe, this);
            Health = worldPlayer.Player.Health;
            Name = worldPlayer.Player.Name;
            IsInCombat = worldPlayer.Player.IsInCombat;
            X = worldPlayer.PositionX;
            Y = worldPlayer.PositionY;
            Facing = worldPlayer.Facing;
            LastLevel = worldPlayer.CurrentLevelLevelId;
            InitializeClass();
            Health = worldPlayer.Player.Health;
            GetComponent<ComponentHealth>().Value = Health;
        }

        public int Attaquer(Entity ennemi)
        {
            int dmg = Class.Attaquer(this.HoldedItem());

            //Attaquer l'ennemi
            ennemi.GetComponent<ComponentHealth>().Hurt(this, dmg, false);

            Rise.Sound.Play(Resources.PoolSwings);

            return dmg;
        }
    }
}