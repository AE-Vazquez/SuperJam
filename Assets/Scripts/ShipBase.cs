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

    public bool boosted = false;

    public float boostDuration = 5;

    public float boostSpeed = 10;

    public GameObject parallaxManager;
    private ParallaxManager manager;

    public Vector3 shakeAmount= new Vector3(2,1,0);

    public float shakeTime = 2;


    // Use this for initialization
    void Start () {
        manager = parallaxManager.GetComponent<ParallaxManager>();
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
                
                iTween.ShakePosition(gameObject, shakeAmount, shakeTime);
                StartInvulTime();
            }
        }
    }

    public void DestroyShip()
    {
        //Instanciar partculas explosion
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<ShipController>().enabled = false;
        gameObject.GetComponent<WebController>().enabled = false;
        gameObject.transform.Find("nave_interior").GetComponent<Renderer>().enabled = false;
        this.enabled = false;
        manager.StopGame();

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

    public void ActivateBoost()
    {
        if (!boosted && currentEnergy == maxEnergy)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            boosted = true;
            manager.ChangeSpeed(boostSpeed);
            StartCoroutine(BoostConsumer());
        }
    }

    public IEnumerator BoostConsumer()
    {
        float t = 0;
        while (currentEnergy>0)
        {
            t += Time.deltaTime / boostDuration;
            currentEnergy = Mathf.Lerp(maxEnergy, 0, t);
            yield return 0;
        }
        DeactivateBoost();
        yield return 0;
    }

    public void DeactivateBoost()
    {
        
        if (boosted)
        {
            boosted = false;
            manager.ChangeSpeed(-boostSpeed);
        }
    }

}
