using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Cette classe fait gestion de la création de la formation des ennemis
//
public class FormationController : MonoBehaviour
{

    CameraController camera;
    GameSettings settings;
    Formation formation;
    float nbPerRowMax = 12;
    float nbPerRowMin = 7;


    void Init(Constants.Creation crea)
    {
        formation = gameObject.GetComponent(typeof(Formation)) as Formation;

        if (crea == Constants.Creation.RANDOM)
        {
            formation.nbPerRowMax = nbPerRowMax;
            formation.nbPerRowMin = nbPerRowMin;
            formation.Creation();
        }
        else
        {
            formation.CreationFromFile();
        }
    }

    void Start()
    {
        Init(Constants.Creation.RANDOM); //Les constantes possibles sont FILE ou RANDOM
        camera = gameObject.AddComponent<CameraController>();
        StartCoroutine(DetachOverTime());
        StartCoroutine(AttackPlanRoofBasedOverTime());
    }

    void Update()
    {

    }

   // Détache un ennemi
   public void DetachEnemy(GameObject randomEnemy) {
        randomEnemy.GetComponentInChildren<EnemyAttack>().SetParentBoxEnemy();
        randomEnemy.GetComponentInChildren<EnemyAttack>().Detach();
    }

    // Détache un ennemi aléatoirement
    private IEnumerator DetachOverTime()
    {
        while (true)
        {
            GameObject randomEnemy = formation.GetRandomEnemy();
            if (randomEnemy != null)
            {
                DetachEnemy(randomEnemy);
            }
            yield return new WaitForSeconds(Constants.delay);
        }
    }

    // Attaque aléatoirement
    private IEnumerator AttackPlanRoofBasedOverTime()
    {
        float ratioLimit = 0.20f;
        float limitForManyRandom = 5.0f;
        GameObject enemyToAttack;
        float difficulty;
        while (true)
        {
            difficulty = formation.GetNbEnemyAlive();
            if (difficulty > limitForManyRandom)
            {
                float limit = ratioLimit * difficulty;
                int quantityToGet = Random.Range(1, (int)System.Math.Round(limit));
                for (int i = 0; i < quantityToGet; i++)
                {
                    enemyToAttack = formation.GetRandomEnemy();
                    if (enemyToAttack != null)
                    {
                        SetEnemyToAttack(enemyToAttack);
                    }
                }

            }
            else if (difficulty >= 0.0f
                     && difficulty <= limitForManyRandom)
            {
                enemyToAttack = formation.GetRandomEnemy();
                if (enemyToAttack != null)
                {
                    SetEnemyToAttack(enemyToAttack);
                }
            }
            yield return new WaitForSeconds(Constants.delay);
        }
    }

    // Définit l'ennemi qui attaque
    public void SetEnemyToAttack(GameObject enemy)
    {
        EnemyAttack enemyAttack = enemy.GetComponentInChildren<EnemyAttack>();
        if (enemyAttack.IsDetached() == false && enemyAttack.IsAttacking() == false)
        {
            enemyAttack.SetAttack(true);
        }
    }


}
