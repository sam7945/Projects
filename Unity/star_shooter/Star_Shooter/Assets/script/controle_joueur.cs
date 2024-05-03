using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class controle_joueur : MonoBehaviour
{
    public float vitesse;
    public Boundary boundary;
    public float rotationVaisseau;
    public Rigidbody laserJoueur;
    public Transform canonLaser;
    public float vitesseTir;
    public Rigidbody lumiereLaser;
    public float frequenceTir;
    float tirSuivant;
    public Canvas canvasGameOver;
    public Button boutonRecommencer;
    public Button boutonMenu;
    public Text textGameOver;

    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver = canvasGameOver.GetComponent<Canvas>();
        boutonMenu = boutonMenu.GetComponent<Button>();
        boutonRecommencer = boutonRecommencer.GetComponent<Button>();
        textGameOver = textGameOver.GetComponent<Text>();
        canvasGameOver.enabled = false;
        boutonMenu.enabled = false;
        boutonRecommencer.enabled = false;
        textGameOver.enabled = false;
    }
    private void OnDestroy()
    {
        canvasGameOver.enabled = true;
        boutonMenu.enabled = true;
        boutonRecommencer.enabled = true;
        textGameOver.enabled = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > tirSuivant)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            tirSuivant = Time.time + frequenceTir;
            Rigidbody munitionLaser;
            munitionLaser = Instantiate(laserJoueur, canonLaser.position, canonLaser.rotation) as Rigidbody;
            munitionLaser.AddForce(canonLaser.forward * vitesseTir);
            Rigidbody lumiereParentee;
            lumiereParentee = Instantiate(lumiereLaser, canonLaser.position, canonLaser.rotation) as Rigidbody;
            lumiereParentee.AddForce(canonLaser.forward * vitesseTir);
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float deplacementHorizontal = Input.GetAxis("Vertical");
        float deplacementVertical = Input.GetAxis("Horizontal");
        Vector3 mouvement = new Vector3(-deplacementHorizontal, 0, deplacementVertical);
        GetComponent<Rigidbody>().velocity = mouvement * vitesse;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.x * -rotationVaisseau);
    }
}
