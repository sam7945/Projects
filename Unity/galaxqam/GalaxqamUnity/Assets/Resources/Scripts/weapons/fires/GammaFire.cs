using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaFire : MonoBehaviour, IFire
{
    public GameObject gammaProjectile;
    public AudioClip gammaSound;
    public AudioSource audioSource;
    public GameObject clone;
    public GameObject spaceship;
    public Transform gammaHolder;

    public float xScale = 0.5f;
    public float yScale = 20;
    public float maxScale = 5;

    public Vector3 baseHolderPos;
    public float holderYScale = 2;
    public float holderMaxScale = 1.5f;

    private int munition = 0; //10;
    public int Munition => munition;
    public int DefaultMunitionAmount => 10;

    private int MunitionsAjoute = 10;
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute;
    public bool isPlaying => audioSource.isPlaying;

    void Start()
    {
        gammaSound = (AudioClip)Resources.Load("Sounds/WeaponRayonGama", typeof(AudioClip));
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = gammaSound;
        gammaProjectile = (GameObject)Resources.Load("Prefabs/WeaponGammaProjectile",
                typeof(GameObject));
        spaceship = GameObject.Find("SpaceShip");
        gammaHolder = spaceship.transform.Find("SpaceShip").transform.Find("WeaponEnergyHolder").transform.Find("WeaponGamma");
        baseHolderPos = gammaHolder.transform.localScale;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (munition > 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                clone.gameObject.transform.position = gammaHolder.transform.position;
                if (clone.gameObject.transform.localScale.y <= maxScale)
                    clone.gameObject.transform.localScale += new Vector3(xScale * Time.deltaTime, yScale * Time.deltaTime, 0);

                if (gammaHolder.transform.localScale.y <= holderMaxScale)
                    gammaHolder.transform.localScale += new Vector3(0, holderYScale * Time.deltaTime, 0);
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                gammaHolder.transform.localScale = baseHolderPos;
                munition--;
            }
        }
    }

    public void fire()
    {

        clone = Instantiate(gammaProjectile, transform.position + new Vector3(0, 2, 0), transform.rotation);
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
