using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_jeu : MonoBehaviour
{
    public GameObject[] obstacle;
    public Vector3 PositionVague;
    public int nombreObstacles;
    public float attenteVague;
    public float debutAttente;
    public float intervalleVague;
    public Canvas canvasGameOver;
    public Button boutonRecommencer;
    public Button boutonMenu;
    public Text textGameOver;


    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver = canvasGameOver.GetComponent<Canvas>();
        boutonMenu = boutonMenu.GetComponent<Button>();
        boutonRecommencer = boutonRecommencer.GetComponent<Button>();
        textGameOver = textGameOver.GetComponent<Text>();
        StartCoroutine(ApparitionVague());
    }

    public void RecommencerPress() 
    {
        canvasGameOver.enabled = false;
        boutonMenu.enabled = false;
        boutonRecommencer.enabled = false;
        textGameOver.enabled = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void RetourMenu()
    {
        canvasGameOver.enabled = false;
        boutonMenu.enabled = false;
        boutonRecommencer.enabled = false;
        textGameOver.enabled = false;
        Application.LoadLevel("MenuAccueil");
    }

    IEnumerator ApparitionVague()
    {
        yield return new WaitForSeconds(debutAttente);
        while (true)
        {
            for (int i = 0; i < nombreObstacles; i++)
            {
                Vector3 Vague = new Vector3(Random.Range(-PositionVague.x, PositionVague.x), PositionVague.y, PositionVague.z);
                Quaternion rotationVague = Quaternion.identity;
                Instantiate(obstacle[Random.Range(0,9)], Vague, rotationVague);
                yield return new WaitForSeconds(attenteVague);
            }
            yield return new WaitForSeconds(intervalleVague);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
