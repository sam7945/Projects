using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Cette classe fait gestion du GameObject AmmoExplosive
//
public class NuclearProjectile : MonoBehaviour
{
    public static float speed = 40.0f;

    // �tablir un plafond o� l'on va d�truire l'objet pour ne pas avoir 10000
    // projectile dans la sc�ne qui ne servent � rien...
    public static float ceilling = 300.0f;

    public static float floor = -40.0f;

    public static float damage = 175.0f;

    public Vector3 direction;

    private Transform startTransform;
    private Transform endTransform;
    private Transform controlPoint1;
    private Transform controlPoint2;
    private static float duration = 1.2f;
    private float startTime;
    private bool isMoving = true;
    Explosion explosion;
    private bool isExploding = false;
    SphereCollider sphereCollider;
    MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform;
        endTransform = new GameObject().transform;
        startTime = Time.time;
        controlPoint1 = new GameObject().transform;
        controlPoint2 = new GameObject().transform;
        explosion = gameObject.GetComponent<Explosion>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();

        


        // Calcule la position du milieu de l'écran
        Vector3 screenMiddle = new Vector3(Screen.width / 2, Screen.height / 1.5f, 0f);

        // Convertit la position de l'écran en position dans l'espace du monde
        Vector3 endPosition = Camera.main.ScreenToWorldPoint(screenMiddle);
        endPosition.z = -1.16f;

        // Attribue la position du milieu de l'écran à endTransform
        endTransform.position = endPosition;


        // Calcule la distance entre la position de départ et d'arrivée
        float distance = Vector3.Distance(startTransform.position, endPosition);

        // Calcule la direction de la trajectoire
        Vector3 direction = (endPosition - startTransform.position).normalized;

        // Calcule les positions des points de contrôle
        controlPoint1.position = GetRandomPointInBounds(startTransform.position, endPosition);
        controlPoint2.position = GetRandomPointInBounds(startTransform.position, endPosition);


    }

    // Génère un point aléatoire à l'intérieur d'une boîte englobante définie par deux points
    Vector3 GetRandomPointInBounds(Vector3 minPoint, Vector3 maxPoint)
    {
        float x = Random.Range(minPoint.x, maxPoint.x);
        float y = Random.Range(minPoint.y, maxPoint.y);
        float z = Random.Range(minPoint.z, maxPoint.z);
        return new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Calcule le temps écoulé depuis le début de la trajectoire
            float elapsedTime = Time.time - startTime;

            //// Calcule la distance parcourue à partir du temps écoulé et de la vitesse
            //float distanceCovered = elapsedTime * speed;

            // Calcule le facteur d'interpolation entre 0 et 1 en fonction de la distance parcourue
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpole les positions de contrôle
            Vector3 p1 = Vector3.Lerp(startTransform.position, controlPoint1.position, t);
            Vector3 p2 = Vector3.Lerp(controlPoint1.position, controlPoint2.position, t);
            Vector3 p3 = Vector3.Lerp(controlPoint2.position, endTransform.position, t);

            // Interpole les positions des points de contrôle pour obtenir la position finale de l'objet
            Vector3 pFinal1 = Vector3.Lerp(p1, p2, t);
            Vector3 pFinal2 = Vector3.Lerp(p2, p3, t);

            // Interpole la position finale de l'objet
            Vector3 finalPosition = Vector3.Lerp(pFinal1, pFinal2, t);

            // Calcule la distance restante à parcourir
            float remainingDistance = Vector3.Distance(transform.position, endTransform.position);

            // Calcule la vitesse nécessaire pour atteindre la destination après la durée spécifiée
            float requiredSpeed = remainingDistance / (duration - elapsedTime);

            // Déplace l'objet vers la position finale avec une vitesse constante indépendante de la frame rate
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, requiredSpeed * Time.deltaTime);

            // Si l'objet a atteint la position finale, enregistre le temps de début pour la prochaine trajectoire
            if (t >= 1f)
            {
                isMoving = false;
                startTime = Time.time;

            }
        }
        else {

            StartCoroutine(WaitAndDestroy());
        }
    }
    IEnumerator WaitAndDestroy() {
        explosion.explosion.transform.localScale = new Vector3(10,10,10);
        isExploding = true;
        meshRenderer.enabled = false;
        explosion.ActivateExplosion(false,null);
        sphereCollider.radius *= 10;
        Vector3 originalSize = sphereCollider.transform.localScale;
        Vector3 targetSize = originalSize * 10f;
        StartCoroutine(GrowCollider(originalSize, targetSize));
        yield return new WaitForSeconds(1f);
        isExploding = false;
        Destroy(endTransform.gameObject);
        Destroy(controlPoint1.gameObject);
        Destroy(controlPoint2.gameObject);
        Destroy(gameObject);
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

    public static void CollisionAction(GameObject ammo)
    {
        //Faire quelque chose

    }

    void OnTriggerEnter(Collider col)
    {
        if (isExploding)
        {
            // Calculer la distance entre l'objet et le centre de l'explosion
            Vector3 explosionCenter = transform.position;
            float distance = Vector3.Distance(col.transform.position, explosionCenter);

            float normalizedDistance = Mathf.Clamp01(distance / sphereCollider.radius / 18);
            float adjustedDamage = damage * ((1f - normalizedDistance));


            if (col.gameObject.GetComponentInParent<Health>() != null && col.gameObject.GetComponentInParent<SpaceShip>() == null)
            {
                col.gameObject.GetComponentInParent<Health>().applyDmg(adjustedDamage);
                if (col.gameObject.GetComponentInParent<Health>()._lifePoints <= 0)
                    Destroy(col.gameObject.transform.parent.gameObject);
            }
            else
            {
                //Destroy(col.gameObject); //Si décommenté, détruit les projectile
            }
        }
    }
}
