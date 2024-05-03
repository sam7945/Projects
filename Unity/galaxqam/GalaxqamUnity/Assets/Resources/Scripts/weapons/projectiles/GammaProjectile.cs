using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class GammaProjectile : MonoBehaviour
{
    public static float speed = 32.0f;
    public static float ceiling = 300.0f;
    public static float floor = -40.0f;
    public static float damage = 5.0f;

    public GameObject spaceship;

    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("SpaceShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != null)
        {
            transform.position +=
                direction * speed * Time.deltaTime;
        }


        if (transform.position.y > ceiling)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < floor)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyUp(KeyCode.Z) || spaceship.GetComponent<Health>()._lifePoints <= 0)
        {
            direction = Vector3.up;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponentInParent<Health>() != null && col.gameObject.GetComponentInParent<SpaceShip>() == null)
        {
            col.gameObject.GetComponentInParent<Health>().applyDmg(damage);
            if (col.gameObject.GetComponentInParent<Health>()._lifePoints <= 0)
                Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
