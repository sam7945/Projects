using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class SpaceShip : MonoBehaviour
{
    // Son Power-Ups
    public bool jouerSon;
    private AudioSource sonTempsEcoule;
    GameMasterInputController gmic;
    Health health;
    Points points;
    SpaceShipDisplayHealth displayHealth;
    SpaceShipDisplayPoints displayPoints;
    SpaceShipInputController controls;

    public static CollisionActions collisionActions = new CollisionActions(){
            {nameof(AmmoEnergy), AmmoEnergy.CollisionAction},
            {nameof(AmmoExplosive), AmmoExplosive.CollisionAction},
            {nameof(WeaponEnergyGamma), WeaponEnergyGamma.CollisionAction},
            {nameof(WeaponEnergyLong), WeaponEnergyLong.CollisionAction},
            {nameof(WeaponEnergyShort), WeaponEnergyShort.CollisionAction},
            {nameof(PowerUpSpeed), PowerUpSpeed.CollisionAction},
            {nameof(PowerUpShield), PowerUpShield.CollisionAction},
            {nameof(PowerUpWeapon), PowerUpWeapon.CollisionAction},
        };

    void Start()
    {
        // Son Power-Ups
        gameObject.AddComponent<AudioSource>();
        sonTempsEcoule = GetComponent<AudioSource>();
        sonTempsEcoule.playOnAwake = false;
        sonTempsEcoule.clip = Resources.Load<AudioClip>("Sounds/PowerUpsSoundEffects/TempsEcoule");
        Init();
    }

    void Update()
    {
        if (jouerSon)
        {
            sonTempsEcoule.Play();
            jouerSon = false;
        }
    }


    public static void CollisionAction(GameObject ammo)
    {
        //Faire quelque chose

    }

    void Init()
    {
        points = gameObject.AddComponent<Points>();
        health = gameObject.GetComponent<Health>();
        displayHealth = gameObject.AddComponent<SpaceShipDisplayHealth>();
        displayPoints = gameObject.AddComponent<SpaceShipDisplayPoints>();
        health.setDisplayLife(displayHealth);
        points.setDisplayPoints(displayPoints);
        //Monkey patching pour activer le game input lors de la lecture
        //de la main scene
    }
}
