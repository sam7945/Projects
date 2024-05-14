using Hevadea.Entities.Blueprints;
using Hevadea.Items;
using Hevadea.Items.Tags;
using System.Collections.Generic;
using Hevadea.Entities.Components;

namespace Hevadea.Registry
{
    public static class ITEMS
    {
        public static readonly List<Item> ById = new List<Item>();
        public static readonly Dictionary<string, Item> ByName = new Dictionary<string, Item>();

        public static Item BELT;
        public static Item BOAT;
        public static Item CHEST;
        public static Item COAL;
        public static Item CRAFTING_BENCH;
        public static Item FURNACE;
        public static Item GRASS_PATCH;
        public static Item IRON_ORE;
        public static Item LIGHTER;
        public static Item PINE_CONE;
        public static Item RAW_FISH;
        public static Item SAND;
        public static Item STONE;
        public static Item TNT;
        public static Item TORCH;
        public static Item LAMP;
        public static Item WOOD_FLOOR;
        public static Item MATERIAL_WOOD_LOG;
        public static Item MATERIAL_WOOD_PLANK;
        public static Item MATERIAL_WOOD_STICK;
        public static Item WOOD_WALL;

        public static Item IRON_INGOT;
        public static Item GOLD_INGOT;
        public static Item GOLD_ORE;

        public static Item WOOD_AXE;
        public static Item WOOD_SWORD;
        public static Item WOOD_PICKAXE;
        public static Item WOOD_SHOVEL;
        public static Item WOOD_HOE;

        public static Item WOOD_STAFF;
        public static Item STONE_STAFF;
        public static Item GOLD_STAFF;
        public static Item IRON_STAFF;

        public static Item WOOD_BOW;
        public static Item STONE_BOW;
        public static Item GOLD_BOW;
        public static Item IRON_BOW;

        public static Item GOLD_AXE;
        public static Item IRON_AXE;
        public static Item STONE_AXE;

        public static Item GOLD_HOE;
        public static Item IRON_HOE;
        public static Item STONE_HOE;

        public static Item GOLD_PICKAXE;
        public static Item IRON_PICKAXE;
        public static Item STONE_PICKAXE;

        public static Item GOLD_SHOVEL;
        public static Item IRON_SHOVEL;
        public static Item STONE_SHOVEL;

        public static Item GOLD_SWORD;
        public static Item IRON_SWORD;
        public static Item STONE_SWORD;

        public static void Initialize()
        {
            BELT = new Item("Belt", Resources.Sprites["item/belt"]);
            BOAT = new Item("Boat", Resources.Sprites["item/boat"]);
            CHEST = new Item("Chest", Resources.Sprites["item/chest"]);
            CRAFTING_BENCH = new Item("Bench", Resources.Sprites["item/bench"]);
            FURNACE = new Item("Furnace", Resources.Sprites["item/furnace"]);

            GOLD_INGOT = new Item("Gold Ingot", Resources.Sprites["item/gold_ingot"]);
            GOLD_ORE = new Item("Ore Gold", Resources.Sprites["item/ore_gold"]);
            IRON_INGOT = new Item("Iron Ingot", Resources.Sprites["item/iron_ingot"]);
            IRON_ORE = new Item("Ore Iron", Resources.Sprites["item/ore_iron"]);

            LIGHTER = new Item("Lighter", Resources.Sprites["item/lighter"]);
            GRASS_PATCH = new Item("Floor Grass", Resources.Sprites["item/floor_grass"]);
            COAL = new Item("Ore Coal", Resources.Sprites["item/ore_coal"]);
            PINE_CONE = new Item("Seed Pine", Resources.Sprites["item/seed_pine"]);
            RAW_FISH = new Item("Raw Fish", Resources.Sprites["item/raw_fish"]);
            SAND = new Item("Floor Sand", Resources.Sprites["item/floor_sand"]);
            TNT = new Item("Tnt", Resources.Sprites["item/tnt"]);
            TORCH = new Item("Torch", Resources.Sprites["item/torch"]);
            LAMP = new Item("Lamp", Resources.Sprites["entity/lamp"]);

            STONE = new Item("Stone", Resources.Sprites["item/material_stone"]);

            MATERIAL_WOOD_LOG = new Item("Wood Log", Resources.Sprites["item/material_wood_log"]);
            MATERIAL_WOOD_PLANK = new Item("Wood Plank", Resources.Sprites["item/material_wood_plank"]);
            MATERIAL_WOOD_STICK = new Item("Wood Stick", Resources.Sprites["item/material_wood_stick"]);

            WOOD_FLOOR = new Item("Floor Wood", Resources.Sprites["item/wood_floor"]);
            WOOD_WALL = new Item("Wall Wood", Resources.Sprites["item/wall_wood_plank"]);
            WOOD_AXE = new Item("Axe Wood", Resources.Sprites["item/axe_wood"]);
            WOOD_PICKAXE = new Item("Pickaxe Wood", Resources.Sprites["item/pickaxe_wood"]);
            WOOD_SHOVEL = new Item("Shovel Wood", Resources.Sprites["item/shovel_wood"]);
            WOOD_SWORD = new Item("Sword Wood", Resources.Sprites["item/sword_wood"]);
            WOOD_HOE = new Item("Hoe Wood", Resources.Sprites["item/hoe_wood"]);

            WOOD_STAFF = new Item("Wood Staff", Resources.Sprites["item/staff"]);
            STONE_STAFF = new Item("Stone Staff", Resources.Sprites["item/staff_stone"]);
            GOLD_STAFF = new Item("Gold Staff", Resources.Sprites["item/staff_gold"]);
            IRON_STAFF = new Item("Iron Staff", Resources.Sprites["item/staff_iron"]);



            WOOD_BOW = new Item("Wood Bow", Resources.Sprites["item/bow"]);
            STONE_BOW = new Item("Stone Bow", Resources.Sprites["item/bow_stone"]);
            GOLD_BOW = new Item("Gold Bow", Resources.Sprites["item/bow_gold"]);
            IRON_BOW = new Item("Iron Bow", Resources.Sprites["item/bow_iron"]);





            GOLD_AXE = new Item("Gold Axe", Resources.Sprites["item/axe_gold"]);
            IRON_AXE = new Item("Iron Axe", Resources.Sprites["item/axe_iron"]);
            STONE_AXE = new Item("Stone Axe", Resources.Sprites["item/axe_stone"]);

            GOLD_HOE = new Item("Gold Hoe", Resources.Sprites["item/hoe_gold"]);
            IRON_HOE = new Item("Iron Hoe", Resources.Sprites["item/hoe_iron"]);
            STONE_HOE = new Item("Stone Hoe", Resources.Sprites["item/hoe_stone"]);

            GOLD_PICKAXE = new Item("Gold Pickaxe", Resources.Sprites["item/pickaxe_gold"]);
            IRON_PICKAXE = new Item("Iron Pickaxe", Resources.Sprites["item/pickaxe_iron"]);
            STONE_PICKAXE = new Item("Stone Pickaxe", Resources.Sprites["item/pickaxe_stone"]);

            GOLD_SHOVEL = new Item("Gold Shovel", Resources.Sprites["item/shovel_gold"]);
            IRON_SHOVEL = new Item("Iron Shovel", Resources.Sprites["item/shovel_iron"]);
            STONE_SHOVEL = new Item("Stone Shovel", Resources.Sprites["item/shovel_stone"]);

            GOLD_SWORD = new Item("Gold Sword", Resources.Sprites["item/sword_gold"]);
            IRON_SWORD = new Item("Iron Sword", Resources.Sprites["item/sword_iron"]);
            STONE_SWORD = new Item("Stone Sword", Resources.Sprites["item/sword_stone"]);




        }

