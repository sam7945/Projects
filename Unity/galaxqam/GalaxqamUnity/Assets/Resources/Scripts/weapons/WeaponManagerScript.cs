using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponManagerScript : MonoBehaviour
{
    public SpaceShipWeaponActivator referenceSSWA; // Référence vers le script 
    public bool armeObtenue; // Indique si l'arme a été obtenu
    public int idArme; // L'ID de l'arme aléatoirement choisie
    
    // Start is called before the first frame update
    void Start()
    {
        //referenceSSWA = transform.parent.GetComponentInParent<SpaceShipWeaponActivator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!armeObtenue)
        {
            idArme = Random.Range(0, 6); // Voir les constantes
            referenceSSWA.ActivateWeapon(idArme);
            armeObtenue = true;
        }            
    }

    private void OnEnable()
    {
        referenceSSWA = transform.parent.GetComponentInParent<SpaceShipWeaponActivator>();
    }

    public void desactiverBooster()
    {
        referenceSSWA.DeactivateWeapon(idArme);
        idArme = 0; // À supprimer, car inutile
        armeObtenue = false;
        gameObject.SetActive(false);
    }

}
