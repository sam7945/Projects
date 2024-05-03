using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ActivationPowerUp : MonoBehaviour
{
    // Debug ->
    public Text debug;
    public GameObject objetDebug;
    // Référence d'autres des scripts d'autres objets
    private SpaceShip referenceSpaceShip;
    private PowerUpSpawner referenceScript; 
    // Variable concernant la durée d'activation
    private const float DUREE = 10f; // Mettre à 30 secondes
    private float timerDuree = DUREE;
    private Text texteTempsRestant;
    private SpaceShipDisplayHealth reference;
    // Variables pour les sons
    private AudioSource son;
    // Variables concernant l'activation
    private Dictionary<int, string> idNom = new Dictionary<int, string>();
    private int idPowerUp;
    private bool collisionDetectee; // Indique si une collision a été détectée avec le vaisseau
    private GameObject powerUp; // Le booster à activer
    // Variable sur la position, composition de l'icône
    private const float MIN_Y = -9.5f;
    private const float FACTEUR_SCALE = 0.6f; // À modifier selon la scène
    private Vector3 POS_ICONE_ACTIF = new Vector3(-28.5f, 43.5f, 0f); // À modifier (dépendemment de la taille de l'écran), car c'est adapté au Laptop.
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        reference = FindObjectOfType<SpaceShipDisplayHealth>();
        son = GetComponent<AudioSource>();
        referenceScript = FindObjectOfType<PowerUpSpawner>();
        referenceSpaceShip = FindObjectOfType<SpaceShip>();
        remplirDictionnaire();
        idPowerUp = referenceScript.idPowerUp;
        objetDebug = GameObject.Find("Canvas/Debug");
        if (objetDebug != null)
        {
            debug = objetDebug.GetComponent<Text>();
        }
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
            if (idPowerUp != 3)
            {
                powerUp = GameObject.Find("SpaceShip/SpaceShip/" + idNom[idPowerUp]);
                powerUp.SetActive(true);
            }
            else
            {
                //debug.text = "Pas encore implemente";
            }
            // Déplacé l'icône en haut à gauche, enlever la gravité et la rotation
            transform.position = POS_ICONE_ACTIF;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.transform.rotation = Quaternion.identity;
            referenceScript.powerUpActif = true;
            transform.localScale *= FACTEUR_SCALE; // Raccourcir l'icône
        }        
    }

    private void gererDuree()
    {
        if (collisionDetectee)
        {
            if (timerDuree > 0) // Il reste du temps
            {
                timerDuree -= Time.deltaTime;
                reference.texteTempsRestant = "Temps restant\n" + Math.Round(timerDuree, 0);
            }
            else // Le temps de durée du power-up est écoulé
            {
                collisionDetectee = false;
                referenceScript.powerUpActif = false;
                referenceScript.iconeActive = false;
                referenceSpaceShip.jouerSon = true;
                reference.texteTempsRestant = "";
                if (idPowerUp != 3)
                {
                    powerUp.SetActive(false);
                }
                Destroy(gameObject);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CollisionBoxLeftWing" || other.name == "CollisionBoxBody" || other.name == "CollisionBoxRightWing")
        {
            // Jouer sonObtention ici
            son.Play();
            collisionDetectee = true;
            activerPowerUp();
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
                referenceScript.iconeActive = false;
                Destroy(gameObject);
            }    
        }    
    }
    
}
