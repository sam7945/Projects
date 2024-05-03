using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Cette classe gère le mouvement horizontal de la formation
//
public class FormationMouvement : MonoBehaviour
{
    float speed = GameSettings._formationSpeed;
    float sideLimitR;
    float sideLimitL;
 
    bool right = true;
    public float formationSize;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
      
        sideLimitR =  (formationSize / 4);
        sideLimitL = -(formationSize / 4);
        StartCoroutine(MoveDownOverTime(Constants.downMovementDuration, Constants.downMovementDistance));
        StartCoroutine(MoveDownOverTime(Constants.downMovementDuration, Constants.downMovementDistance));
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            if (transform.position.x < sideLimitR)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else { right = false; }
                
        }
        if (!right)
        {
            if (transform.position.x > sideLimitL)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else { 
            right = true;
            }
        }
    }
    
    IEnumerator MoveDownOverTime(float duration, float distance)
    {
        while (true)
        {
            Vector3 start = transform.position;
            Vector3 end = transform.position + Vector3.down * distance;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(start, end, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(Constants.downMovementEveryX_second);
        }
    }


}
