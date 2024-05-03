using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceShipDisplayHealth : MonoBehaviour, HealthDisplayInterface
{
    private GUIStyle tempsRestantPowerUpStyle;
    private GUIStyle healthStyle = new GUIStyle();
    
    public string texteTempsRestant = "";
    public Rect rectTexteTps;
    public string healthText;
   
   
    public float health;
    TMP_FontAsset font;
    // Pour les munitions
    private GUIStyle affichageMunitions;
    public string texteMunitions;
    // Start is called before the first frame update
    void Start()
    {
        font = Resources.Load<TMP_FontAsset>($"Fonts & Materials/Electronic Highway Sign SDF");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        // Pour l'affichage du nombre de munitions
        affichageMunitions = stylerTexte();
        // Pour l'affichage du temps restant 
        placerLeTexte();
        // Pour l'affichage de la vie
        healthStyle.font = font.sourceFontFile;
        tempsRestantPowerUpStyle = stylerTexte();
        if(health < 25)
        {
            healthStyle.normal.textColor = Color.red;
        }
        else
        {
            healthStyle.normal.textColor = Color.white;
        }
        healthStyle.fontSize = 24;
        healthStyle.font = font.sourceFontFile;
        GUI.Label(new Rect(50, Screen.height - 50, 200, 200), healthText, healthStyle);
        
        GUI.Label(new Rect(rectTexteTps), texteTempsRestant, tempsRestantPowerUpStyle);
        GUI.Label(new Rect(placerMunitions()), texteMunitions, affichageMunitions);
    }


    public void displayLife(float health)
    {
        this.health = health;
        healthText = "HEALTH : " + health.ToString();
    }

    private GUIStyle stylerTexte()
    {
        GUIStyle retour = new GUIStyle();
        retour.font = font.sourceFontFile;
        retour.fontSize = 20;
        retour.normal.textColor = Color.cyan;
        retour.alignment = TextAnchor.MiddleCenter;
        return retour;
    }
   
    private GUIStyle stylerLeTimer ()
    {
        GUIStyle retour = new GUIStyle();
        retour.font = font.sourceFontFile;
        retour.fontSize = 20;
        retour.normal.textColor = Color.cyan;
        retour.alignment = TextAnchor.MiddleCenter;
        return retour;
    }

    private void placerLeTexte()
    {
        // Pour que ça reste en haut à gauche 
        float offsetX = 20f; // Décalage horizontal depuis le bord droit de l'écran
        float offsetY = 40f; // Décalage vertical depuis le bord bas de l'écran
        float labelWidth = 230f; // Largeur du label
        float labelHeight = 45f; // Hauteur du label
        rectTexteTps = new Rect(offsetX, offsetY, labelWidth, labelHeight);
    }

    private Rect placerMunitions()
    {
        // Pour que ça reste en haut à gauche 
        float offsetX = Screen.width - 220f; // Décalage horizontal depuis le bord droit de l'écran
        float offsetY = Screen.height - 60f; // Décalage vertical depuis le bord bas de l'écran
        float labelWidth = 200f; // Largeur du label
        float labelHeight = 20f; // Hauteur du label
        return new Rect(offsetX, offsetY, labelWidth, labelHeight);    
    }
    
}
