using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class AmmoExplosive : MonoBehaviour
{
    void Start(){}

    void Update(){}

    public static void CollisionAction(GameObject ammo){

        //Faire quelque chose

        Debug.Log("Explosion!");
        RechargeExplosiveAmmo();
        Destroy(ammo);
    }

     private static void RechargeExplosiveAmmo(){
        Debug.Log("Energy Recharged!");
    }
}