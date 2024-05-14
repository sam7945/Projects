using Hevadea.Entities;
using Hevadea.Entities.Monsters;
using Hevadea.Entities.Blueprints;
using Hevadea.Items;
using System.Collections.Generic;

namespace Hevadea.Registry
{
    public static class ENTITIES
    {
        public static Groupe<EntityBlueprint> GROUPE_CREATURE;
        public static Groupe<EntityBlueprint> GROUPE_TREE;
        public static Groupe<EntityBlueprint> GROUPE_SAVE_EXCUDED;

        public static EntityBlueprint ITEM;

        public static EntityBlueprint BELT;
        public static EntityBlueprint BOAT;
        public static EntityBlueprint CHEST;
        public static EntityBlueprint CHIKEN;
        public static EntityBlueprint CRAFTING_BENCH;
        public static EntityBlueprint DOG;
        public static EntityBlueprint ANGRYDOG;
        public static EntityBlueprint FISH;
        public static EntityBlueprint FLOWER;
        public static EntityBlueprint FURNACE;
        public static EntityBlueprint GRASS;
        public static EntityBlueprint PLAYER;
        public static EntityBlueprint STAIRES;
        public static EntityBlueprint TNT;
        public static EntityBlueprint TORCH;
        public static EntityBlueprint LAMP;
        public static EntityBlueprint TREE;
        public static EntityBlueprint ZOMBIE;
        public static EntityBlueprint ZOMBIEBOSS;
        public static EntityBlueprint DARKFLOWER;
        public static EntityBlueprint DARKMUSHROOM;
        public static EntityBlueprint PAPAMUSH;
        public static EntityBlueprint KINGSHRUMP;
        public static EntityBlueprint DARKTREE;
        public static EntityBlueprint XPORB;
        public static bool ZBOSS = false;
        public static bool PMUSH = false;
        public static bool KSHRUMP = false;

        public static void Initialize()
        {
            ITEM = RegisterEntityBlueprint(new GenericEntityBlueprint<ItemEntity>("item"));

            BELT = RegisterEntityBlueprint(new GenericEntityBlueprint<Belt>("belt"));
            BOAT = RegisterEntityBlueprint(new GenericEntityBlueprint<Boat>("boat"));
            CHEST = RegisterEntityBlueprint(new GenericEntityBlueprint<Chest>("chest"));
            CHIKEN = RegisterEntityBlueprint(new GenericEntityBlueprint<Chicken>("chiken"));
            CRAFTING_BENCH = RegisterEntityBlueprint(new GenericEntityBlueprint<Bench>("crafting_bench"));
            DOG = RegisterEntityBlueprint(new GenericEntityBlueprint<Dog>("dog"));
            ANGRYDOG = RegisterEntityBlueprint(new GenericEntityBlueprint<AngryDog>("angry_dog"));
            FISH = RegisterEntityBlueprint(new GenericEntityBlueprint<Fish>("fish"));
            FLOWER = RegisterEntityBlueprint(new GenericEntityBlueprint<Flower>("flower"));
            FURNACE = RegisterEntityBlueprint(new GenericEntityBlueprint<Furnace>("furnace"));
            GRASS = RegisterEntityBlueprint(new GenericEntityBlueprint<Grass>("grass"));
            PLAYER = RegisterEntityBlueprint(new GenericEntityBlueprint<Player>("player"));
            STAIRES = RegisterEntityBlueprint(new GenericEntityBlueprint<Stairs>("staires"));
            TNT = RegisterEntityBlueprint(new GenericEntityBlueprint<TNT>("tnt"));
            TORCH = RegisterEntityBlueprint(new GenericEntityBlueprint<Torch>("torch"));
            LAMP = RegisterEntityBlueprint(new GenericEntityBlueprint<Lamp>("lamp"));
            TREE = RegisterEntityBlueprint(new GenericEntityBlueprint<EntityTree>("tree"));

            // Monsters
            ZOMBIE = RegisterEntityBlueprint(new GenericEntityBlueprint<Zombie>("zombie"));
            ZOMBIEBOSS = RegisterEntityBlueprint(new GenericEntityBlueprint<BigMamaZombie>("mama_zombie"));
            DARKFLOWER = RegisterEntityBlueprint(new GenericEntityBlueprint<DarkFlower>("dark_flower"));
            DARKMUSHROOM = RegisterEntityBlueprint(new GenericEntityBlueprint<DarkMushroom>("dark_mushroom"));
            PAPAMUSH = RegisterEntityBlueprint(new GenericEntityBlueprint<BigPapaMushroom>("papa_mushroom"));
            DARKTREE = RegisterEntityBlueprint(new GenericEntityBlueprint<DarkTree>("dark_tree"));
            KINGSHRUMP = RegisterEntityBlueprint(new GenericEntityBlueprint<KingShrump>("king_shrump"));


            XPORB = RegisterEntityBlueprint(new GenericEntityBlueprint<XpOrb>("xporb"));

            GROUPE_CREATURE = new Groupe<EntityBlueprint>("creature", CHIKEN, FISH, PLAYER, ZOMBIE, DARKFLOWER, DARKMUSHROOM, DARKTREE);
            GROUPE_TREE = new Groupe<EntityBlueprint>("tree", TREE);
            GROUPE_SAVE_EXCUDED = new Groupe<EntityBlueprint>("save_excluded", PLAYER);
        }

        public static Dictionary<string, EntityBlueprint>
            BlueprintLibrary = new Dictionary<string, EntityBlueprint>();

        public static EntityBlueprint RegisterEntityBlueprint(EntityBlueprint blueprint)
        {
            if (BlueprintLibrary.ContainsKey(blueprint.Name))
                BlueprintLibrary[blueprint.Name] = blueprint;
            else
                BlueprintLibrary.Add(blueprint.Name, blueprint);

            return blueprint;
        }

        public static Entity Construct(string name)
        {
            return BlueprintLibrary.ContainsKey(name) ? BlueprintLibrary[name].Construct() : null;
        }

        public static EntityBlueprint GetBlueprint(string name)
        {
            return BlueprintLibrary.ContainsKey(name) ? BlueprintLibrary[name] : null;
        }
    }
}