using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce petit script vous donne un point de départ pour comprendre comment
// les collisions sont gérer par le système.

public class ColliderSensors : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        System.Action<GameObject> action;

        //Actions de collision pour le vaisseau
        if(gameObject.name == "SpaceShip")
        {
            SpaceShip.collisionActions.TryGetValue(col.gameObject.name, out action);
            action(col.gameObject);
        }

        /*Définir d'autres Actions de collision pour d'autres objets.
        if(gameObject.name == "SimpleProjectile")
        {
            game.collisionActions.TryGetValue(col.gameObject.name, out action);
            action(col.gameObject);
        }**/

    }

}



