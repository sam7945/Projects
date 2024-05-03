using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongFire : MonoBehaviour, IFire
{
    public GameObject projectile;
    public AudioClip shortLaserSound;
    public AudioSource audioSource;
    public GameObject spaceship;
    public Transform shortHolder;

    public float xScale = 0.5f;
    public float yScale = 20;
    public float maxScale = 5;

    public Vector3 baseHolderPos;
    public float holderYScale = 2;
    public float holderMaxScale = 1.5f;

    public int munition = 0; // 15;
    public int Munition => munition;
    
    private int MunitionsAjoute = 12;
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute;
    public int DefaultMunitionAmount => 15;
    public bool isPlaying => audioSource.isPlaying;
    void Start()
    {
        shortLaserSound = (AudioClip)Resources.Load("Sounds/WeaponLongLaser", typeof(AudioClip));
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = shortLaserSound;
        projectile = (GameObject)Resources.Load("Prefabs/LongProjectile",
                    typeof(GameObject));

        spaceship = GameObject.Find("SpaceShip");
        shortHolder = spaceship.transform.Find("SpaceShip").transform.Find("WeaponEnergyHolder").transform.Find("WeaponLongLaser");
        baseHolderPos = shortHolder.transform.localScale;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (shortHolder.transform.localScale.y <= holderMaxScale)
                shortHolder.transform.localScale += new Vector3(0, holderYScale * Time.deltaTime, 0);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            shortHolder.transform.localScale = baseHolderPos;
        }
    }
    public void addMunition(int munition)
    {
        this.munition += munition;
    }
    public void fire()
    {
        munition--;
        GameObject clone = Instantiate(projectile, transform.position + new Vector3(0, 20, 0), transform.rotation);
        if (transform.GetComponentInParent<Enemy>() != null)
        {
            clone.GetComponent<LongProjectile>().direction = Vector3.down;
        }
        else
        {
            clone.GetComponent<LongProjectile>().direction = Vector3.up;
        }
        audioSource.Play();
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
