using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody enemy;

    public Transform enemyPos;

    public Transform parentTrans;

    public bool isAttacking=false;
    public bool isBack=true;


    // Start is called before the first frame update
    void Start()
    {
        /*
        enemy=this.gameObject.GetComponent<Rigidbody> ();
        enemyPos = enemy.GetComponent(typeof(Transform)) as Transform;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(isAttacking==true && enemyPos.parent==null){
            enemyPos.position += Vector3.down*10*Time.deltaTime;
        }

        if(enemyPos.position.y<-25 && isAttacking==true){
            enemyPos.position = new Vector3(0,80,0);
            isAttacking=false;
            isBack=false;
        }

        if(isBack==false){
            enemyPos.position = Vector3.MoveTowards(enemyPos.position, parentTrans.position, 100*Time.deltaTime);
            if(enemyPos.position==parentTrans.position){
                enemyPos.transform.SetParent(parentTrans);
                isBack=true;
            }
        }
        */
    }

    public void attack(){
        /*
        if(enemyPos.parent != null){
            parentTrans= enemyPos.parent;
            enemyPos.parent = null;
            isAttacking=true;
        }
        */
    }
}
