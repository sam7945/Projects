using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxManager : MonoBehaviour
{
    public GameObject[] weaponschoices = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        Init();
        DeactivateAllWeapon();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        weaponschoices[Constants.WEAPON_SHORT_LASER_ID] =        //0
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponShortLaser_blend").gameObject;
        weaponschoices[Constants.WEAPON_LONG_LASER_ID] =         //1
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponLongLaser_blend").gameObject;
        weaponschoices[Constants.WEAPON_GAMMA_ID] =              //2
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponGamma_blend").gameObject;
        weaponschoices[Constants.WEAPON_MACHINE_GUN_ID] =        //3
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponMachineGun_blend").gameObject;
        weaponschoices[Constants.WEAPON_GRENADE_LAUNCHER_ID] =   //4
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponGrenadeLauncher_blend").gameObject;
        weaponschoices[Constants.WEAPON_NUCLEAR_LAUNCHER_ID] =   //5
            transform.Find("WeaponBoxModel_blend").
            transform.Find("WeaponNuclearLauncher_blend").gameObject;
    }


    void ActivateWeapon(int constants_weapon_id)
    {
        weaponschoices[constants_weapon_id].SetActive(true);
    }

    void DeactivateAllWeapon()
    {
        for (int i = 0; i < weaponschoices.Length; i++)
        {
            weaponschoices[i].SetActive(false);
        }
    }
}
