using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public delegate void onDeathEvent(GameObject deadObject);
    //public event onDeathEvent onDeath;

    GameObject spaceShip;
    public SpaceShipBoosterActivator ssba;

    public float _lifePoints = 100;

    public bool isExploding = false;
    private HealthDisplayInterface displayLife;
    private Invulnerability invulnerable;



    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GameObject.Find("SpaceShip");
        ssba = spaceShip.GetComponent<SpaceShipBoosterActivator>();
        if(CompareTag("Player"))
            invulnerable = gameObject.GetComponent<Invulnerability>();

    }

    // Update is called once per frame
    void Update()
    {

        if (displayLife != null)
        {
            displayLife.displayLife(_lifePoints);
        }

    }

    public void setDisplayLife(HealthDisplayInterface displayLife)
    {
        this.displayLife = displayLife;

    }


    public void addHealth(float amount)
    {
        Debug.Log("Points de vie ajoutés");
        _lifePoints += amount;
        if(_lifePoints > 100)
        {
            _lifePoints = 100;
        }
    }

    public float getHealth() {
        return _lifePoints;
    }

    public void applyDmg(float dmg){

        if (!isExploding )
        {
            /* if (CompareTag("Player") && ssba.powerUpShieldEnabled && !invulnerable.isInvincible) */
            /* { */
                /* dmg = (float)Math.Ceiling(dmg / 2); */

            /* } */

            /* /1* if (ssba != null) { *1/ */
            /*     if (this.gameObject.tag == "Enemy" */
            /*             && ssba.powerUpWeaponEnabled) */
            /*     { */
            /*         dmg = dmg * 2; */
            /*     } */
            /* /1* } *1/ */

            if (_lifePoints - dmg <= 0 && CompareTag("Player"))
            {
                _lifePoints = 0;

                StartCoroutine(explosion());


            }
            else if (CompareTag("Player") && !invulnerable.isInvincible) {
                invulnerable.beginInvincibility(2);
                _lifePoints -= dmg;
            }
            else if(CompareTag("Enemy"))
            {
                _lifePoints -= dmg;
            }

        }

    }
    IEnumerator explosion()
    {
        spaceShip.GetComponent<Explosion>().ActivateExplosion(true,Constants.EXPLOSION_VAISSEAU);
        isExploding = true;
        spaceShip.gameObject.transform.Find("SpaceShip").GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitUntil(() => spaceShip.GetComponent<Explosion>().isExploding == false);
        Destroy(spaceShip, 2);
        SceneManager.LoadScene("GameOver");
    }

}
