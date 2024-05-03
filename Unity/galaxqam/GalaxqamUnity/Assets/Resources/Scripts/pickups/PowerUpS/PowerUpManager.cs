using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // Reférence vers les autres scripts
    private PowerUpSpawner referenceSpawner;
    private SpaceShipBoosterActivator referenceSSBA;
    private SpaceShip referenceSpaceShip;
    private SpaceShipDisplayHealth referenceDisplay;
    // Pour le timer
    public float timerPowerUp;
    private float DUREE;
    // Pour la position de l'icône
    private const float MIN_Y = -9.5f;
    private const float FACTEUR_SCALE = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        referenceSpawner = FindObjectOfType<PowerUpSpawner>(); // Obtenir la référence vers le spawner de power-up
        referenceSSBA = FindObjectOfType<SpaceShipBoosterActivator>(); // Obtenir la référence vers l'activateur des power-ups
        referenceSpaceShip = FindObjectOfType<SpaceShip>(); // 
        referenceDisplay = FindObjectOfType<SpaceShipDisplayHealth>(); // 
        DUREE = GameSettings.GetBoosterTime(); // 
    }

    // Update is called once per frame
    void Update()
    {
        detruireIconeSiTropBas();
        gererTimer();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activer();
        }
    }

    private void activer()
    {
        referenceSpawner.powerUpActif = true; // Signaler au Spawner de power-up 
        // Placer l'icône en haut à gauche
        placerTopLeft();
        figerIcone();
        // Jouer son
        GetComponent<AudioSource>().Play();
        // Gestion des cas selon le power-up
        if (referenceSpawner.idPowerUp < 4) // Cas où il y a une limite de temps pour le power-up
        {
            timerPowerUp = DUREE;
            if (referenceSpawner.idPowerUp == 3) // Cas invulnérabilité
            {
                referenceSpaceShip.GetComponent<Invulnerability>().beginInvincibility2(DUREE);        
            }
            else // Les power-ups déja implémentés dans SpaceShipBoosterActivator (0, 1, 2)
            {
                referenceSSBA.SetActive(referenceSpawner.idPowerUp); // Activer le power up        
            }
        }
        else // Les power-up qui n'ont pas de timer (vie et munitions)
        {
            timerPowerUp = 3f; // Pour afficher le texte pendant 3 secondes
            if (referenceSpawner.idPowerUp == 4) // Cas points de vie
            {
                referenceSpaceShip.GetComponent<Health>().addHealth(Constants.POINTS_DE_VIE_A_AJOUTER);
                referenceDisplay.texteTempsRestant = Constants.POINTS_DE_VIE_A_AJOUTER + " points de vie\najoutes";
            }
            else // Cas pour les munitions
            {
                // Ajouter le composant avec le script de gestion des munitions avec les armes
                referenceSpaceShip.AddComponent<WeaponAmmoPowerUp>();
                referenceSpaceShip.GetComponent<WeaponAmmoPowerUp>().weaponId = referenceSpawner.idPowerUp - 5;
                referenceDisplay.texteTempsRestant = "Munitions de \n" + Constants.TextualWeaponId(referenceSpawner.idPowerUp - 5) + "\nrecuperees";
            }
        }   
    }

    private void gererTimer()
    {
        if (referenceSpawner.powerUpActif) 
        {
            if (timerPowerUp > 0)
            {
                timerPowerUp -= Time.deltaTime; // MAJ le timer
                if (referenceSpawner.idPowerUp < 4) 
                {
                    referenceDisplay.texteTempsRestant = "Temps restant\n" + Math.Round(timerPowerUp, 0);
                }
            }
            else // Le temps du timer est écoulé
            {
                desactivation();
            }
        }
    }

    private void detruireIconeSiTropBas()
    {
        if (!referenceSpawner.powerUpActif && transform.position.y < MIN_Y)
        {
            referenceSpawner.iconeActive = false;
            Destroy(gameObject);
        }
    }

    private void desactivation()
    {
        if (referenceSpawner.idPowerUp < 4) // Si le power-up a un timer
        {
            referenceSpaceShip.jouerSon = true; // Jouer le son
        }
        referenceDisplay.texteTempsRestant = "";
        referenceSpawner.iconeActive = false;
        referenceSpawner.powerUpActif = false;
        Destroy(gameObject);
    }

    private void placerTopLeft()
    {
        Vector3 topLeftViewPort;
        Vector3 topLeftWorld;
        topLeftViewPort = new Vector3(0.18f, 0.925f, Camera.main.nearClipPlane);
        topLeftWorld = Camera.main.ViewportToWorldPoint(topLeftViewPort);
        topLeftWorld.z = 0;
        transform.position =  topLeftWorld;
    }

    private void figerIcone()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.transform.rotation = Quaternion.identity;
        transform.localScale *= FACTEUR_SCALE; // Raccourcir l'icône
    }
}
