using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class SpaceShipDisplayPoints : MonoBehaviour, PointsDisplayInterface
{
    private GUIStyle pointsStyle = new GUIStyle();
    public string pointsText;
    public float points;
    TMP_FontAsset font;
    void Start()
    {
        font = Resources.Load<TMP_FontAsset>($"Fonts & Materials/Electronic Highway Sign SDF");
    }
    void OnGUI()
    {
        pointsStyle.font = font.sourceFontFile;
        pointsStyle.fontSize = 24;
        pointsStyle.font = font.sourceFontFile;
        pointsStyle.normal.textColor = Color.white;
        
        GUI.Label(new Rect(50, Screen.height - 90, 200, 200), pointsText, pointsStyle);
    }

    public void displayPoints(float points)
    {
        this.points = points;
        pointsText = "Pts : " + points.ToString();

    }
}
