using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle_meteorite : MonoBehaviour
{
    Rigidbody rigidbodyMeteorite;
    public float vitesseMeteorite;
    public Vector3 eulerAngleVelocity;
    public GameObject explosion;
    public GameObject explosionJoueur;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMeteorite = GetComponent<Rigidbody>();
        rigidbodyMeteorite.velocity = -transform.forward * vitesseMeteorite;

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
        if (other.tag == "Player")
        {
            Instantiate(explosionJoueur, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rigidbodyMeteorite.MoveRotation(rigidbodyMeteorite.rotation * deltaRotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
