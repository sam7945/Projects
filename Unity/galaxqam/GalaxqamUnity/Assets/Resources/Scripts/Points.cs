using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    GameObject spaceShip;

    public float _playerPoints = 0;

    private PointsDisplayInterface displayPoints;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.Find("SpaceShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (displayPoints != null)
        {
            displayPoints.displayPoints(_playerPoints);
        }
    }

    public void setDisplayPoints(PointsDisplayInterface displayPoints)
    {
        this.displayPoints = displayPoints;

    }
    public void addPoints(float amount)
    {

        _playerPoints += amount;
        
    }
}
