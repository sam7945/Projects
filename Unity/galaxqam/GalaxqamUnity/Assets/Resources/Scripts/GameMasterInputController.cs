using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterInputController : MonoBehaviour
{

    public SpaceShipBoosterActivator ssba;
    public GameObject spaceShip;
    public SpaceShipWeaponActivator sswa;
    // public SpaceShipCameraController sscc;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake(){
        InitSpaceShip();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    public void InitSpaceShip()
    {
        spaceShip = GameObject.Find(Constants.SPACESHIP_NAME);
        ssba = spaceShip.GetComponent<SpaceShipBoosterActivator>();
        sswa = spaceShip.GetComponent<SpaceShipWeaponActivator>();
        // sscc = spaceShip.GetComponent<SpaceShipCameraController>();
    }

    void InputManager()
    {
        /* if(Input.GetKeyDown(KeyCode.J)){ */
        /*     sscc.ToggleCam(); */
        /* } */
        if(Input.GetKey(KeyCode.Keypad1)){
            ssba.SetActive(SpaceShipBoosterActivator.SHIELD);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ssba.SetActive(SpaceShipBoosterActivator.WEAPON);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ssba.SetActive(SpaceShipBoosterActivator.SPEED);
        }

        // special weapon
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sswa.FireEnergy();
            Debug.Log("Weapon Energy keyboard fired!");
            // fire energy
        }


        if (Input.GetKeyDown(KeyCode.X) && sswa.explosive_id != Constants.WEAPON_MACHINE_GUN_ID)
        {
            sswa.FireExplosive();
            Debug.Log("Weapon Explosive keyboard fired!");
            // fire explosive
        }
        if (Input.GetKey(KeyCode.X) && sswa.explosive_id == Constants.WEAPON_MACHINE_GUN_ID)
        {
            sswa.FireExplosive();
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sswa.ActivateWeapon(Constants.WEAPON_SHORT_LASER_ID);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sswa.ActivateWeapon(Constants.WEAPON_LONG_LASER_ID);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sswa.ActivateWeapon(Constants.WEAPON_GAMMA_ID);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // activate Machine Gun
            sswa.ActivateWeapon(Constants.WEAPON_MACHINE_GUN_ID);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // activate GrenadeLauncher
            sswa.ActivateWeapon(Constants.WEAPON_GRENADE_LAUNCHER_ID);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // activate NuclearLaucher
            sswa.ActivateWeapon(Constants.WEAPON_NUCLEAR_LAUNCHER_ID);
        }
    }
}
