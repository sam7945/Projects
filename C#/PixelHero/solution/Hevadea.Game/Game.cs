using System;
using System.IO;
using Hevadea.Entities;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Threading;
using Hevadea.Loading;
using Hevadea.Models;
using Hevadea.Registry;
using Hevadea.Scenes;
using Hevadea.Scenes.Menus;
using Hevadea.WorldGenerator;

namespace Hevadea
{
    public static class Game
    {
        public static readonly int Unit = 16;
        public static readonly string Title = "Pixel Hero";
        public static readonly string SubTitle = "\"Tales of the unknown\"";
        public static readonly string Version = "0.0.0";
        public static readonly int VersionNumber = 2;
        public static string Classe { get; private set; }

        public static string LastGameFile => Rise.Platform.GetStorageFolder().CombineWith("/LastGame");
        public static string ConfigFile => Rise.Platform.GetStorageFolder().CombineWith("/Config.json");
        public static string ServersFile => Rise.Platform.GetStorageFolder().CombineWith("/Servers.json");
        public static string SavesFolder => Rise.Platform.GetStorageFolder().CombineWith("/Saves/");
        public static string ModsFolder => Rise.Platform.GetStorageFolder().CombineWith("/Mods/");
        public static string PlayersFolder => Rise.Platform.GetStorageFolder().CombineWith("/Players/");

        public static WorldPlayer WorldPlayer { get; set; } = null;

        public static void Initialize()
        {
            Directory.CreateDirectory(SavesFolder);
            Directory.CreateDirectory(ModsFolder);
            Directory.CreateDirectory(PlayersFolder);

            Resources.Load();

            REGISTRY.Initialize();

            Rise.Ui.DefaultFont = Resources.FontRomulus;
            Rise.Ui.DebugFont = Resources.FontHack;
        }

        public static void SetLastGame(string path)
        {
            try
            {
                File.WriteAllText(LastGameFile, path);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        public static string GetLastGame()
        {
            return File.Exists(LastGameFile)
                ? File.ReadAllText(LastGameFile)
                : null;
        }

        public static void GoToTileScreen()
        {
            Rise.Scene.Switch(new SceneTitleScreen());
        }

        public static void GoToMainMenu()
        {
            Game.WorldPlayer = null;
            Rise.Scene.Switch(new MenuMain());
        }
        public static void GoToMenuOnline()
        {
            Rise.Scene.Switch(new MenuConnection());
        }
        public static void GoToMenuOffline()
        {
            Rise.Scene.Switch(new MenuOffline());
        }
        public static void GoToMenuRegister(string username, string password)
        {
            Rise.Scene.Switch(new MenuRegister(username, password));
        }
        public static void GoToMenuLogin(Account user)
        {
            Rise.Scene.Switch(new MenuLogIn(user));
        }
        public static void GoToMenuConnection()
        {
            Rise.Scene.Switch(new MenuConnection());
        }

        public static void Play(string gamePath)
        {
            var job = Jobs.LoadWorld.SetArguments(new Jobs.WorldLoadInfo(gamePath));

            job.Finish += (sender, e)
                => Rise.Scene.Switch(new SceneGameplay((GameState)((Job)sender).Result));

            Rise.Scene.Switch(new LoadingScene(job));
        }


        public static void New(string name, string seedString, Generator generator, bool online = false, string classeChoisie=null)
        {
            if (!int.TryParse(seedString, out int seed)) seed = seedString.GetHashCode();

            New(name, seed, generator, online, classeChoisie);
        }

        public static void New(string name, int seed, Generator generator, bool online, string classeChoisie)
        {
            Classe = classeChoisie;
            var job = online ? Jobs.GenerateWorldOnline : Jobs.GenerateWorld;
            job.SetArguments(new Jobs.WorldGeneratorInfo(SavesFolder.CombineWith(name), seed,
                generator, name));

            job.Finish += (sender, e) =>
            {
                var gameState = (GameState)((Job)sender).Result;
                ((Job)sender).Report("Initializing...");
                gameState.Initialize();
                Rise.Scene.Switch(new SceneGameplay(gameState));
            };
            Rise.Scene.Switch(new LoadingScene(job));
        }
    }
}