using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public IFire standardWeapon;
    private IFire energyWeapon;
    public IFire EnergyWeapon{
        get { return energyWeapon; }
        set { energyWeapon = value; }
    }

    private IFire explosiveWeapon;
    public IFire ExplosiveWeapon {
        get { return explosiveWeapon; }
        set { explosiveWeapon = value; }
    }

    public GameObject[] weaponSystem = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireStandardWeapon()
    {
        standardWeapon.fire();
    }

    public void FireEnergy()
    {
        if (this.energyWeapon != null && this.energyWeapon.Munition > 0)
            energyWeapon.fire();
    }

    public void FireExplosive()
    {
        if (this.explosiveWeapon != null && this.explosiveWeapon.Munition > 0)
            explosiveWeapon.fire();
    }

    public bool EnergieIsEmpty() {

        return energyWeapon.Munition == 0;

    }

    public bool ExplosiveIsEmpty()
    {
        return explosiveWeapon.Munition == 0;

    }

    public void setEnergyWeapon(IFire energyWeapon)
    {
        this.energyWeapon = energyWeapon;
    }

    public void setExplosiveWeapon(IFire explosiveWeapon)
    {
        this.explosiveWeapon = explosiveWeapon;
    }

    void Init()
    {
        if (gameObject.GetComponentInParent<Enemy>() == null)
        {
            this.standardWeapon = transform.Find("SpaceShip").transform.Find("WeaponStandardHolder").gameObject.GetComponent<SimpleFire>();
        }
        else
        {
            this.standardWeapon = transform.Find("ProjectileCreator").GetComponent<SimpleFire>();
        }
        this.energyWeapon = null;
        this.explosiveWeapon = null;
    }
}
