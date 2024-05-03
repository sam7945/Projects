using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PowerUpSpawner : MonoBehaviour
{
    // Pour débugger
    public Text debug;
    // Cooldown au début de la partie
    private const float TEMPS_COOLDOWN_DEBUT = 10f; // Mettre à 120 -> 2 mminutes
    private const float TEMPS_APRES_COOLDOWN = 5f; // Mettre à 20- -> 20 secondes
    public float coolDownTimer = TEMPS_COOLDOWN_DEBUT;
    private bool timerDebutEcoule;
    // Instance de l'icône du power-up
    private SpriteRenderer spriteRenderer;
    private Sprite sprite;
    private GameObject prefab; 
    public GameObject instance;
    // Activation
    public bool iconeActive;
    public bool ennemiDetruit;
    public bool powerUpActif;
    public int idPowerUp;

    // Start is called before the first frame update
    void Start()
    {
       prefab = Resources.Load<GameObject>("Prefabs/IcônePowerUp");
    }

    // Update is called once per frame
    void Update()
    {
        activerPremiereFois();
        activerApresCooldown();
        rotation();
        //debug.text = "Cooldown : " + Math.Round(coolDownTimer, 0);
    }

    private void activerPremiereFois()
    {
        if (!timerDebutEcoule)
        {   
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime; // MAJ le timer
            }
            else
            {
                instancierObjet();
                timerDebutEcoule = true;
            }    
        }
    }

    private Sprite determinerPowerUp(int i)
    {
        idPowerUp = i;
        switch (i)
        { 
            case 0 :
                return Resources.Load<Sprite>("Images/PowerUpsIcons/Shield");
            case 1 :
                return Resources.Load<Sprite>("Images/PowerUpsIcons/Armes");
            case 2 :
                return Resources.Load<Sprite>("Images/PowerUpsIcons/Vitesse");
            case 3 :
                return Resources.Load<Sprite>("Images/PowerUpsIcons/Invulnerabilite");
            case 4 :
                return Resources.Load<Sprite>("Images/PowerUpsIcons/Vie");
            case 5 :
                return Resources.Load<Sprite>("Images/AmmoIcons/shortLaser");
            case 6 :
                return Resources.Load<Sprite>("Images/AmmoIcons/longLaser");
            case 7 :
                return Resources.Load<Sprite>("Images/AmmoIcons/gamma");
            case 8 :
                return Resources.Load<Sprite>("Images/AmmoIcons/machineGun");
            case 9 :
                return Resources.Load<Sprite>("Images/AmmoIcons/grenade");
            case 10 :
                return Resources.Load<Sprite>("Images/AmmoIcons/nuclear");
            // Ajouter ammoBox
            default :
                return null;
        }
    }

    private void rotation()
    {
        if (iconeActive && !powerUpActif)
        {
            instance.transform.Rotate(0f, 0f, 0.5f);
        }
    }

    private void activerApresCooldown()
    {
        if (timerDebutEcoule && !iconeActive && !powerUpActif)
        {   
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime; // MAJ le timer
            }
            else
            {
                instancierObjet();
            }     
        }
    }

    private void instancierObjet()
    {
        if (ennemiDetruit) //  && Random.Range(1, 3) > 1 -> 50% de chance qu'un power-up soit 
        {
            // Ajouter quelque chose pour diminuer les chances d'avoir la bombe nucléaire idPowerUp : 10
            int i = Random.Range(0, 11); // Pour déterminer quel powerUp activer 0 = shield, 1 = weapon, 2 = speed, 3 = invulnérabilité, 4 = health, reste = munitions pour les armes
            float x = Random.Range(-45f, 45f); // Déterminer la position latérale de l'icône de power-up alèatoirement, peut-être prendre en compte la largeur de la caméra/screen
            sprite = determinerPowerUp(i);
            instance = Instantiate(prefab, new Vector3(x, Random.Range(40f, 105f), 0), Quaternion.identity); //y:40f indique la hauteur à laquelle peut être instanciée l'icône
            spriteRenderer = instance.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            
            if (idPowerUp >= 5) // Régler le problème du scale / collider si idPowerUp >= 5
            {
                instance.transform.localScale *= 2f;
                instance.GetComponent<SphereCollider>().radius = 2f;
                instance.GetComponent<SphereCollider>().center = new Vector3(0f, 0f, 0f);
            }
            instance.SetActive(true);
            iconeActive = true;
            coolDownTimer = TEMPS_APRES_COOLDOWN;
        }
        ennemiDetruit = false;
    }
}
