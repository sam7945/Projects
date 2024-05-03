using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle_menu : MonoBehaviour
{

    public void Jouer() 
    {
        Application.LoadLevel("jeu");
    }

    public void Quitter() 
    {
        Application.Quit();
    }
}
