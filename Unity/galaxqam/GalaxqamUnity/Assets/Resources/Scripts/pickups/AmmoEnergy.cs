using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AmmoEnergy : MonoBehaviour
{
    //Constructeur static pour appeler les méthodes static lors des collisions.
    static AmmoEnergy(){}

    void Start(){}

    void Update(){}

    public static void CollisionAction(GameObject ammo){
        //Faire quelque chose
        Debug.Log("Energie!");
        RechargeEnergyAmmo();
        Destroy(ammo);
    }

    private static void RechargeEnergyAmmo(){
        Debug.Log("Energy Recharged!");
    }
}