using UnityEngine;
using System.Collections;

public class ShipBase : MonoBehaviour {


    public float maxLives = 3;

    private float currentLives;


    public float points;
    public float maxEnergy = 100;
    
    public float currentEnergy = 0;

    public float invulTime = 2;
   
    public bool invulnerable = false;



	// Use this for initialization
	void Start () {
        currentLives = maxLives;
        points = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeHit()
    {
        if (!invulnerable)
        {
            currentLives--;

            if (currentLives <= 0)
            {
                DestroyShip();
            }
            else
            {
                StartInvulTime();
            }
        }
    }

    public void DestroyShip()
    {
        Destroy(gameObject);

        //Instanciar partculas explosion
    }

    public void StartInvulTime()
    {
        invulnerable = true;
        GetComponent<Flicker>().StartFlickering();
    }

    public void StarCollected(Star star)
    {
        points += star.pointReward;
        currentEnergy += star.energyReward;
        if(currentEnergy>maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

    }

}
