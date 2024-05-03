using System;
using UnityEngine;

public class EnemyDisplayHealth : MonoBehaviour, HealthDisplayInterface
{
    Material[] enemyMaterials;
    Color interpolatedColor;
    private const string LIFE_MATERIAL_NAME = "LifeStatusMaterial (Instance)";
    


    void Start()
    {
        enemyMaterials = gameObject.GetComponentInChildren<MeshRenderer>().materials;
    }
    public void displayLife(float life) 
    {
        if(enemyMaterials != null)
        {
            float lifeDecimal = life / 100;
            interpolatedColor = interpolateColor(lifeDecimal);

            changeMaterials(interpolatedColor);
        }
        
    }

    private Color interpolateColor(float life_decimal)
    {
        return new Color(3.0f * (1 - life_decimal), 2.0f * life_decimal, 0);
    }

    private void changeMaterials(Color color)
    {
        Material[] materialsToChange = Array.FindAll(enemyMaterials, mat => mat.name.Equals(LIFE_MATERIAL_NAME));
        Array.ForEach(materialsToChange, material => material.SetColor("_Color", color));
        Array.ForEach(materialsToChange, material => material.SetColor("_EmissionColor", color));
    }
}
