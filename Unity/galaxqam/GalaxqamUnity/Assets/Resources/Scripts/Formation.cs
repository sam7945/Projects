using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ennemis disponibles dans le jeu
public enum EnemyType { None, Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6 };

//
// Cette classe crée la formation des ennemis
//
public class Formation : MonoBehaviour

{
    public float startPositionX;

    public float nbPerRowMax;
    public float nbPerRowMin;
    public Dictionary<EnemyType, float> enemyProbabilities = GameSettings.enemyProbabilities;
    GameSettings gs;

    private float enemyAlive;

    private List<Vector2> enemyPositionsList;

    public Formation() {

    }

    // Créer la formation des ennemis
    public void Creation()
    {

        GameObject rootFormation = new GameObject("root_formation");
        nbPerRowMax = (nbPerRowMax <= GameSettings._actualMaxPerRow) ? nbPerRowMax : GameSettings._actualMaxPerRow;
        nbPerRowMin = (nbPerRowMin >= GameSettings._actualMinPerRow) ? nbPerRowMin : GameSettings._actualMinPerRow;
        if (nbPerRowMax < nbPerRowMin) {
            float temps = 0f;
            temps = nbPerRowMax;
            nbPerRowMax = nbPerRowMin;
            nbPerRowMin = temps;
        }
        float halfSpace = (nbPerRowMax - 1) / 2;
        startPositionX = -(halfSpace * GameSettings._xSpacing);

        if(enemyPositionsList == null)
        {
            enemyPositionsList = new List<Vector2>();
        }


        ObjectRandomizer<EnemyType> enemyRandomizer = new ObjectRandomizer<EnemyType>(enemyProbabilities);

        for (int i = 0; i < GameSettings._nbRow; i++)
        {
            EnemyType en;
            float nbEnemy = CalculEnemyNb(i);
            int halfRow = (int)System.Math.Ceiling(nbEnemy / 2);
            List<EnemyType> halfList = enemyRandomizer.GetRandomObjects(halfRow);
            for (int j = 0; j < nbEnemy; j++)
            {
                bool larger = (i % 2 == 0);
                Vector3 pos = AssignPosition(i, j, larger);
                int indexEnnemi = (int)IndexTypeEnemy(nbEnemy, j);
                en = halfList[indexEnnemi];
                string name = NameEnemy(en);

                GameObject enemyContainer = new GameObject("box" + "_(" + i + "," + j + ")");
                enemyContainer.transform.position = pos;

                enemyContainer.transform.SetParent(rootFormation.transform);
                GameObject loadedEnemy = (GameObject)Resources.Load("Prefabs/" + name, typeof(GameObject));
                GameObject enemy = Instantiate(loadedEnemy, enemyContainer.transform, false);
                enemy.name = "prefab_" + name + "_(" + i + "," + j + ")";
                enemy.AddComponent<EnemyAttack>();
                SetLayer(enemy);

                enemyPositionsList.Add(new Vector2(i, j));

            }
            enemyAlive += nbEnemy;
        }
        rootFormation.AddComponent<FormationMouvement>().formationSize = this.GetSize();
    }

