using System;
using System.Collections.Generic;

public class ObjectRandomizer<T>
{
    private Dictionary<T, float> probabilities;

    public ObjectRandomizer(Dictionary<T, float> probabilities)
    {
        this.probabilities = probabilities;
    }

    public List<T> GetRandomObjects(int count) //2
    {
        List<T> objects = new List<T>();
        Random random = new Random();

        List<T> weightedObjects = new List<T>();
        foreach (KeyValuePair<T, float> pair in probabilities) //6
        {
            T obj = pair.Key;
            float probability = pair.Value;

            int weightedCount = (int)System.Math.Ceiling(probability * count);
            for (int i = 0; i < weightedCount; i++)
            {
                weightedObjects.Add(obj);
            }
        }

        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(weightedObjects.Count);
            T selectedObject = weightedObjects[randomIndex];
            objects.Add(selectedObject);
        }

        return objects;
    }
}

/* exemple d'utilisation: pas besoin d'ajouter ce script a un game object, juste l'instancier dans votre script.
enum EnemyType { Enemy1, Enemy2, Enemy3, Enemy4, Enemy5 }
    void fonctionQuelconque()
    {
        Dictionary<EnemyType, float> enemyProbabilities = new Dictionary<EnemyType, float>()
        {
            { EnemyType.Enemy1, 0.3f }, 
            { EnemyType.Enemy2, 0.2f },
            { EnemyType.Enemy3, 0.1f }, 
            { EnemyType.Enemy4, 0.2f },
            { EnemyType.Enemy5, 0.2f }
        };

        ObjectRandomizer<EnemyType> enemyRandomizer = new ObjectRandomizer<EnemyType>(enemyProbabilities);

        // Obtenir une liste de 5 ennemis aléatoires
        List<EnemyType> randomEnemies = enemyRandomizer.GetRandomObjects(5);
    }
*/