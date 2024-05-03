using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class <c>GameSettings</c>
/// Patron de conception singleton pour avoir un objet central permanent qui conserve les donn�es du jeu et qui facilite la communications entre les objets du jeu.
/// Mettre ce prefab sur toutes les sc�nes pour lancer le jeu de n'importe quelle sc�ne, ou passer d'une sc�ne � l'autre pour faciliter le d�veloppement.
/// Ainsi, toute sc�ne du jeu sera � jouable � sans avoir � lancer l'application depuis le d�but.

/// </summary>
public class GameSettings : MonoBehaviour
{
    public Constants.Difficulty chosenDifficulty;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private static GameSettings instance = null;
    public static GameSettings Instance => instance;

    public static float _soundEffectsVolume = Constants.VOLUME_LEVEL_MAX / 2;
    public static float _musicVolume = Constants.VOLUME_LEVEL_MAX / 2;


    public static float _difficultySpaceShipMovementModifier =
        Constants.DIFFICULTY_NORMAL_SPACE_SHIP_MOVEMENT_MODIFIER;

    public static float _difficultyLifeModifier =
        Constants.DIFFICULTY_NORMAL_LIFE_MODIFIER;

    public static float _difficultyBoosterModifier =
        Constants.DIFFICULTY_NORMAL_BOOSTER_TIME_MODIFIER;

    public void SetDifficulty(int Option) {
        chosenDifficulty = (Constants.Difficulty)Option;
        _nbRow = 4.0f;
        if (chosenDifficulty == Constants.Difficulty.FACILE)
        {
            switchDifficultyToEasy();
            _nbRow += _ModifRowEasy;
            Debug.Log("EASY");
        }
        else if (chosenDifficulty == Constants.Difficulty.NORMAL)
        {
            switchDifficultyToNormal();
            Debug.Log("NORMAL");
        }
        else if (chosenDifficulty == Constants.Difficulty.DIFFICILE)
        {
            switchDifficultyToHard();
            _formationSpeed += _formationSpeedModifHard;
            _nbRow += _ModifRowHard;
            Debug.Log("HARD");
        }
        else
        {
            switchDifficultyToEasy();

        }
    }


    #region "Vitesse de deplacement du vaisseau du joueur"
    static public float PlayerShipSpeed
    {
        get
        {
            return (Constants.SPACE_SHIP_MOVEMENT_BASE * _difficultySpaceShipMovementModifier);
        }

        set
        {
            /// Le vaisseau du joueur se deplace � vitesse normale, � moins d'avoir capturer un powerup VITESSE (issue #85).
            /// Pendant 10 secondes, le powerup double la vitesse du vaisseau du joueur.
            if (value < 0 || value > 2)
                throw new ArgumentOutOfRangeException(nameof(value), "Le facteur de modification de la vitesse du vaisseau doit �tre entre 0 et 2.");

            _difficultySpaceShipMovementModifier = value;
        }
    }
    #endregion

    /* TODO Implementer comment le niveau de difficulte affecte le jeu */
    #region "Niveaux de difficultes issue #63"

    static void switchDifficultyToEasy()
    {
        _difficultyLifeModifier = Constants.DIFFICULTY_EASY_LIFE_MODIFIER;
    }

    static void switchDifficultyToNormal()
    {
        _difficultyLifeModifier = Constants.DIFFICULTY_NORMAL_LIFE_MODIFIER;
    }

    static void switchDifficultyToHard()
    {
        _difficultyLifeModifier = Constants.DIFFICULTY_HARD_LIFE_MODIFIER;
    }
    #endregion

    #region "Movement Speed"

    // Ok, ici c'est une question de comment implémenter le tout. Si cette
    // approche est valide, j'y vois plusieurs problèmes.
    // Dans le jeu, une fois que le jeu est démarré, plusieur check seront
    // obligatoire...
    //
    // À moins que j'ai mal compris ce que vous voullez faire ici...
    //
    // Aussi, comme ce sont des constantes, nous pouvons les mettres statics
    // pour qu'ils soient accessible sans instanciation de la classe...
    public const float MOVEMENT_SPEED_SLOW = 8.0f;

