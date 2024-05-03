using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForceMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Pour l'ajout de force, le fixedUpdate est plus adapté
    void FixedUpdate()
    {
        // <- j, ^ i, v k, -> l
        Command();
    }

    void Init(){
        rb = gameObject.GetComponent<Rigidbody>();
        thrust = 10.0f;

    }

    void Command(){
        if(Input.GetKey(KeyCode.I)){
            rb.AddForce(Vector3.up * thrust);
        }
        if(Input.GetKey(KeyCode.J)){
            rb.AddForce(Vector3.left * thrust);
        }
        if(Input.GetKey(KeyCode.K)){
            rb.AddForce(Vector3.down * thrust);
        }
        if(Input.GetKey(KeyCode.L)){
            rb.AddForce(Vector3.right * thrust);
        }
    }
}
