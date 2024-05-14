using Hevadea.Framework;
using Hevadea.Framework.Threading;
using Hevadea.Registry;
using Hevadea.Worlds;
using System;
using System.Collections.Generic;

namespace Hevadea.WorldGenerator
{
    public class Generator
    {
        public List<LevelGenerator> LevelsGenerators { get; set; } = new List<LevelGenerator>();
        public List<WorldFeature> WorldFeatures { get; set; } = new List<WorldFeature>();
        public int Seed { get; set; } = 0;
        public int Size { get; set; } = 256;

        public Noise Noise { get; private set; }
        public Random Random { get; private set; }

        public World Generate(Job job)
        {
            var w = new World();
            Random = new Random(Seed);
            Noise = new Noise(Seed);

            foreach (var levelGenerator in LevelsGenerators)
            {
                job.Report($"Generating {levelGenerator.Name}...");

                var level = new Level(levelGenerator.Properties, Size, Size)
                    {LevelId = levelGenerator.Id, Name = levelGenerator.Name};

                for (var i = 0; i < levelGenerator.Features.Count; i++)
                {
                    var generatorFeature = levelGenerator.Features[i];
                    job.Report(i / (float) levelGenerator.Features.Count);
                    generatorFeature.Apply(this, levelGenerator, level);
                }

                w.AddLevel(level);
            }

            foreach (var feature in WorldFeatures) feature.Apply(this, w);

            return w;
        }
        public World GenerateOnline(Job job, string name)
        {
            var w = new World();
            w.Name = name;
            Random = new Random(Seed);
            Noise = new Noise(Seed);
            REGISTRY.Context.Worlds.Add(w);
            REGISTRY.Context.SaveChanges();
            foreach (var levelGenerator in LevelsGenerators)
            {
                job.Report($"Generating {levelGenerator.Name}...");

                var level = new Level(levelGenerator.Properties, Size, Size)
                { LevelId = levelGenerator.Id, Name = levelGenerator.Name };

                for (var i = 0; i < levelGenerator.Features.Count; i++)
                {
                    var generatorFeature = levelGenerator.Features[i];
                    job.Report(i / (float)levelGenerator.Features.Count);
                    generatorFeature.Apply(this, levelGenerator, level);
                }
                
                w.AddLevel(level);
                REGISTRY.Context.Levels.Add(level);
                REGISTRY.Context.SaveChanges();
                //TODO:Save to DB
                if (level.Name == "overworld")
                    w.PlayerSpawnLevelId = level.LevelId;
                REGISTRY.Context.SaveChanges();
            }

            foreach (var feature in WorldFeatures) feature.Apply(this, w);
            //TODO: Save World to DB
            return w;
        }
    }
}