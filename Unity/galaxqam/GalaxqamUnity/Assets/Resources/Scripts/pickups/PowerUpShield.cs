using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    public static void CollisionAction(GameObject ammo)
    {
        GameObject spaceShip = GameObject.Find("SpaceShip");
        SpaceShipBoosterActivator ssba = spaceShip.GetComponent<SpaceShipBoosterActivator>();

        ssba.SetActive(SpaceShipBoosterActivator.SHIELD);
    }

    public static void Enable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpShieldEnabled = true;
    }

    public static void Disable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpShieldEnabled = false;
    }
}
