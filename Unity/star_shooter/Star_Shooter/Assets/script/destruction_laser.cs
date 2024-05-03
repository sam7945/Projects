using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction_laser : MonoBehaviour
{
    public float dureeDestruction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dureeDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
