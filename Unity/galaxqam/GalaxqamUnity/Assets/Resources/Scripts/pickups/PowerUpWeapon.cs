using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWeapon : MonoBehaviour
{
    public static void CollisionAction(GameObject ammo)
    {
        GameObject spaceShip = GameObject.Find("SpaceShip");
        SpaceShipBoosterActivator ssba = spaceShip.GetComponent<SpaceShipBoosterActivator>();

        ssba.SetActive(SpaceShipBoosterActivator.WEAPON);
    }

    public static void Enable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpWeaponEnabled = true;
    }

    public static void Disable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpWeaponEnabled = false;
    }
}
