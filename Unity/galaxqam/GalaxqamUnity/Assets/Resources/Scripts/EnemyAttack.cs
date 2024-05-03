using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Cette classe fait la gestion du déplacement du ennemi
//
public class EnemyAttack : MonoBehaviour
{

    GameObject box;
    GameObject spaceship;
    BoxCollider trigger;
    public string parentName;
    
    float lowerTeleportPoint;
    float higherTeleportPoint;
    bool detached;
    bool teleport;
    bool specialMovement = false;
    public WeaponControl weaponControl;
    float counter = 0;

    private bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        if (parentName != null)
        {
            Invoke("Detach", 1);
        }

        weaponControl = gameObject.AddComponent<WeaponControl>();

    }


    // Update is called once per frame
    void Update()
    {
        if (detached == true)
        {
            Trajectory();
            if (!teleport) {
                
                 counter += Time.deltaTime;
                 if (counter > 1.5f)
                 {
                    counter = 0;
                    if (weaponControl != null)
                    {
                    weaponControl.FireStandardWeapon();
                    }
                 }
            }
        } else {
            if (attack == true)
            {
                counter += Time.deltaTime;
                if (counter > Random.Range(3.0f, 16.0f))
                 {
                    counter = 0;
                    SetAttack(false);
                    if (weaponControl != null)
                    {
                        weaponControl.FireStandardWeapon();
                    }
                 } 
            }
        }
    }

    // Faire que l'ennemi se détache de sa formation
    public void Detach()
    {
        trigger = box.AddComponent<BoxCollider>();
        trigger.size = new Vector3(0.5f, 0.5f, 0.5f);
        transform.parent = null;
        detached = true;
        Invoke("SetTrigger", 4);
        specialMovement = (Random.value < Constants.probabilitySpecialMovement);
    }

    // Faire le déplacement du ennemi
    public void Trajectory()
    {
        if (specialMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, spaceship.transform.position,
                Constants.specialMovementSpeed * Time.deltaTime);
            if(transform.position.y < 20.0f)
            {
                specialMovement = false;
                transform.position = Vector3.MoveTowards(transform.position, box.transform.position,
                    Constants.specialMovementSpeed * Time.deltaTime);
                teleport = true;
            }
        }
        else if (teleport == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, box.transform.position,
                Constants.attackSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, box.transform.position) < 0.05f) {
                Attach();
            }
        }
        else if (transform.position.y <= -10)
        {
            transform.position = new Vector3(transform.position.x, 200, 0);
            transform.rotation = Quaternion.identity;
            teleport = true;
            
        }
        else
        {
            transform.position += Vector3.down * 
                Constants.attackSpeed * Time.deltaTime;
            
            
        }
    }

    // Attache l'ennemi à sa position relative dans la formation
    void Attach()
    {
        transform.SetParent(box.transform);
        transform.localPosition = Vector3.zero;
        teleport = false;
        detached = false;
        
    }

    // Met à jour le trigger
    void SetTrigger()
    {
        trigger.isTrigger = true;
    }

    // Gère la collision avec sa boîte
    void OnTriggerEnter(Collider target)
    {
        
        if (target.gameObject.name == parentName && detached)
        {
            
            Attach();
        }
    }

    // Définit la boîte qui contient l'ennemi
    public void SetParentBoxEnemy()
    {
        parentName = gameObject.transform.parent.name;
        spaceship = GameObject.Find("SpaceShip");
        box = GameObject.Find(parentName);
        teleport = false;
        detached = false;
        
    }

    // Retourne si c'est détache
    public bool IsDetached()
    {
        return detached == true;
    }

    // Définit si l'ennemi attaque
    public void SetAttack(bool condition)
    {
        attack  = condition;
    }

    // Retourne si attaque
    public bool IsAttacking()
    {
        return attack == true;
    }
}