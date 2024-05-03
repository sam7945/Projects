using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MusicController musicController;
    void Start()
    {
        if (musicController != null) {
            musicController = GameObject.Find("GameController").
            GetComponent<MusicController>();
        }

    }
    public void StartNewGame() {
        /* if (musicController != null) */
        /* { */
        /*     musicController.PlayForScene(Constants.SCENE_ENNEMY_FORMATION_CONTROLLER); */
        /* } */
        SceneManager.LoadScene(Constants.SCENE_CLASSIC_GAME);
    }

    public void StartOptionsMenu() {
        SceneManager.LoadScene(Constants.SCENE_OPTIONS_MENU);
    }

    public void StartCreditsMenu() {
        SceneManager.LoadScene(Constants.SCENE_CREDITS_MENU_SCENE);
    }



    public void QuitGame() {
        Application.Quit();
    }
}
