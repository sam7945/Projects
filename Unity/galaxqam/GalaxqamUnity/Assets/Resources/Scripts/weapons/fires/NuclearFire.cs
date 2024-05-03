using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearFire : MonoBehaviour, IFire
{
    public GameObject nuclearProjectile;
    public AudioClip nuclearSound;
    public AudioSource audioSource;
    private int munition = 0; //10;

    public int Munition => munition;
    
    private int MunitionsAjoute = 1;
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute;
    public int DefaultMunitionAmount => 10;
    public bool isPlaying => audioSource.isPlaying;



    public Transform nuclearHolder;
    public float holderYScale = 2;
    public float holderMaxScale = 0.5f;
    public Vector3 baseHolderPos;


    void Start()
    {
        nuclearSound = (AudioClip)Resources.Load("Sounds/WeaponNuclearFull", typeof(AudioClip));
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = nuclearSound;
        nuclearProjectile = (GameObject)Resources.Load("Prefabs/WeaponNuclearLauncherProjectile",
                typeof(GameObject));
        audioSource.playOnAwake = false;


        nuclearHolder = GameObject.Find("SpaceShip").transform.Find("SpaceShip").transform.Find("WeaponExplosionHolder").transform.Find("WeaponNuclearLauncher");
        baseHolderPos = nuclearHolder.transform.localScale;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (nuclearHolder.transform.localScale.y >= holderMaxScale)
                nuclearHolder.transform.localScale -= new Vector3(0, holderYScale * Time.deltaTime, 0);
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            nuclearHolder.transform.localScale = baseHolderPos;
        }
    }

    public void fire()
    {
        GameObject clone = Instantiate(nuclearProjectile, transform.position + new Vector3(0, 3, 0), transform.rotation);
        if (transform.GetComponentInParent<Enemy>() != null)
        {
            clone.GetComponent<NuclearProjectile>().direction = Vector3.down;
        }
        else
        {
            //clone.GetComponent<NuclearProjectile>().direction = Vector3.up;
        }
        audioSource.Play();
        munition--;
    }

    public void addMunition(int munition)
    {
        this.munition += munition;
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