    public void CreationFromFile()
    {
        GameObject rootFormation = new GameObject("root_formation");
        startPositionX = 0;

        string[] lines = Resources.Load<TextAsset>(Constants.formationFileName).text.Split('\n');

        float maxLenght = lines[0].Length;
        nbPerRowMax = maxLenght;
        float nbRow = lines.Length;
        GameSettings._nbRow = lines.Length;

        float halfSpace = (maxLenght - 1) / 2;
        startPositionX = -(halfSpace * GameSettings._xSpacing);
        GameSettings._startPositionY = 45f + (GameSettings._nbRow * GameSettings._ySpacing);


        if(enemyPositionsList == null)
        {
            enemyPositionsList = new List<Vector2>();
        }

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {

                EnemyType enemyType = CharacterToEnemyType(line[j]);


                if (enemyType != EnemyType.None)
                {
                    Vector3 pos = AssignPosition(i, j, true);

                    GameObject enemyContainer = new GameObject("box" + "_(" + i + "," + j + ")");
                    enemyContainer.transform.position = pos;
                    enemyContainer.transform.SetParent(rootFormation.transform);
                    string name = NameEnemy(enemyType);

                    GameObject loadedEnemy = (GameObject)Resources.Load("Prefabs/" + name, typeof(GameObject));
                    GameObject enemy = Instantiate(loadedEnemy, enemyContainer.transform, false);
                    enemy.name = "prefab_" + name + "_(" + i + "," + j + ")";
                    enemy.AddComponent<EnemyAttack>();
                    SetLayer(enemy);

                    // Add the enemy position to the list
                    enemyPositionsList.Add(new Vector2(i, j));
                }
            }
        }
        rootFormation.AddComponent<FormationMouvement>().formationSize = this.GetSize();

    }

    private EnemyType CharacterToEnemyType(char c)
    {
        switch (c)
        {
            case '1':
                return EnemyType.Enemy1;
            case '2':
                return EnemyType.Enemy2;
            case '3':
                return EnemyType.Enemy3;
            case '4':
                return EnemyType.Enemy4;
            case '5':
                return EnemyType.Enemy5;
            case '6':
                return EnemyType.Enemy6;
            default:
                return EnemyType.None;
        }
    }

    // Assigner la position à l'ennemi
    public Vector3 AssignPosition(int i, int j, bool larger)
    {
        float nStartPosition;
        if (larger)
        {
            return new Vector3(startPositionX + GameSettings._xSpacing * j, GameSettings._startPositionY - GameSettings._ySpacing * i, 0);
        }
        else
        {
            float gap = (nbPerRowMax - nbPerRowMin) / 2;
            nStartPosition = startPositionX + (gap * GameSettings._xSpacing);
            return new Vector3(nStartPosition + GameSettings._xSpacing * j, GameSettings._startPositionY - GameSettings._ySpacing * i, 0);
        }
    }

    // Get le nombre d'ennemis pour une ligne
    public float CalculEnemyNb(float i)
    {
        float nbEnemy = 0;
        if (i % 2 == 0) { nbEnemy = nbPerRowMax; } //positions relative
        else { nbEnemy = nbPerRowMin; }
        return nbEnemy;
    }

    // Get un indice pour identifier l'ennemi en permettant l'effet miroir
    // Par exemple pour une ligne de 7 ennemis, on aura: 0 1 2 3 2 1 0
    public float IndexTypeEnemy(float sizeLine, float positionX)
    {
        float half = sizeLine / 2;
        bool pair = (sizeLine % 2 == 0);
        if (positionX < half)
        {
            return positionX % half;
        }
        else
        {
            if (pair)
            {
                positionX = sizeLine - (positionX % half + 1);
                return positionX % half;
            }
            else
            {
                if (positionX == half)
                {
                    return positionX;
                }
                else
                {
                    positionX = sizeLine - (positionX % half);
                    return positionX % half - 1;
                }
            }
        }
    }

    // Obtenir le nom de l'ennemi
    public string NameEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                return "Enemy1";
                break;
            case EnemyType.Enemy2:
                return "Enemy2";
                break;
            case EnemyType.Enemy3:
                return "Enemy3";
                break;
            case EnemyType.Enemy4:
                return "Enemy4";
                break;
            case EnemyType.Enemy5:
                return "Enemy5";
                break;
            default:
                return "Enemy6";
                break;
        }
    }

    // Obtenir la taille de la plus grande ligne
    public float GetSize() {
        return nbPerRowMax * GameSettings._xSpacing;
    }

    // Retourne un ennemi choisi entre ceux existants dans
    // la formation existante
    public GameObject GetRandomEnemy()
    {
        GameObject enemySelected = null;
        Transform enemyBox = null;

        if(enemyPositionsList.Count == 0)
        {
            Debug.Log("No enemies available.");
            return null;
        }

        while(enemyBox == null)
        {
            // Select a random index from the list
            int randomIndex = Random.Range(0, enemyPositionsList.Count);
            Vector2 enemyPosition = enemyPositionsList[randomIndex];

            // Form the enemyNameBox
            string enemyNameBox = "box" + "_(" + enemyPosition.x + "," + enemyPosition.y + ")";
            enemyBox = GameObject.Find(enemyNameBox)?.transform;

            // If enemyBox exists and has a child
            if (enemyBox != null && enemyBox.childCount > 0)
            {
                enemySelected = enemyBox.GetChild(0).gameObject;
            }
            else
            {
                // If the enemy does not exist or is destroyed, remove it from the list
                enemyPositionsList.RemoveAt(randomIndex);
            }
        }

        return enemySelected;
    }

    // Donne un layer au ennemi
    public void SetLayer(GameObject g)
    {

        int layerName = LayerMask.NameToLayer("EnemyLayer");

        g.gameObject.layer = layerName;

    }

    // Retourne la difficulté en fonction du nombre d'ennemis
    // Un ennemi tué diminue cette valeur en 1
    public float GetNbEnemyAlive()
    {
        enemyAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return enemyAlive;
    }
}
