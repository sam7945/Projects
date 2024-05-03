using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauMovement : MonoBehaviour
{
    public float verticalSpeed = 0.2f; // La vitesse du mouvement vertical
    public float horizontalAmplitude = 0.6f; // L'amplitude du mouvement horizontal
    public float horizontalFrequency = 0.4f; // La fréquence du mouvement horizontal

    private Vector3 initialPosition;
    private float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        timeOffset = Random.Range(0f, 0.3f * Mathf.PI); // Décalage aléatoire pour les vaisseaux
    }

    // Update is called once per frame
    void Update()
    {
        // Mouvement vertical (rotation autour de l'axe Y)
        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * 0.5f; // 2f est l'amplitude du mouvement vertical
        transform.rotation = Quaternion.Euler(verticalOffset, 0f, 0f);

        // Mouvement horizontal (translation le long de l'axe X)
        float horizontalOffset = Mathf.Sin((Time.time + timeOffset) * horizontalFrequency) * horizontalAmplitude;
        transform.position = initialPosition + new Vector3(horizontalOffset, 0f, 0f);
    }
}
