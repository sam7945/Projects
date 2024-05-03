using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{

/*
    public float startPositionY=0;

    public int rowNumber=3;
    public int columnNumber=2;

    public float enemyVerticalSpeed= 3.0f;
    public float enemyHorizontalSpeed= 5.0f;

    public float sideLimits = 50.0f;

    public int direction= 0;
    public float previousY = 0;
    public float y=5;

    public Transform controllerPos;
    public GameObject enemyMovementControler;

    public GameObject enem;
    public GameObject[,] tmp;

    // Je ne comprend pas le premier " " et j'ai corriger les nom de prefabs de
    // ennemy a enemy...
    private string[] enemiesName={" ","Enemy1","Enemy2","Enemy3","Enemy4","Enemy5","Enemy6"};
    private int[,] matrice;

    float timePassed = 11f;
    public float time=0;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovementControler=GameObject.Find("EnemyMovementController");
        controllerPos = enemyMovementControler.GetComponent(typeof(Transform)) as Transform;
        startPositionY=controllerPos.position.y;
        generateMatrix();
        initialiseEnemyFormation();
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemyFormation();

        timePassed += Time.deltaTime;
        if(timePassed > time)
        {
            EnemyMovement a=tmp[(int)Random.Range(0, rowNumber),(int)Random.Range(0, columnNumber)].GetComponent("EnemyMovement") as EnemyMovement;
            a.attack();
            timePassed=0;
            //do something
        }
    }

    //Genere une matrice de nombre random de 1 à 6 symetrique pourait servir pour initialisation de la formation
    public void generateMatrix(){

        int[,] matrix= new int[rowNumber, columnNumber];

        for(int i=0;i<rowNumber;i++){
            for(int j=0;j<columnNumber/2+1;j++){
                matrix[i,j]= (int)Random.Range(1, 7);
                matrix[i,columnNumber-j-1]= matrix[i,j];
            }
        }
        matrice=matrix;
    }

    public void initialiseEnemyFormation(){

        float currentX= 0;
        float currentY= startPositionY;
        tmp=new GameObject[rowNumber,columnNumber];
        GameObject enemyMovementControler=GameObject.Find("EnemyMovementController");

        for(int i=0;i<rowNumber;i++){

            currentX= -15*(int)System.Math.Truncate((decimal)rowNumber/2)-15;

            for(int j=0;j< columnNumber;j++){

                GameObject empty=new GameObject("EnemyEmpty"+i.ToString()+","+j.ToString());

                empty.transform.SetParent(enemyMovementControler.transform);

                if(matrice[i,j]!=0){

            Debug.Log("pt "+transform.position);
                    GameObject tmpEnemy=Instantiate((GameObject)Resources.Load("Prefabs/"+enemiesName[matrice[i,j]],typeof(GameObject)));
                    // Ajout des scripts automatiquement (ou tu peux les ajouter
                    // au prefabs si tu veux.
                    tmpEnemy.AddComponent(typeof(EnemyMovement));

                    tmpEnemy.transform.SetParent(empty.transform);
                    empty.transform.position=new Vector3(currentX,currentY,0);
                    tmp[i,j]=tmpEnemy;
                }
                currentX+= 15;

            }
            currentY-=11;
        }
    }

    public void moveEnemyFormation(){

        if(direction==0){
            controllerPos.position += Vector3.right*enemyHorizontalSpeed*Time.deltaTime;

            if(controllerPos.position.x > sideLimits){
                direction=2;
                previousY = controllerPos.position.y;
            }
        } else if(direction==1){
            controllerPos.position += Vector3.left*enemyHorizontalSpeed*Time.deltaTime;

            if(controllerPos.position.x < -sideLimits){
                direction=2;
                previousY = controllerPos.position.y;
            }
        } else if(direction==2){
            if(controllerPos.position.y>-15){
                controllerPos.position += Vector3.down*enemyVerticalSpeed*Time.deltaTime;
            } else{
                if (controllerPos.position.x<0){
                    direction=0;
                }else if (controllerPos.position.x>0){
                    direction=1;
                }
            }


            if(controllerPos.position.y < previousY-y ){
                if (controllerPos.position.x<0){
                    direction=0;
                }else if (controllerPos.position.x>0){
                    direction=1;
                }
            }
        }
    }

*/
}
