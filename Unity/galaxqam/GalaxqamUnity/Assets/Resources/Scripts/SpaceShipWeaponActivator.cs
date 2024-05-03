using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipWeaponActivator : MonoBehaviour
{
    public GameObject[] weaponSystem = new GameObject[6];

    public int energy_id = -1;
    public int explosive_id = -1;

    public WeaponControl weaponControl = null;

    // si à null, no weapon in use.
    /* public WeaponControl wc_energy = null; */
    /* public WeaponControl wc_explosive = null; */


    // Start is called before the first frame update
    void Start()
    {
        Init();
        //SetAllOff();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        weaponSystem[Constants.WEAPON_SHORT_LASER_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_ENERGY_HOLDER_NAME).transform.
            Find(Constants.WEAPON_SHORT_LASER_NAME).gameObject;
        weaponSystem[Constants.WEAPON_SHORT_LASER_ID].AddComponent<ShortFire>();

        weaponSystem[Constants.WEAPON_LONG_LASER_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_ENERGY_HOLDER_NAME).transform.
            Find(Constants.WEAPON_LONG_LASER_NAME).gameObject;
        weaponSystem[Constants.WEAPON_LONG_LASER_ID].AddComponent<LongFire>();

        weaponSystem[Constants.WEAPON_GAMMA_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_ENERGY_HOLDER_NAME).transform.
            Find(Constants.WEAPON_GAMMA_NAME).gameObject;
        weaponSystem[Constants.WEAPON_GAMMA_ID].AddComponent<GammaFire>();

        weaponSystem[Constants.WEAPON_MACHINE_GUN_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_EXPLOSION_HOLDER_NAME).transform.
            Find(Constants.WEAPON_MACHINE_GUN_NAME).gameObject;
        weaponSystem[Constants.WEAPON_MACHINE_GUN_ID].AddComponent<MachineFire>();

        weaponSystem[Constants.WEAPON_GRENADE_LAUNCHER_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_EXPLOSION_HOLDER_NAME).transform.
            Find(Constants.WEAPON_GRENADE_LAUNCHER_NAME).gameObject;
        weaponSystem[Constants.WEAPON_GRENADE_LAUNCHER_ID].AddComponent<GrenadeFire>();

        weaponSystem[Constants.WEAPON_NUCLEAR_LAUNCHER_ID] =
            gameObject.transform.Find(Constants.SPACESHIP_NAME).transform.
            Find(Constants.WEAPON_EXPLOSION_HOLDER_NAME).transform.
            Find(Constants.WEAPON_NUCLEAR_LAUNCHER_NAME).gameObject;
        weaponSystem[Constants.WEAPON_NUCLEAR_LAUNCHER_ID].AddComponent<NuclearFire>();

        this.weaponControl = GameObject.Find("SpaceShip").GetComponent<WeaponControl>();
    }

    void SetAllOff()
    {
        SetEnergyOff();
        SetExplosiveOff();
    }

    void SetEnergyOff()
    {
        for (int i = Constants.WEAPON_SHORT_LASER_ID;
                i <= Constants.WEAPON_GAMMA_ID;
                ++i)
        {
            weaponSystem[i].SetActive(false);
        }
    }

    void SetExplosiveOff()
    {
        for (int i = Constants.WEAPON_MACHINE_GUN_ID;
                i <= Constants.WEAPON_NUCLEAR_LAUNCHER_ID;
                ++i)
        {
            weaponSystem[i].SetActive(false);
        }
    }

    public void ActivateWeapon(int WEAPON_ID)
    {
        if (WEAPON_ID >= weaponSystem.Length ||
                WEAPON_ID < 0 || weaponSystem[WEAPON_ID].activeInHierarchy )
        {
            // id is invalid, do nothing
            return;
            // If the weapon is the energy type
        }



        if (WEAPON_ID >= Constants.WEAPON_SHORT_LASER_ID &&
                WEAPON_ID <= Constants.WEAPON_GAMMA_ID )
        {


            SetEnergyOff();
            energy_id = WEAPON_ID;
            weaponSystem[WEAPON_ID].SetActive(true);
            this.weaponControl.EnergyWeapon = (IFire)weaponSystem[WEAPON_ID].GetComponent(Constants.WEAPONS[WEAPON_ID]);


            // this.weaponControl.EnergyWeapon.resetMunitionAmount();

        }
        else
        {
            SetExplosiveOff();
            explosive_id = WEAPON_ID;
            weaponSystem[WEAPON_ID].SetActive(true);
            this.weaponControl.ExplosiveWeapon = (IFire)weaponSystem[WEAPON_ID].GetComponent(Constants.WEAPONS[WEAPON_ID]);

            // this.weaponControl.ExplosiveWeapon.resetMunitionAmount();
        }
    }

    public void DeactivateWeapon(int WEAPON_ID)
    {
        if (WEAPON_ID < 0 && WEAPON_ID >= weaponSystem.Length)
        {
            return;
        }
        if (WEAPON_ID <= Constants.WEAPON_GAMMA_ID)
        {
            energy_id = -1;
            // wc_energy = null;
            weaponSystem[WEAPON_ID].SetActive(false);
            weaponSystem[WEAPON_ID].GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else
        {
            explosive_id = -1;
            // wc_explosive = null;
            weaponSystem[WEAPON_ID].SetActive(false);
            weaponSystem[WEAPON_ID].GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    IEnumerator deactivateDelay(int weaponId) {
        if (weaponId >= 0 && weaponId <= Constants.WEAPON_GAMMA_ID)
        {
            weaponSystem[weaponId].GetComponentInChildren<MeshRenderer>().enabled = false;
            yield return new WaitUntil(() => weaponControl.EnergyWeapon.isPlaying == false);
            DeactivateWeapon(weaponId);
        }
        else {
            weaponSystem[weaponId].GetComponentInChildren<MeshRenderer>().enabled = false;
            yield return new WaitUntil(() => weaponControl.ExplosiveWeapon.isPlaying == false);
            DeactivateWeapon(weaponId);
        }
    }

    public void FireEnergy()
    {
        if (energy_id >= 0 && energy_id <= Constants.WEAPON_GAMMA_ID)
        {
            Debug.Log(weaponControl.EnergyWeapon);
            // Call the fire script of the energy weapon
            if (weaponControl != null)
            {
                weaponControl.FireEnergy();
                Debug.Log("Fire energy : " + Constants.TextualWeaponId(energy_id));
                if (weaponControl.EnergyWeapon.Munition <= 0)
                    StartCoroutine(deactivateDelay(energy_id));//DeactivateWeapon(energy_id);

            }
        }
        else
        {
            // else make noise no ammo
            Debug.Log("Fire Energy called with energy_id = -1");
        }

    }

    public void FireExplosive()
    {
        if (explosive_id >= Constants.WEAPON_MACHINE_GUN_ID &&
                explosive_id <= Constants.WEAPON_NUCLEAR_LAUNCHER_ID)
        {
            if (weaponControl != null)
            {
                weaponControl.FireExplosive();
                Debug.Log("Fire explosive : " + Constants.TextualWeaponId(explosive_id));
                if (weaponControl.ExplosiveWeapon.Munition <= 0)
                    StartCoroutine(deactivateDelay(explosive_id));//DeactivateWeapon(explosive_id);

            }
            // Call the fire script of the energy weapon
            // weaponSystem[energy_id].GetComponent<WeaponControl>().Fire()

        }
        else
        {
            Debug.Log("Fire Explosive called with energy_id = -1");
            // else MakeNoise no available ammo...
        }
    }

    /* IEenumerator ActivateWeaponTemp(int WEAPON_ID){ */
    /*     // this should only be call after WEAPON_ID has been validated */


    /* } */



}
