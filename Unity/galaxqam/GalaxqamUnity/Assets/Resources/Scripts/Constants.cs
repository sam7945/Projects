using System;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

    # region "GameScenes"
    public const string SCENE_MAIN_MENU = "MainMenuScene";
    public const string SCENE_MAIN_MENU_FIXED = "MainMenuSceneFixed";
    public const string SCENE_OPTIONS_MENU = "OptionsMenuScene";
    public const string SCENE_CREDITS_MENU_SCENE = "CreditsMenuScene";
    public const string SCENE_GAME_MASTER_MENU_SCENE = "GameMasterMenuScene";
    public const string SCENE_CLASSIC_GAME = "ClassicGameScene";
    public const string SCENE_MUSIC_MAIN_MENU = "MusicMainMenu";
    public const string SCENE_GAME_OVER = "GameOver";
    public const string SCENE_ENNEMY_FORMATION_CONTROLLER = "EnemiesFormationController";
    # endregion

    # region "Game environment"
    public const float VISUAL_SIDE_LIMITS = 110F;
    #endregion

    #region "Game Difficulty"

    public enum Difficulty { FACILE, NORMAL, DIFFICILE };

    #endregion

    #region "Formation Creation Type"

    public enum Creation { RANDOM, FILE };

    public const string formationFileName = "formation";
    public const string easyFormationFileName = "easy_Formation";
    public const string difficultFormationFileName = "difficult_Formation";

    #endregion

    #region " Difficulty life modifier"
    public const float DIFFICULTY_EASY_LIFE_MODIFIER = 0.75f;
    public const float DIFFICULTY_NORMAL_LIFE_MODIFIER = 1.0f;
    public const float DIFFICULTY_HARD_LIFE_MODIFIER = 2.0f;

    #endregion

    #region "Formation mouvements"
    public const float downMovementDuration = 0.2f;
    public const float downMovementDistance = 1f;
    public const float downMovementEveryX_second = 10f;
    public const float delay = 5.0f;
    #endregion

    #region "Mouvement attaque"
    public const float attackSpeed = 15.0f;
    public const float specialMovementSpeed = 10.0f;
    public const float probabilitySpecialMovement = 0.3f;
    #endregion
    #region "Booster"

    // Temps de base qu'un booster (shield, weapon, speed) est actif
    public const float SPACE_SHIP_BOOSTER_TIME_BASE = 5.0F;
    public const float DIFFICULTY_EASY_BOOSTER_TIME_MODIFIER = 1.5F;
    public const float DIFFICULTY_NORMAL_BOOSTER_TIME_MODIFIER = 1.0F;
    public const float DIFFICULTY_HARD_BOOSTER_TIME_MODIFIER = 0.5F;
    // Nombre de points de vie ajoutés lors de la récupération du power-up correspondant
    public const float POINTS_DE_VIE_A_AJOUTER = 30f;

    #endregion

    #region "Movement Speed"

    public const float SPACE_SHIP_MOVEMENT_BASE = 40.0f;

    public const float DIFFICULTY_EASY_SPACE_SHIP_MOVEMENT_MODIFIER = 1.5F;
    public const float DIFFICULTY_NORMAL_SPACE_SHIP_MOVEMENT_MODIFIER = 1.0F;
    public const float DIFFICULTY_HARD_SPACE_SHIP_MOVEMENT_MODIFIER = 0.8F;

    public const float PLAYER_SHIP_MOVEMENT_MODIFIER_NORMAL = 1.0f;
    public const float PLAYER_SHIP_MOVEMENT_MODIFIER_FAST = PLAYER_SHIP_MOVEMENT_MODIFIER_NORMAL * 2;
    public const float PLAYER_SHIP_MOVEMENT_MODIFIER_SLOW = 0.8f;

    #endregion


    #region "Names"
    public const string SPACESHIP_NAME = "SpaceShip";
    public const string WEAPON_ENERGY_HOLDER_NAME = "WeaponEnergyHolder";
    public const string WEAPON_EXPLOSION_HOLDER_NAME = "WeaponExplosionHolder";
    public const string WEAPON_SHORT_LASER_NAME = "WeaponShortLaser";
    public const string WEAPON_LONG_LASER_NAME = "WeaponLongLaser";
    public const string WEAPON_GAMMA_NAME = "WeaponGamma";
    public const string WEAPON_GRENADE_LAUNCHER_NAME = "WeaponGrenadeLauncher";
    public const string WEAPON_MACHINE_GUN_NAME = "WeaponMachineGun";
    public const string WEAPON_NUCLEAR_LAUNCHER_NAME = "WeaponNuclearLauncher";
    #endregion

    #region "Weapon Damage"

    public const float WEAPON_STANDARD_DAMAGE = 10f;
    public const float WEAPON_SHORT_LASER_DAMAGE = 25;
    public const float WEAPON_LONG_LASER = WEAPON_SHORT_LASER_DAMAGE * 2;
    public const float WEAPON_GAMMA = WEAPON_SHORT_LASER_DAMAGE * 3;
    public const float WEAPON_MACHINE_GUN = 30;
    public const float WEAPON_GRENADE_LAUNCHER = 40;
    public const float WEAPON_NUCLEAR_LAUNCHER = 100f; // with falloff
    #endregion


    #region "Weapon Identification"
    public static Dictionary<int, Type> WEAPONS = new Dictionary<int, Type>() {
        {WEAPON_SHORT_LASER_ID,typeof(ShortFire) },
        {WEAPON_LONG_LASER_ID,typeof(LongFire) },
        {WEAPON_GAMMA_ID,typeof(GammaFire) },
        {WEAPON_MACHINE_GUN_ID,typeof(MachineFire) },
        {WEAPON_GRENADE_LAUNCHER_ID,typeof(GrenadeFire) },
        {WEAPON_NUCLEAR_LAUNCHER_ID,typeof(NuclearFire) },

    };

    public const int WEAPON_SHORT_LASER_ID = 0;
    public const int WEAPON_LONG_LASER_ID = 1;
    public const int WEAPON_GAMMA_ID = 2;
    public const int WEAPON_MACHINE_GUN_ID = 3;
    public const int WEAPON_GRENADE_LAUNCHER_ID = 4;
    public const int WEAPON_NUCLEAR_LAUNCHER_ID = 5; // with falloff
    #endregion



    #region "Life points"

    public const float PLAYER_SHIP_LIFE_POINTS = 500f;
    public const float ENEMY1_LIFE_POINT = 50f;
    public const float ENEMY2_LIFE_POINT = 60f;
    public const float ENEMY3_LIFE_POINT = 60f;
    public const float ENEMY4_LIFE_POINT = 60f;
    public const float ENEMY6_LIFE_POINT = 100f;
    public const float BOSS_LIFE_POINT = 2500f;

    #endregion

    #region "Sons"

    public const float VOLUME_LEVEL_MIN = 0f;
    public const float VOLUME_LEVEL_MAX = 1f;

    #endregion

    #region "Sons noms"
    public const string EXPLOSION_VAISSEAU = "ExplosionVaisseau";
    public const string EXPLOSION = "Explosion";
    public const string GAME_OVER = "GameOverLoser";



    #endregion


    public static string TextualWeaponId(int WEAPON_ID)
    {
        string result;
        switch (WEAPON_ID)
        {
            case WEAPON_SHORT_LASER_ID:
                result = WEAPON_SHORT_LASER_NAME;
                break;
            case WEAPON_LONG_LASER_ID:
                result = WEAPON_LONG_LASER_NAME;
                break;
            case WEAPON_GAMMA_ID:
                result = WEAPON_GAMMA_NAME;
                break;
            case WEAPON_MACHINE_GUN_ID:
                result = WEAPON_MACHINE_GUN_NAME;
                break;
            case WEAPON_GRENADE_LAUNCHER_ID:
                result = WEAPON_GRENADE_LAUNCHER_NAME;
                break;
            case WEAPON_NUCLEAR_LAUNCHER_ID:
                result = WEAPON_NUCLEAR_LAUNCHER_NAME;
                break;
            default:
                result = "error: bad weapon name";
                break;
        }

        return result;
    }


}
