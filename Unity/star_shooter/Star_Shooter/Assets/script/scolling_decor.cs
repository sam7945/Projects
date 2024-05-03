using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scolling_decor : MonoBehaviour
{
    public float vitesseDefilement;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * vitesseDefilement;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
