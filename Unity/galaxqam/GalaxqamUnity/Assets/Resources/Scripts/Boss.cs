using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject mainBody;
    public GameObject arm;
    public GameObject cannon;
    public int nbSegments = 7;
    public Transform[] segments;
    public Vector3[] initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiation(-2.919815f, 0.4980004f, 0.4980004f, true);
        Instantiation(-2.591273f, 2.992242f, 0.4529427f, true);
        Instantiation(-2.604682f, 5.278631f, 0.5250813f, true);
        Instantiation(2.93518f, 0.4980004f, 0.4980004f, false);
        Instantiation(2.62675f, 2.992242f, 0.4529427f, false);
        Instantiation(2.552995f, 5.278631f, 0.5250813f, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Instantiation(float x, float y, float z, bool isLeft)
    {
        Vector3 spawnPosition = new Vector3(x,y,z);
        float segmentOffset = isLeft ? -0.3f : 0.3f;
        float canonOffset = isLeft ? -0.5f : 0.5f;
        Transform currentSegment = transform;
        arm.AddComponent<HingeJoint>();
        cannon.AddComponent<HingeJoint>();
        HingeJoint previousJoint = arm.GetComponent<HingeJoint>();
        //Instancier 8 segments de bras
        for (int i = 0; i < nbSegments; i++)
        {
            GameObject joint2 = Instantiate(arm, spawnPosition, Quaternion.identity);
            HingeJoint newJoint = joint2.GetComponent<HingeJoint>();
            newJoint.connectedBody = previousJoint.GetComponent<Rigidbody>();
            previousJoint = newJoint;
                //old code
            //joint2.transform.SetParent(currentSegment);
            //Pour positionner la nouvelle instance juste à coté
            spawnPosition.x += segmentOffset;
            if (i + 1 < nbSegments)
            {
                GameObject joint3 = Instantiate(cannon, spawnPosition, Quaternion.identity);
                joint3.transform.Rotate(0.095f,90.0f,-90.0f);
                newJoint = joint3.GetComponent<HingeJoint>();
                newJoint.connectedBody = previousJoint.GetComponent<Rigidbody>();
                previousJoint = newJoint;
                //old code
                //joint3.transform.SetParent(currentSegment);
                spawnPosition.x += canonOffset;
            }
        }
    }
}
