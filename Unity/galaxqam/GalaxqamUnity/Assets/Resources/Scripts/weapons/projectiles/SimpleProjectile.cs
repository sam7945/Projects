using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class SimpleProjectile : MonoBehaviour
{
    public static float speed = 32.0f;

    // �tablir un plafond o� l'on va d�truire l'objet pour ne pas avoir 10000
    // projectile dans la sc�ne qui ne servent � rien...
    public static float ceilling = 300.0f;

    public static float floor = -40.0f;

    public static float damage = 33.0f;

    public Vector3 direction;
    private bool isExploding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction != null)
        {
            transform.position +=
                direction * speed * Time.deltaTime;
        }

        if (transform.position.y > ceilling)
        {
            //Debug.Log("Destroyed shot");
            Destroy(gameObject);
        }

        if (transform.position.y < floor)
        {
            //Debug.Log("Destroyed shot");
            Destroy(gameObject);
        }


    }

    public static void CollisionAction(GameObject ammo)
    {
        //Faire quelque chose

    }

    void OnTriggerEnter(Collider col)
    {

        if ((gameObject.GetComponent<SimpleProjectile>().direction == Vector3.down && col.gameObject.GetComponentInParent<Enemy>() != null))
            return;

        if (col.gameObject.GetComponentInParent<Health>() != null)
        {
            col.gameObject.GetComponentInParent<Health>().applyDmg(damage);

            if (col.gameObject.GetComponentInParent<Health>()._lifePoints <= 0)
                Destroy(col.gameObject.transform.parent.gameObject);

            Destroy(gameObject);

        }
        else
        {
            //Destroy(col.gameObject); //Si décommenté, détruit les projectile
        }

    }
}
