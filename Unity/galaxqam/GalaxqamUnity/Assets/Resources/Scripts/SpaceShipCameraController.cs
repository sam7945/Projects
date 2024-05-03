using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCameraController : MonoBehaviour
{
    public Camera mainCam;
    public Camera perspectiveCam;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {


    }



    public void ToggleCam(){
        if(mainCam.enabled){
            mainCam.enabled = false;
            perspectiveCam.enabled = true;
        } else {
            mainCam.enabled = true;
            perspectiveCam.enabled = false;
        }
    }
    void Init(){

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        perspectiveCam = transform.Find("CameraController").
            Find("Camera").GetComponent<Camera>();
        mainCam.enabled = true;
        perspectiveCam.enabled = false;
    }
}
