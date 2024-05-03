using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmmoBoxScript : MonoBehaviour
{
    /*
    [FormerlySerializedAs("referenceGestion")] public PowerUpSpawner reference;
    public int idArme;
    private bool collisionDetectee;
    private const float MIN_Y = -9.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PowerUpPickup>() != null) // Si le power-up est encore actif
        {
            rotation();  
            detruireSiTropBas();
            ajouterMunitions();
        }
        else
        {
            desactiver();
        }
    }

    private void OnEnable()
    {
        reference = GameObject.FindWithTag("Player").GetComponent<PowerUpSpawner>();
        reference.ammoBoxInstanciee = true;
        idArme = reference.idPowerUp - 6;
    }

    private void desactiver()
    {
        collisionDetectee = false;
        reference.ammoBoxInstanciee = false;
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collisionDetectee = true;
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<SpriteRenderer>());
            PowerUpPickup referencePUP = FindObjectOfType<PowerUpPickup>();
            referencePUP.jouerSon();
        }
    }

    private void rotation()
    {
        if (!collisionDetectee)
        {
            transform.Rotate(0f, 0f, 0.5f);
        }
    }

    private void detruireSiTropBas()
    {
        if (transform.position.y < MIN_Y && !collisionDetectee)
        {
            desactiver();
            Destroy(gameObject);
        }
    }

    private void ajouterMunitions()
    {
        if (collisionDetectee)
        {
            PowerUpPickup referencePup = FindObjectOfType<PowerUpPickup>();
            int munitionsAjouter = referencePup.arme.MUNITIONS_A_AJOUTER;
            referencePup.arme.addMunition(munitionsAjouter);
            desactiver();
        }
    }*/
    
}
