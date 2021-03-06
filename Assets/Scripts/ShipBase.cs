﻿using UnityEngine;
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

    public Vector3 shakeAmount= new Vector3(2.5f,1.5f,0);

    private AudioSource audio;

    public AudioClip[] audioClips;

    public float shakeTime = 2;

    [HideInInspector]
    public bool dead = false;


    public GameObject HudManager;
    [HideInInspector]
    public HUDManager hudManager;


    // Use this for initialization
    void Start () {
        manager = parallaxManager.GetComponent<ParallaxManager>();
        hudManager = HudManager.GetComponent<HUDManager>();
        currentLives = maxLives;
        points = 0;
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void TakeHit()
    {
        
        if (!invulnerable && !dead)
        {
            currentLives--;
            hudManager.UpdateLives((int)currentLives);
            audio.clip = audioClips[0];
            audio.Play();

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
        // Game Over
          hudManager.SetGameOver();

        //Instanciar partculas explosion
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<ShipController>().enabled = false;
        gameObject.GetComponent<WebController>().enabled = false;
        if (gameObject.transform.Find("nave_interior") != null)
        {
            gameObject.transform.Find("nave_interior").GetComponent<Renderer>().enabled = false;
            if(gameObject.transform.Find("nave_interior").GetComponent<Canvas>())            gameObject.transform.Find("nave_interior").GetComponent<Canvas>().enabled = false;

        }
        if (gameObject.transform.Find("nave") != null)
        {
            gameObject.transform.Find("nave").GetComponent<Renderer>().enabled = false;
        }
        dead = true;
        
        manager.StopGame();

    }

    public void StartInvulTime()
    {
        invulnerable = true;
        GetComponent<Flicker>().StartFlickering();
    }

    public void StarCollected(Star star)
    {
        if (!dead)
        {
            points += star.pointReward;
            hudManager.UpdatePoints((int)points);
            currentEnergy += star.energyReward;
            hudManager.UpdateBooster(currentEnergy/100);
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

    }

    public void ActivateBoost()
    {
        if (!boosted && currentEnergy == maxEnergy)
        {
            audio.clip = audioClips[1];
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
            hudManager.UpdateBooster(currentEnergy/100);
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
