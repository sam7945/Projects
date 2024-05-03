using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFire : MonoBehaviour, IFire
{
    public GameObject grenadeProjectile;
    public AudioClip grenadeSound;
    public AudioSource audioSource;
    private int munition = 0; //10;

    public int Munition => munition;
    private int MunitionsAjoute = 10;
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute;
    public int DefaultMunitionAmount => 10;
    public bool isPlaying => audioSource.isPlaying;



    public Transform grenadeHolder;
    public float holderYScale = 2;
    public float holderMaxScale = 0.75f;
    public Vector3 baseHolderPos;
    void Start()
    {
        grenadeSound = (AudioClip)Resources.Load("Sounds/GrenadeLauncher", typeof(AudioClip));
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = grenadeSound;
        grenadeProjectile = (GameObject)Resources.Load("Prefabs/WeaponGrenadeLauncherProjectile",
                typeof(GameObject));
        audioSource.playOnAwake = false;

        grenadeHolder = GameObject.Find("SpaceShip").transform.Find("SpaceShip").transform.Find("WeaponExplosionHolder").transform.Find("WeaponGrenadeLauncher");
        baseHolderPos = grenadeHolder.transform.localScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (grenadeHolder.transform.localScale.y >= holderMaxScale)
                grenadeHolder.transform.localScale -= new Vector3(0, holderYScale * Time.deltaTime, 0);
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            grenadeHolder.transform.localScale = baseHolderPos;
        }
    }

    public void fire()
    {
        munition--;
        GameObject clone = Instantiate(grenadeProjectile, transform.position + new Vector3(0, 3, 0), transform.rotation);
        if (transform.GetComponentInParent<Enemy>() != null)
        {
            clone.GetComponent<GrenadeProjectile>().direction = Vector3.down;
        }
        else
        {
            clone.GetComponent<GrenadeProjectile>().direction = Vector3.up;
        }
        audioSource.Play();

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