    public const float MOVEMENT_SPEED_NORMAL = 10.0f;
    public const float MOVEMENT_SPEED_FAST = 12.0f;

    // voici ce que je propose pour éviter ces checks...
    public const float SPACE_SHIP_MOVEMENT_BASE = 8.0f;

    public const float SPACE_SHIP_MOVEMENT_MODIFIER_SLOW = 0.8f;
    public const float SPACE_SHIP_MOVEMENT_MODIFIER_NORMAL = 1.0f;
    public const float SPACE_SHIP_MOVEMENT_MODIFIER_FAST = 1.2f;

    ///////////////////////////////////////////////////////
    // Grosso modo, ce script est la sources des données "hard-codé" que
    // nous allons fixé arbitrairmenent qui servirons à un autre script
    // d'initialisation en fonction du niveau de difficulté choisi.
    //
    // Donc, dans le script d'initialisation cela pourrait être semblable à
    // cela:
    //
    // Ceci pourrait être utilisé à l'initilisation des valeurs utilisées
    // pour la partie en cours par le biais de variables, au début.
    //
    // DANS UN AUTRE SCRIPT D'INITIALISATION QUI SE SERT DE "GAME_SETTING"
    // et ensuite, le script d'initialisation fournis les valeurs sur
    // demande par le biais de getters.
    static public float GetBoosterTime() {
        return Constants.SPACE_SHIP_BOOSTER_TIME_BASE * _difficultyBoosterModifier;
    }

    static public float GetVisualSideLimit() {
        return Constants.VISUAL_SIDE_LIMITS;
    }
    #endregion

    #region "Options : reglage des effets sonores #73"
    static public float SoundEffectVolume
    {
        get
        {
            return _soundEffectsVolume;
        }

        set
        {
            if (value < Constants.VOLUME_LEVEL_MIN)
                _soundEffectsVolume = Constants.VOLUME_LEVEL_MIN;
            else if (value > Constants.VOLUME_LEVEL_MAX)
                _soundEffectsVolume = Constants.VOLUME_LEVEL_MAX;
            else
                _soundEffectsVolume = value;
        }
    }
    #endregion

    #region "Options : reglage de la musique #73"
    static public float MusicEffectVolume
    {
        get
        {
            return _musicVolume;
        }

        set
        {
            if (value < Constants.VOLUME_LEVEL_MIN)
                _musicVolume = Constants.VOLUME_LEVEL_MIN;
            else if (value > Constants.VOLUME_LEVEL_MAX)
                _musicVolume = Constants.VOLUME_LEVEL_MAX;
            else
                _musicVolume = value;
        }
    }
    #endregion
    #region "Formation Enemy"

    public static float _formationSpeed = 15.0f;
    public static float _formationSpeedModifHard = 3.0f;

    public static float _actualMaxPerRow = 25.0f;
    public static float _actualMinPerRow = 2.0f;
    public static float _actualMaxPerRowHard = 30.0f;
    public static float _xSpacing = 15.0f;
    public static float _ySpacing = 15.0f;
    public static float _nbRow = 4.0f;
    public static float _ModifRowEasy = -2.0f;
    public static float _ModifRowHard = 2.0f;
    public static float _ajustPositionY = 45.0f;
    public static float _startPositionY = _ajustPositionY + (_nbRow * _ySpacing);


    public static Dictionary<EnemyType, float> enemyProbabilities =  new Dictionary<EnemyType, float>()
        {
            { EnemyType.Enemy1, 0.2f },
            { EnemyType.Enemy2, 0.2f },
            { EnemyType.Enemy3, 0.1f },
            { EnemyType.Enemy4, 0.2f },
            { EnemyType.Enemy5, 0.1f },
            { EnemyType.Enemy6, 0.2f }
        };

    #endregion

}
