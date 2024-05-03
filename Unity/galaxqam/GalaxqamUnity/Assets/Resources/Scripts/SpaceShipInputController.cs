using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class <c>SpaceShipInputController</c>
/// Cette classe gère les déplacements du vaisseau du joueur et les entrées
/// (touches du clavier)
/// Aussi, il s'assure que le vaisseau ne vas pas au dela des limites de
/// l'écran.
/// </summary>

public class SpaceShipInputController : MonoBehaviour
{

    // La position à laquelle le vaisseau quitte l'écran avec une configuration
    // 16:9.
    public float sideLimit;
    public float speed;

    GameSettings gameSettings;

    public WeaponControl weaponControl;
    public GameObject spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    void InputManager()
    {
        /* if (spaceShip.GetComponent<Health>()._lifePoints > 0 || true) */
        /* { */
            // Déplacement à gauche
            if (Input.GetKey(KeyCode.A))
            {
                if (transform.position.x > -sideLimit)
                {
                    transform.position += Vector3.left * GameSettings.PlayerShipSpeed * Time.deltaTime;
                }

            }

            // Déplacement à droite
            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < sideLimit)
                {
                    transform.position += Vector3.right * GameSettings.PlayerShipSpeed * Time.deltaTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                weaponControl.FireStandardWeapon();
            }
        //}
    }

    void Init()
    {
        gameSettings = GameObject.Find("GameController").GetComponent<GameSettings>();
        weaponControl = gameObject.AddComponent<WeaponControl>();
        sideLimit = GameSettings.GetVisualSideLimit();
        speed = GameSettings.PlayerShipSpeed;
        spaceShip = GameObject.Find("SpaceShip");
    }
}
