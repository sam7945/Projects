using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_laser : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionJoueur;

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
}
