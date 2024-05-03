using UnityEngine;
using System.Collections.Generic;
 
 public class RandomSpawn : MonoBehaviour
 { 
    public GameObject ammoEnergy;

    public float sideLimits = 50.0f;
    public float timeSinceLastDrop = 0;
    public float dropInterval = 3.0f;
    private Vector3 position;

     void Start()
     {
        ammoEnergy = (GameObject)Resources.Load("Prefabs/AmmoEnergy",
                typeof(GameObject));     
     }
 
     void update(){
        Instantiate(ammoEnergy, transform.position, transform.rotation);
     }

     void spawnAmmoEnergy(){
        
     }
 }