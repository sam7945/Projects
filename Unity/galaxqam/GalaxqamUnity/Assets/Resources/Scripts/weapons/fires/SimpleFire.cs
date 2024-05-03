using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFire : MonoBehaviour, IFire
{

    // Tout élément est un "GameObject", ici, nous allons
    // plus tard mettre un projectile, une simple capsule pour
    // servir d'exemple
    //
    // En mettant la variable public, nous voyons dans "UNITY" la variable dans
    // l'inspecteur.
    public GameObject projectile;

    // vous ne verrez pas la variable projectile2 dans l'inspecteur
    GameObject projectile2;

    // Un transform est un composant qui contient la position, la rotation et le
    // scale. Ici, nous allons lier le "générateur" pour avoir sa position
    //public Transform transform;

    // Ici, un "AudioClip" est le fichier "wav", cela peut être d'autre format
    // audio.
    public AudioClip laserSound;

    // Le AudioSource est le lecteur audio qui permet de jouer l'audio clip
    public AudioSource audioSource;

    private int munition = Int32.MaxValue;

    public int Munition => munition;

    private int MunitionsAjoute = 0; // Pour que ça compile
    public int MUNITIONS_A_AJOUTER => MunitionsAjoute; // Pour que ça compile
    public int DefaultMunitionAmount => Int32.MaxValue;
    public bool isPlaying => audioSource.isPlaying;

    public bool isEmpty => throw new NotImplementedException();

    void Start()
    {
        // La classe Ressource permet de naviguer dans le fichier du jeu. Ici,
        // nous allons dans le fichier /Resources/Sounds/ pour aller chercher le
        // fichier "publicLaserShot" que j'ai créer à l'aide d'un fichier libre de
        // droit de "9mm" et que j'ai modifier avec des effets sonores (wha wha
        // et  phaser).
        laserSound = (AudioClip)Resources.Load("Sounds/WeaponLaserShot", typeof(AudioClip));
        // Je créer un composant AudioSource attacher au générateur Projectile
        // Creator
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;


        // Nous attachons le fichier wave dans le AudioSource
        audioSource.clip = laserSound;
        audioSource.playOnAwake = false;
        // Nous assignons la variable projectile à un Prefabs, un object de jeux
        // complet que nous avons créer dans UNITY
        projectile = (GameObject)Resources.Load("Prefabs/Projectile",
                typeof(GameObject));

        // Nous allons chercher le composant Transform du GameObject auquel est
        // rataché ce script.
        //transform = gameObject.GetComponent(typeof(Transform)) as Transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // la fonction qui est appellé dans le controlleur du vaisseau
    public void fire()
    {
        // nous créons un projectile à l'endroit oû le créateur est.
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        if (transform.GetComponentInParent<Enemy>() != null)
        {
            clone.GetComponent<SimpleProjectile>().direction = Vector3.down;
        }
        else
        {
            //Vector3 position = clone.GetComponent<SimpleProjectile>().transform.position;
            //clone.GetComponent<SimpleProjectile>().transform.position = position + new Vector3(3.0f, -0.5f, 0); // utilisé cette méthode pour changer la position initiale des projectiles par arme
            clone.GetComponent<SimpleProjectile>().direction = Vector3.up;
        }
        audioSource.Play();
    }
    public void addMunition(int munition)
    {
        //Les munitions sont infinie pas besoin d'en ajoutÃ© pour simple fire
    }
    public void resetMunitionAmount()
    {
        munition = DefaultMunitionAmount;
    }
}
