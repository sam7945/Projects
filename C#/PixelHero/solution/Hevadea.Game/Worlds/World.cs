using Hevadea.Entities;
using Hevadea.Framework;
using Hevadea.Models;
using Hevadea.Storage;
using Hevadea.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Hevadea.Worlds
{
    public class World
    {
        public int WorldId { get; set; }
        public GameState GameState;
        public ICollection<Level> Levels { get; set; } = new List<Level>();
        [NotMapped]
        public DayNightCycle DayNightCycle { get; }
        [NotMapped]
        public string PlayerSpawnLevel { get; set; } = "overworld";
        public int PlayerSpawnLevelId { get; set; }
        public string Name { get; set; }
        public ICollection<WorldPlayer> WorldPlayers { get; set; }


        public World()
        {
            DayNightCycle = new DayNightCycle(
                    new DayStage("Day", 600, Color.White),
                    new DayStage("Dusk0", 30, new Color(187, 104, 50)),
                    new DayStage("Dusk1", 30, new Color(125, 54, 48)),
                    new DayStage("Dusk2", 30, new Color(75, 32, 32)),
                    new DayStage("Dusk3", 30, new Color(25, 26, 25)),
                    new DayStage("Night", 600, Color.Blue * 0.1f),
                    new DayStage("Dawn0", 30, new Color(25, 26, 25)),
                    new DayStage("Dawn1", 30, new Color(75, 32, 32)),
                    new DayStage("Dawn2", 30, new Color(125, 54, 48)),
                    new DayStage("Dawn3", 30, new Color(187, 104, 50))
                )
                {Transition = 30};
        }

        public static World Load(WorldStorage store)
        {
            var world = new World();

            world.DayNightCycle.Time = store.Time;
            world.PlayerSpawnLevel = store.PlayerSpawnLevel;
            
            return world;
        }

        public WorldStorage Save()
        {
            var worldStorage = new WorldStorage();

            worldStorage.Time = DayNightCycle.Time;
            worldStorage.PlayerSpawnLevel = PlayerSpawnLevel;

            foreach (var l in Levels) worldStorage.Levels.Add(l.Name);

            return worldStorage;
        }

        public void SpawnPlayer(Player player)
        {
            var level = GetLevel(PlayerSpawnLevel);
            level.AddEntityAt(player, new Coordinates(level.Width / 2, level.Height / 2));
        }

        public Level GetLevel(string name)
        {
            return Levels.FirstOrDefault(l => l.Name == name);
        }

        public Level GetLevel(int id)
        {
            return Levels.FirstOrDefault(l => l.LevelId == id);
        }

        public void AddLevel(Level level)
        {
            if (GetLevel(level.LevelId) == null) Levels.Add(level);
        }

        public void Initialize(GameState gameState)
        {
            GameState = gameState;
            foreach (var l in Levels) l.Initialize(this, gameState);
        }
    }
}