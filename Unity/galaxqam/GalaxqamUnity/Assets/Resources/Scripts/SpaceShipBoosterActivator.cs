using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipBoosterActivator : MonoBehaviour
{
    // Start is called before the first frame update
    // Juste pour être plus clean dans le call du tableau
    public const int SHIELD=0;
    public const int WEAPON=1;
    public const int SPEED=2;

    public GameObject[] boosters = new GameObject[3];
    private IEnumerator[] coroutine = new IEnumerator[3];

    public bool powerUpSpeedEnabled;
    public bool powerUpShieldEnabled;
    public bool powerUpWeaponEnabled;

    void Start()
    {
        Init();
        SetBoostersInactives();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init(){
        powerUpSpeedEnabled = false;
        powerUpShieldEnabled = false;
        powerUpWeaponEnabled = false;
        boosters[SHIELD] = transform.Find("SpaceShip").transform.Find("BoosterShield").gameObject;
        boosters[WEAPON] = transform.Find("SpaceShip").transform.Find("BoosterWeapon").gameObject;
        boosters[SPEED] = transform.Find("SpaceShip").transform.Find("BoosterSpeed").gameObject;
    }

    void SetBoostersInactives(){
        for(int i = 0; i < boosters.Length; i++){
            boosters[i].SetActive(false);
        }
    }

    public void SetActive(int id){
        switch (id) {
            case SHIELD:
                if(powerUpShieldEnabled)
                {
                    StopCoroutine(coroutine[id]);
                }
                break;
            case WEAPON:
                if (powerUpWeaponEnabled)
                {
                    StopCoroutine(coroutine[id]);
                }
                break;
            case SPEED:
                if (powerUpSpeedEnabled)
                {
                    StopCoroutine(coroutine[id]);
                }
                break;
        }

        coroutine[id] = SetActiveCoroutine(id);

        StartCoroutine(coroutine[id]);
    }

    IEnumerator SetActiveCoroutine(int id){
        Debug.Log("Activate " + id);
        boosters[id].SetActive(true);
        EnablePowerUp(id);
        yield return new WaitForSeconds(GameSettings.GetBoosterTime());
        boosters[id].SetActive(false);
        DisablePowerUp(id);
        Debug.Log("Deactivate " + id);
    }

    private void EnablePowerUp(int id)
    {
        switch (id)
        {
            case SHIELD:
                PowerUpShield.Enable(this);
                break;
            case WEAPON:
                PowerUpWeapon.Enable(this);
                break;
            case SPEED:
                PowerUpSpeed.Enable(this);
                break;
        }
    }

    private void DisablePowerUp(int id)
    {
        switch (id)
        {
            case SHIELD:
                PowerUpShield.Disable(this);
                break;
            case WEAPON:
                PowerUpWeapon.Disable(this);
                break;
            case SPEED:
                PowerUpSpeed.Disable(this);
                break;
        }
    }
}
