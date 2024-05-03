using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    public void back() {
        SceneManager.LoadScene("MainMenuSceneFixed");
    }

    public void loadGameMasterMenu() {
        SceneManager.LoadScene("GameMasterMenuScene");
    }

    public void loadOptionsMenu() {
        SceneManager.LoadScene("OptionsMenuScene");
    }

    public void changeOption(int index)
    {
         GameObject.Find("GameController").GetComponent<GameSettings>().SetDifficulty(index);
    }
}
