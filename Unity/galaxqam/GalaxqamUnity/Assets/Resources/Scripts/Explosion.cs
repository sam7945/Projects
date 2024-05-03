using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPrefab;
    public Transform[] children;
    public bool isExploding = false;

    public AudioClip explosionSound;
    public AudioSource audioSource;

    // L'intervalle entre l'apparition de chaque enfant de l'explosion
    public float interval = 0.1f;
    private float durationSound = 1.0f;

    // Start is called before the first frame update
    void Start () {
        Init();

        // On préfère faire l'initialisation dans une fonction pour garder les
        // fonctions héritée de MonoBehaviour plus "clean"
        // Détruire l'objet d'explosion après un certain délai
        //Destroy(explosion, 0.5f);
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.E)){
            explosion.transform.localScale = explosionPrefab.transform.localScale * 2;
            ActivateExplosion(true,Constants.EXPLOSION_VAISSEAU);

        }
    }

    public void ActivateExplosion(bool sound,string soundType){
        StartCoroutine(DisplayChild(sound,soundType));
    }
    void assignSound(string soundType) {
        switch (soundType)
        {
            case Constants.EXPLOSION:
                explosionSound = (AudioClip)Resources.Load("Sounds/Explosion", typeof(AudioClip));
                durationSound = 1.0f;
                break;
            case Constants.EXPLOSION_VAISSEAU:
                explosionSound = (AudioClip)Resources.Load("Sounds/ExplosionVaisseau", typeof(AudioClip));
                durationSound = 1.5f;
                break;
            default:
                explosionSound = (AudioClip)Resources.Load("Sounds/Explosion", typeof(AudioClip));
                durationSound = 1.0f;
                break;
        }

        
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = explosionSound;
        audioSource.volume = 1f;
        audioSource.playOnAwake = false;
        float newPitch = audioSource.clip.length / durationSound;
        audioSource.pitch = newPitch;

    }
    void Init(){
        // Charger le préfab depuis le dossier "Prefabs"
        explosionPrefab = Resources.Load<GameObject>("Prefabs/ExplosionSpaceShip");


        //instancier le préfab
        // Ici, il faut le lier à un gameobject, pour qu'il reste avec le
        // vaisseau. On pourrait aussi stopper les contrôles pour que je joueur
        // ne puisse pas contrôler le vaisseau lors de l'explosion.
        explosion = Instantiate(explosionPrefab, transform);
        //explosion = Instantiate(explosionPrefab,
        //        transform.position, Quaternion.identity) as GameObject;

        // Récupérer les enfants de l'explosion
        children = explosion.GetComponentsInChildren<Transform>();

        for (int i = 1; i < children.Length; i++) {
            children[i].gameObject.SetActive(false);
        }

    }

    IEnumerator DisplayChild(bool sound,string soundType) {
        isExploding = true;
        if (sound){
            assignSound(soundType);
            audioSource.Play();
        }




        for (int i = 1; i < children.Length; i++) {

            GameObject child = children[i].gameObject;
            //Debug.Log(child);
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(interval);
            child.gameObject.SetActive(false);
        }
        isExploding = false;

    }



}