        public static void AttachTags()
        {
            CHEST.AddTag(new PlaceEntity(ENTITIES.CHEST));
            CRAFTING_BENCH.AddTag(new PlaceEntity(ENTITIES.CRAFTING_BENCH));
            FURNACE.AddTag(new PlaceEntity(ENTITIES.FURNACE));
            TORCH.AddTag(new PlaceEntity(ENTITIES.TORCH));
            LAMP.AddTag(new PlaceEntity(ENTITIES.LAMP));

            WOOD_FLOOR.AddTag(new PlaceTile(TILES.WOOD_FLOOR) { CanBePlaceOn = { TILES.DIRT } });
            WOOD_WALL.AddTag(new PlaceTile(TILES.WOOD_WALL) { CanBePlaceOn = { TILES.DIRT } });
            GRASS_PATCH.AddTag(new PlaceTile(TILES.GRASS) { CanBePlaceOn = { TILES.DIRT } });
            SAND.AddTag(new PlaceTile(TILES.SAND) { CanBePlaceOn = { TILES.DIRT } });

            BOAT.AddTag(new PlaceEntity(ENTITIES.BOAT));
            BELT.AddTag(new PlaceEntity(ENTITIES.BELT));
            TNT.AddTag(new PlaceEntity(ENTITIES.TNT));
            LIGHTER.AddTag(new ActionItemTag()
            {
                Action = (user, pos) =>
                {
                    foreach (var e in user.Level.QueryEntity(pos))
                    {
                        e.GetComponent<ComponentFlammable>()?.SetInFire();
                    }
                }
            });

            WOOD_AXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_TREE, 2f),
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.3f)
                }
            });

            WOOD_SWORD.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.5f)
                }
            });
            WOOD_STAFF.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.2f)
                }
            });
            STONE_STAFF.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.3f)
                }
            });
            GOLD_STAFF.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.5f)
                }
            });
            IRON_STAFF.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.8f)
                }
            });



            WOOD_BOW.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.2f)
                }
            });

            STONE_BOW.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.3f)
                }
            });
            GOLD_BOW.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.5f)
                }
            });
            IRON_BOW.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.8f)
                }
            });

            GOLD_SWORD.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.7f)
                }
            });
            IRON_SWORD.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE,2.0f)
                }
            });
            STONE_SWORD.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.6f)
                }
            });

            GOLD_AXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_TREE, 3f),
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.7f)
                }
            });
            IRON_AXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_TREE, 4f),
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 2.0f)
                }
            });
            STONE_AXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_TREE, 2.5f),
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.5f)
                }
            });
            GOLD_PICKAXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                     new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.5f)
                },
                PerTileDamages = 
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_ROCK, 2.5f)
                }
            });
            IRON_PICKAXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.7f)
                },
                PerTileDamages =
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_ROCK, 3.0f)
                }
            });
            STONE_PICKAXE.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.6f)
                },
                PerTileDamages =
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_ROCK, 2.7f)
                }
            });
            GOLD_SHOVEL.AddTag(new DamageTag() 
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.6f)
                },
                PerTileDamages =
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_SOIL, 2.5f)
                }
            });
            IRON_SHOVEL.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.6f)
                },
                PerTileDamages =
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_SOIL, 3.0f)
                }
            });
            STONE_SHOVEL.AddTag(new DamageTag()
            {
                PerEntityDamage =
                {
                    new GroupeDamage<EntityBlueprint>(ENTITIES.GROUPE_CREATURE, 1.6f)
                },
                PerTileDamages =
                {
                    new GroupeDamage<Tiles.Tile>(TILES.GROUPE_SOIL, 2.7f)
                }
            });
        }
    }
}