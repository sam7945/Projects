using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Reflection;



//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class Enemy : MonoBehaviour
{
    //public delegate void OnDestroyDelegate(); // Ajout
    //public static event OnDestroyDelegate OnDestroyEvent; // Ajout
    public PowerUpSpawner referenceGestion;


    Health health;
    EnemyDisplayHealth displayLife;
    public WeaponControl weaponControl;
    float counter;
    float maxDelay;
    float damage;
    Rigidbody body;
    GameObject spaceShip;
    public static CollisionActions collisionActions = new CollisionActions(){
            {nameof(SimpleProjectile), SimpleProjectile.CollisionAction}
        };

    void Start()
    {
        spaceShip = GameObject.Find("SpaceShip");
        body = this.GetComponent<Rigidbody>();
        body.useGravity = false;
        body.freezeRotation = true;
        body.constraints = RigidbodyConstraints.FreezeAll;
        referenceGestion = FindObjectOfType<PowerUpSpawner>();
        health = gameObject.AddComponent<Health>();
        EnemyDisplayHealth displayLife = gameObject.AddComponent<EnemyDisplayHealth>();
        health.setDisplayLife(displayLife);

        maxDelay = updateMaxDelay();
    }

    void Update()
    {
        /*
        // les enemis tirent un projectile dans un range de temps au hasard, a retravailler lors de l'implementation du niveau
        counter += Time.deltaTime;
        if (counter > maxDelay)
       {
            counter = 0;
            maxDelay = updateMaxDelay();
            if (weaponControl != null)
            {
                weaponControl.FireStandardWeapon();
            }
        }*/
    }

    float updateMaxDelay()
    {
        float random = Random.Range(1.0f, 10.0f);
        return random;
    }

    public void OnDestroy()
    {
        if (spaceShip != null)
            spaceShip.gameObject.GetComponent<Points>().addPoints((7 - Int32.Parse(this.gameObject.name.Substring(12, 1))) * 5);


        //Debug.Log("Ennemi détruit !"); // Ça marche
        if ((!referenceGestion.iconeActive && referenceGestion.coolDownTimer <= 0))
        {
            referenceGestion.ennemiDetruit = true;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SpaceShip")
        {
            damage = collision.gameObject.GetComponent<Health>().getHealth();
            collision.gameObject.GetComponent<Health>().applyDmg(damage);
            Destroy(gameObject);
        }

    }
}
