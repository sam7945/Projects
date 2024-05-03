using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PowerUpPickup : MonoBehaviour
{   /*
    // Debug
    public Text debug;
    public GameObject objetDebug;
    // Référence d'autres des scripts d'autres objets
    // Variable concernant la durée d'activation
    private const float DUREE = 35f; // Mettre à 30 secondes
    private float timerDuree = DUREE;
    private Text texteTempsRestant;
    // Variables pour les sons
    private AudioSource audioSource; 
    // Variables concernant l'activation
    private Dictionary<int, string> idNom = new Dictionary<int, string>();
    private int idPowerUp;
    private bool collisionDetectee; // Indique si une collision a été détectée avec le vaisseau
    private GameObject powerUp; // Le booster à activer
    // Variable sur la position, composition de l'icône
    private const float MIN_Y = -9.5f;
    private const float FACTEUR_SCALE = 0.8f; // À modifier selon la scène
    private Vector3 POS_ICONE_ACTIF = new Vector3(-87f, 118f, 0f); // À modifier (dépendemment de la taille de l'écran), car c'est adapté au Laptop.

    // Pour l'affichage des munitions des armes
    public IFire arme;
    private SpaceShipDisplayHealth referenceHealth;
    
    
     * id identifie le powerUp 
     * 1- weapon 
     * 2- shield
     * 3- invulnerabilité
     * 4- vitesse
     * 5- vie
     
    public int id;

    private SpaceShipBoosterActivator boosterItem;
    private Vector3 vector3;
    static private GameObject spaceship;
    static private Invulnerability invulnerable;
    public  AudioClip[] audioList;

    //inserer les booster a activer
     GameObject shieldBoost;
     GameObject weaponBoost;
     GameObject speedBoost;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/PowerUpsSoundEffects/Obtention");
        audioSource.playOnAwake = false;
        vector3 = transform.position;
        spaceship = GameObject.FindGameObjectWithTag("Player");
        shieldBoost = spaceship.transform.GetChild(1).transform.GetChild(0).gameObject;
        weaponBoost = spaceship.transform.GetChild(1).transform.GetChild(2).gameObject;
        speedBoost = spaceship.transform.GetChild(1).transform.GetChild(1).gameObject;

        invulnerable = spaceship.GetComponent<Invulnerability>();
        boosterItem = spaceship.GetComponent<SpaceShipBoosterActivator>();

        //une liste des audio power up (Cause une IndexOutOfBoundsException)
        /*audioList[0] = Resources.Load<AudioClip>("Sounds/PowerUp1");
        audioList[1] = Resources.Load<AudioClip>("Sounds/PowerUp2");
        audioList[2] = Resources.Load<AudioClip>("Sounds/PowerUp3");
        audioList[3] = Resources.Load<AudioClip>("Sounds/PowerUp4");
        
        // Pour le son

        //importer de l'autre
        remplirDictionnaire();
        objetDebug = GameObject.Find("Canvas/Debug");
        if (objetDebug != null)
        {
            debug = objetDebug.GetComponent<Text>();
        }
        timerDuree = DUREE;
    }

    // Update is called once per frame
    void Update()
    {
        gererDuree();
        gererTropBas();
    }


    private void activerPowerUp()
    {
        if (collisionDetectee)
        {
            if (idPowerUp == 1 || idPowerUp == 2 || idPowerUp == 4)
            {
                powerUp = GameObject.Find("SpaceShip/SpaceShip/" + idNom[idPowerUp]);
            }
            else
            {
                if (idPowerUp > 5)
                {
                    referenceHealth = spaceship.GetComponent<SpaceShipDisplayHealth>();
                    arme = determinerArmeActivee();
                }
            }
            // Déplacé l'icône en haut à gauche, enlever la gravité et la rotation
            transform.position = POS_ICONE_ACTIF;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.transform.rotation = Quaternion.identity;
            spaceship.GetComponent<PowerUpSpawner>().powerUpActif = true;
            transform.localScale *= FACTEUR_SCALE; // Raccourcir l'icône
            // Jouer le son
            jouerSon();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        idPowerUp = spaceship.GetComponent<PowerUpSpawner>().idPowerUp;
        if (other.CompareTag("Player"))
        {

            switch (id)
            {
                case 1:
                    collisionDetectee = true;

                    //AudioSource.PlayClipAtPoint(audioList[0], vector3);
                    boosterItem.SetActive(1);
                    break;

                case 2:
                    collisionDetectee = true;

                    //AudioSource.PlayClipAtPoint(audioList[1], vector3);
                    boosterItem.SetActive(0);
                    break;

                case 3:
                    //AudioSource.PlayClipAtPoint(audioList[2], vector3);
                    invulnerable.beginInvincibility2(5);
                    collisionDetectee = false; 
                    Destroy(gameObject);
                    break;

                case 4:
                    collisionDetectee = true;

                    //AudioSource.PlayClipAtPoint(audioList[3], vector3);
                    boosterItem.SetActive(2);
                    break;

                case 5:
                    //AudioSource.PlayClipAtPoint(audioList[3], vector3);
                    spaceship.GetComponent<Health>().addHealth(30);
                    collisionDetectee = false ;
                    Destroy(gameObject);
                    break;
                case 10 :
                    int idArme = idPowerUp - 6;
                    spaceship.GetComponent<SpaceShipWeaponActivator>().ActivateWeapon(idArme);
                    collisionDetectee = true;
                    break;
            }
            activerPowerUp();
        }
    }

    public void jouerSon()
    {
        audioSource.Play();
    }

    private void gererDuree()
    {
        if (collisionDetectee)
        {
            if (timerDuree > 0) // Il reste du temps
            {
                timerDuree -= Time.deltaTime;
                spaceship.GetComponent<SpaceShipDisplayHealth>().texteTempsRestant = "Temps restant\n" + Math.Round(timerDuree, 0);
                if (idPowerUp > 5)
                {
                    referenceHealth.texteMunitions = "Munitions : " + arme.Munition;
                }
            }
            else // Le temps de durée du power-up est écoulé
            {
                collisionDetectee = false;
                spaceship.GetComponent<PowerUpSpawner>().idPowerUp = 0;
                spaceship.GetComponent<PowerUpSpawner>().powerUpActif = false;
                spaceship.GetComponent<PowerUpSpawner>().iconeActive = false;
                spaceship.GetComponent<SpaceShip>().jouerSon = true;
                spaceship.GetComponent<SpaceShipDisplayHealth>().texteTempsRestant = "";
                if (idPowerUp != 3 && idPowerUp < 6) 
                {
                    powerUp.SetActive(false);
                }
                else
                {
                    spaceship.GetComponent<SpaceShipWeaponActivator>().DeactivateWeapon(idPowerUp - 6);
                    spaceship.GetComponent<PowerUpSpawner>().timerAmmoBox = PowerUpSpawner.DUREE_COOLDOWN_AMMO;
                    referenceHealth.texteMunitions = "";
                }
                Destroy(gameObject);
            }
        }
    }


    private void remplirDictionnaire()
    {
        idNom.Add(1, "BoosterSpeed");
        idNom.Add(2, "BoosterShield");
        idNom.Add(4, "BoosterWeapon");
    }

    private void gererTropBas()
    {
        if (!collisionDetectee)
        {
            if (transform.position.y < MIN_Y)
            {
                spaceship.GetComponent<PowerUpSpawner>().iconeActive = false;
                Destroy(gameObject);
            }
        }
    }

    private IFire determinerArmeActivee()
    {
        int idArme = idPowerUp - 6;
        GameObject energyHolder = GameObject.Find("SpaceShip/SpaceShip/WeaponEnergyHolder");
        GameObject explosionHolder = GameObject.Find("SpaceShip/SpaceShip/WeaponExplosionHolder");
        switch (idArme)
        {
            case 0 :
                return energyHolder.GetComponentInChildren<ShortFire>();
            case 1 : 
                return energyHolder.GetComponentInChildren<LongFire>();
            case 2 : 
                return energyHolder.GetComponentInChildren<GammaFire>();
            case 3 : 
                return explosionHolder.GetComponentInChildren<MachineFire>();
            case 4 : 
                return explosionHolder.GetComponentInChildren<GrenadeFire>();
            case 5 : 
                return explosionHolder.GetComponentInChildren<NuclearFire>();
            default :
                return null;
        }    
    }*/
}
