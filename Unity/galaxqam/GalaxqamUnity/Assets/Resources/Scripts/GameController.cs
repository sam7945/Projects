using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO DO: Utilisation du verticalSapce et horizontalSpace pour laisser des espaces vides, Utilisation de constantes


public class GameController : MonoBehaviour
{
    FormationController formationController;

    // Start is called before the first frame update
    void Start()
    {
        formationController = gameObject.GetComponent<FormationController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

}
