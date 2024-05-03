using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WeaponAmmoPowerUp : MonoBehaviour
{
    /*
     * les id:
     * 0 - machine gun 
     * 1 - lance grenade
     * 2 - bombe nucleaire
     * 3 - laser court
     * 4 - laser long
     * 5 - rayon gamma
     */

    public int weaponId;
    public SpaceShipWeaponActivator sswa; 
    private  WeaponControl weaponControl;
    private GameObject weaponTargeted;

    public MachineFire machineFire;
    public GrenadeFire grenadeFire;
    public GammaFire gammaFire;
    public LongFire longFire;
    public ShortFire shortFire;
    public NuclearFire nuclearFire;

    AudioClip ac;
    UnityEngine.Vector3 vector3;


    // Start is called before the first frame update
    void Start()
    {

        vector3 = transform.position;

        sswa = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipWeaponActivator>();
        weaponControl = sswa.weaponControl;
        weaponTargeted = sswa.weaponSystem[weaponId];


        ac = Resources.Load<AudioClip>("Sounds/PowerUpsSoundEffects/Obtention");
        switch (weaponId)
        {
            case Constants.WEAPON_MACHINE_GUN_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_MACHINE_GUN_ID];
                break;

            case Constants.WEAPON_GRENADE_LAUNCHER_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_GRENADE_LAUNCHER_ID];
                break;

            case Constants.WEAPON_NUCLEAR_LAUNCHER_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_NUCLEAR_LAUNCHER_ID];
                break;

            case Constants.WEAPON_SHORT_LASER_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_SHORT_LASER_ID];
                break;

            case Constants.WEAPON_LONG_LASER_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_LONG_LASER_ID];
                break;

            case Constants.WEAPON_GAMMA_ID:
                weaponTargeted = sswa.weaponSystem[Constants.WEAPON_GAMMA_ID];
                break;
        }

        gammaFire = weaponTargeted.GetComponent<GammaFire>();
        machineFire = weaponTargeted.GetComponent<MachineFire>();
        grenadeFire = weaponTargeted.GetComponent<GrenadeFire>();
        nuclearFire = weaponTargeted.GetComponent<NuclearFire>();
        shortFire = weaponTargeted.GetComponent<ShortFire>();
        longFire = weaponTargeted.GetComponent<LongFire>();
        
        activerEffets();
    }

    private void activerEffets()
    {
        switch (weaponId)
        {   
            case Constants.WEAPON_MACHINE_GUN_ID:
                AddMachineGunMunition(150);
                break;

            case Constants.WEAPON_GRENADE_LAUNCHER_ID:
                AddGrenadeLauncherMunition(10);
                break;

            case Constants.WEAPON_NUCLEAR_LAUNCHER_ID:
                AddNuclearMunition(1);
                break;

            case Constants.WEAPON_SHORT_LASER_ID:
                AddShortLaserMunition(15);
                break;

            case Constants.WEAPON_LONG_LASER_ID:
                AddLongLaserMunition(12);
                break;

            case Constants.WEAPON_GAMMA_ID:
                AddRayonGmmaMunition(10);
                break;
        }
        Destroy(GetComponent<WeaponAmmoPowerUp>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddMachineGunMunition(int munition)
    {
        if (machineFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            machineFire.addMunition(munition);
        }
    }

    private void AddGrenadeLauncherMunition(int munition)
    {
        if (grenadeFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            grenadeFire.addMunition(munition);
        }
    }

    private void AddNuclearMunition(int munition)
    {
        if (nuclearFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            nuclearFire.addMunition(munition);
        }
    }

    private void AddShortLaserMunition(int munition)
    {
        if (shortFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            shortFire.addMunition(munition);
        }
    }

    private void AddLongLaserMunition(int munition)
    {
        if (longFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            longFire.addMunition(munition);
        }
    }

    private void AddRayonGmmaMunition(int munition)
    {
        if (gammaFire == null)
        {
            sswa.ActivateWeapon(weaponId);
        }
        else
        {
            gammaFire.addMunition(munition);
        }
    }


}
