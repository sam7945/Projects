using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFire : MonoBehaviour, IFire
{
    public GameObject machineProjectile;
    public AudioClip machineSound;
    public AudioSource audioSource;
    public float cadence = 0.1f;
    private float distanceTemp = 0.0f;
    private int munition = 0; //200;
    public int Munition => munition;

    private int MunitionsAjoute = 150;
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute;
    public int DefaultMunitionAmount => 200;
    public bool isPlaying => audioSource.isPlaying;



    public Transform machineHolder;
    private float rotationSpeed = 1000f;

    void Start()
    {
        machineSound = (AudioClip)Resources.Load("Sounds/WeaponMachineGun", typeof(AudioClip));
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = machineSound;
        machineProjectile = (GameObject)Resources.Load("Prefabs/WeaponMachineGunProjectile",
                typeof(GameObject));
        audioSource.playOnAwake = false;

        machineHolder = GameObject.Find("SpaceShip").transform.Find("SpaceShip").transform.Find("WeaponExplosionHolder").transform.Find("WeaponMachineGun");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            machineHolder.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
    public void addMunition(int nbMunition)
    {
        munition += nbMunition;
    }
    public void fire()
    {
        distanceTemp += Time.deltaTime;
        if (distanceTemp >= cadence)
        {
            distanceTemp = 0.0f;
            GameObject clone = Instantiate(machineProjectile, transform.position + new Vector3(0, 3, 0), transform.rotation);
            if (transform.GetComponentInParent<Enemy>() != null)
            {
                clone.GetComponent<MachineProjectile>().direction = Vector3.down;
            }
            else
            {
                clone.GetComponent<MachineProjectile>().direction = Vector3.up;
            }
            audioSource.Play();
            munition--;
        }
    }
    public void resetMunitionAmount()
    {
        munition = DefaultMunitionAmount;
    }

    public bool isEmpty
    {
        get
        {
            if (this.munition == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
