using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class GrenadeProjectile : MonoBehaviour
{
    public static float speed = 32.0f;
    public static float ceilling = 300.0f;
    public static float floor = -40.0f;
    public static float damage = 15.0f;

    public Vector3 direction;

    Explosion explosion;
    SphereCollider sphereCollider;
    private bool isExploding;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        explosion = gameObject.GetComponent<Explosion>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != null && !isExploding)
        {
            transform.position +=
                direction * speed * Time.deltaTime;
        }

        if (transform.position.y > ceilling)
        {
            Debug.Log("Destroyed shot");
            Destroy(gameObject);
        }

        if (transform.position.y < floor)
        {
            Debug.Log("Destroyed shot");
            Destroy(gameObject);
        }


    }

    IEnumerator GrowCollider(Vector3 originalSize, Vector3 targetSize)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            // Calculez le facteur d'interpolation entre 0 et 1 en fonction du temps écoulé
            float t = elapsedTime / 1f;

            // Interpole la taille actuelle du SphereCollider vers la taille cible
            Vector3 newSize = Vector3.Lerp(originalSize, targetSize, t);

            // Mettez à jour la taille du SphereCollider
            sphereCollider.transform.localScale = newSize;

            // Mettez à jour la taille du SphereCollider utilisé pour la détection de collision
            float newRadius = Mathf.Lerp(originalSize.x, targetSize.x, t);
            sphereCollider.radius = newRadius;

            // Augmentez le temps écoulé
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Assurez-vous que la taille finale est définie explicitement
        sphereCollider.transform.localScale = targetSize;
        sphereCollider.radius = targetSize.x;
    }

    IEnumerator WaitAndDestroy()
    {
        explosion.explosion.transform.localScale = new Vector3(1.28f * 2, 1.28f * 2, 1.28f * 2);
        isExploding = true;
        meshRenderer.enabled = false;
        explosion.ActivateExplosion(true,Constants.EXPLOSION);
        sphereCollider.radius *= 4;
        Vector3 originalSize = sphereCollider.transform.localScale;
        Vector3 targetSize = originalSize * 4f;
        StartCoroutine(GrowCollider(originalSize, targetSize));
        yield return new WaitForSeconds(1f);
        isExploding = false;
        Destroy(gameObject);
    }

    public static void CollisionAction(GameObject obj)
    {

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.GetComponentInParent<Health>() != null && col.gameObject.GetComponentInParent<SpaceShip>() == null)
        {
            if (!isExploding)
                StartCoroutine(WaitAndDestroy());

            col.gameObject.GetComponentInParent<Health>().applyDmg(damage);

            if (col.gameObject.GetComponentInParent<Health>()._lifePoints <= 0)
                Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
