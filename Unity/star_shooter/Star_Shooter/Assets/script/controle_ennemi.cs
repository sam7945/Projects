using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle_ennemi : MonoBehaviour
{
    public float vitesseEnnemi;
    Rigidbody rigidbodyEnnemi;
    public Rigidbody munitionEnnemie;
    public Transform laserEnnemie1;
    public Transform laserEnnemie2;
    public Transform laserEnnemie3;
    public Transform laserEnnemie4;
    public Rigidbody lumiereLaserEnnemi;
    public float cadenceTirEnnemi = 0.5f;
    float tirSuivantEnnemi = 0.5f;
    public GameObject explosionJoueur;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyEnnemi = GetComponent<Rigidbody>();
        rigidbodyEnnemi.velocity = transform.forward * -1*vitesseEnnemi;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ennemi")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(explosionJoueur, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tirSuivantEnnemi) 
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            tirSuivantEnnemi = Time.time + cadenceTirEnnemi;

            Rigidbody lumiereParentee1;
            Rigidbody laserInstance1;
            laserInstance1 = Instantiate(munitionEnnemie, laserEnnemie1.position, laserEnnemie1.rotation) as Rigidbody;
            laserInstance1.AddForce(laserEnnemie1.forward * 2000);
            lumiereParentee1 = Instantiate(lumiereLaserEnnemi, laserEnnemie1.position, laserEnnemie1.rotation) as Rigidbody;
            lumiereParentee1.AddForce(laserEnnemie1.forward * 2000);

            Rigidbody lumiereParentee2;
            Rigidbody laserInstance2;
            laserInstance2 = Instantiate(munitionEnnemie, laserEnnemie2.position, laserEnnemie2.rotation) as Rigidbody;
            laserInstance2.AddForce(laserEnnemie2.forward * 2000);
            lumiereParentee2 = Instantiate(lumiereLaserEnnemi, laserEnnemie2.position, laserEnnemie2.rotation) as Rigidbody;
            lumiereParentee2.AddForce(laserEnnemie2.forward * 2000);

            Rigidbody lumiereParentee3;
            Rigidbody laserInstance3;
            laserInstance3 = Instantiate(munitionEnnemie, laserEnnemie3.position, laserEnnemie3.rotation) as Rigidbody;
            laserInstance3.AddForce(laserEnnemie3.forward * 2000);
            lumiereParentee3 = Instantiate(lumiereLaserEnnemi, laserEnnemie3.position, laserEnnemie3.rotation) as Rigidbody;
            lumiereParentee3.AddForce(laserEnnemie3.forward * 2000);

            Rigidbody lumiereParentee4;
            Rigidbody laserInstance4;
            laserInstance4 = Instantiate(munitionEnnemie, laserEnnemie4.position, laserEnnemie4.rotation) as Rigidbody;
            laserInstance4.AddForce(laserEnnemie4.forward * 2000);
            lumiereParentee4 = Instantiate(lumiereLaserEnnemi, laserEnnemie4.position, laserEnnemie4.rotation) as Rigidbody;
            lumiereParentee4.AddForce(laserEnnemie4.forward * 2000);

        }
    }
}
