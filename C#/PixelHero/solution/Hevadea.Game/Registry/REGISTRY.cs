using Hevadea.Database;
using Hevadea.Framework;
using System.Threading;

namespace Hevadea.Registry
{
    public static class REGISTRY
    {
        public static DataContext Context { get; private set; }
        public static Mutex Mutex { get; private set; }
        public static void Initialize()
        {
            Context = new DataContext();
            Mutex = new Mutex();
            Context.SaveChanges();
            Logger.Log("Initializing game registry.");

            TILES.Initialize();
            ENTITIES.Initialize();
            ITEMS.Initialize();
            RECIPIES.InitializeHandCraftedRecipe();
            LEVELS.Initialize();
            GENERATOR.Initialize();
            TILES.AttachRender();
            TILES.AttachTags();
            ITEMS.AttachTags();

            SYSTEMS.Initialize();
        }
    }
}