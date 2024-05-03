using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public static void CollisionAction(GameObject ammo)
    {
        GameObject spaceShip = GameObject.Find("SpaceShip");
        SpaceShipBoosterActivator ssba = spaceShip.GetComponent<SpaceShipBoosterActivator>();

        ssba.SetActive(SpaceShipBoosterActivator.SPEED);
    }

    public static void Enable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpSpeedEnabled = true;
        GameSettings.PlayerShipSpeed = 2;
    }

    public static void Disable(SpaceShipBoosterActivator ssba)
    {
        ssba.powerUpSpeedEnabled = false;
        GameSettings.PlayerShipSpeed = 1;
    }
}
