using Hevadea.Craftings;
using System.Collections.Generic;

namespace Hevadea.Registry
{
    public static class RECIPIES
    {
        public static readonly List<Recipe> BenchCrafted = new List<Recipe>();
        public static readonly List<Recipe> HandCrafted = new List<Recipe>();
        public static readonly List<Recipe> FurnaceCrafted = new List<Recipe>();

        public static void InitializeHandCraftedRecipe()
        {
            //Bench Crafted
            BenchCrafted.Add(new Recipe(ITEMS.CHEST, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 8));
            BenchCrafted.Add(new Recipe(ITEMS.FURNACE, 1, new RecipeCost(ITEMS.STONE, 8)));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_FLOOR, 1, new RecipeCost(ITEMS.MATERIAL_WOOD_PLANK, 2)));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_WALL, 1, new RecipeCost(ITEMS.MATERIAL_WOOD_PLANK, 4)));
            BenchCrafted.Add(new Recipe(ITEMS.LAMP, 1, new RecipeCost(ITEMS.TORCH, 1)).AddCost(ITEMS.IRON_ORE, 4));
        
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_STAFF, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_STAFF, 1).AddCost(ITEMS.GOLD_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_STAFF, 1).AddCost(ITEMS.IRON_ORE, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_STAFF, 1).AddCost(ITEMS.STONE, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));

            BenchCrafted.Add(new Recipe(ITEMS.WOOD_BOW, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_BOW, 1).AddCost(ITEMS.GOLD_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_BOW, 1).AddCost(ITEMS.IRON_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_BOW, 1).AddCost(ITEMS.STONE, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));


            BenchCrafted.Add(new Recipe(ITEMS.GOLD_AXE, 1).AddCost(ITEMS.GOLD_INGOT, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_HOE, 1).AddCost(ITEMS.GOLD_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_PICKAXE, 1).AddCost(ITEMS.GOLD_INGOT, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_SHOVEL, 1).AddCost(ITEMS.GOLD_INGOT, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.GOLD_SWORD, 1).AddCost(ITEMS.GOLD_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_AXE, 1).AddCost(ITEMS.IRON_INGOT, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_HOE, 1).AddCost(ITEMS.IRON_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_PICKAXE, 1).AddCost(ITEMS.IRON_INGOT, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_SHOVEL, 1).AddCost(ITEMS.IRON_INGOT, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.IRON_SWORD, 1).AddCost(ITEMS.IRON_INGOT, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_AXE, 1).AddCost(ITEMS.STONE, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_HOE, 1).AddCost(ITEMS.STONE, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_PICKAXE, 1).AddCost(ITEMS.STONE, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_SHOVEL, 1).AddCost(ITEMS.STONE, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.STONE_SWORD, 1).AddCost(ITEMS.STONE, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));

            BenchCrafted.Add(new Recipe(ITEMS.WOOD_SWORD, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_HOE, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 2).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_PICKAXE, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_SHOVEL, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));
            BenchCrafted.Add(new Recipe(ITEMS.WOOD_AXE, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 3).AddCost(ITEMS.MATERIAL_WOOD_STICK, 2));           
            BenchCrafted.Add(new Recipe(ITEMS.TNT, 4).AddCost(ITEMS.STONE, 4).AddCost(ITEMS.COAL, 2).AddCost(ITEMS.LIGHTER, 1));
            //HandCrafted
            HandCrafted.Add(new Recipe(ITEMS.CRAFTING_BENCH, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 4).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 4));
            HandCrafted.Add(new Recipe(ITEMS.LIGHTER, 1).AddCost(ITEMS.IRON_ORE, 1).AddCost(ITEMS.STONE, 1));
            HandCrafted.Add(new Recipe(ITEMS.TORCH, 4).AddCost(ITEMS.COAL, 1).AddCost(ITEMS.MATERIAL_WOOD_STICK, 1));
            HandCrafted.Add(new Recipe(ITEMS.MATERIAL_WOOD_PLANK, 2).AddCost(ITEMS.MATERIAL_WOOD_LOG, 1));
            HandCrafted.Add(new Recipe(ITEMS.MATERIAL_WOOD_STICK, 4).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 1));
            HandCrafted.Add(new Recipe(ITEMS.BOAT, 1).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 3));

            //FurnaceCrafted
            FurnaceCrafted.Add(new Recipe(ITEMS.IRON_INGOT, 1).AddCost(ITEMS.IRON_ORE, 1).AddCost(ITEMS.COAL, 1));
            FurnaceCrafted.Add(new Recipe(ITEMS.GOLD_INGOT, 1).AddCost(ITEMS.GOLD_ORE, 1).AddCost(ITEMS.COAL, 1));
            FurnaceCrafted.Add(new Recipe(ITEMS.COAL, 4).AddCost(ITEMS.MATERIAL_WOOD_LOG, 10).AddCost(ITEMS.COAL, 1));
            FurnaceCrafted.Add(new Recipe(ITEMS.COAL, 2).AddCost(ITEMS.MATERIAL_WOOD_PLANK, 10).AddCost(ITEMS.COAL, 1));

        }
    }
}