using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class ShortProjectile : MonoBehaviour
{
    public static float speed = 32.0f;
    public static float ceilling = 300.0f;
    public static float floor = -40.0f;
    public static float damage = 33.0f;

    public Vector3 direction;

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
            Destroy(gameObject);
        }

        if (transform.position.y < floor)
        {
            Destroy(gameObject);
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
