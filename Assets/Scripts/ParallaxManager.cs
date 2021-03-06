﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

    public float acceleration = 1;

    public float initialSpeed = 5;

    public float maxSpeed = 20;

    public float currentSpeed;

    private Vector3 initialPos;

    public List<GameObject> obstaclesPrefabs;

    public float obstacleTimer;

    public float obstacleTimerBounds;

    public float obstacleTimerDecrease;

    public float minObstacleTimer=3;

    public List<GameObject> starsPrefabs;

    public float starTimer;

    public float starTimerBounds;

    public float starTimerDecrease;

    public float minStarTimer=2;

    public bool menu=false;


    //private bool spawnObstacle = false;
    void Awake()
    {
        currentSpeed = initialSpeed;
        
        initialPos = transform.Find("GroundStart").position;

    }

    // Use this for initialization
    void Start()
    {
        
        if (!menu)
        {
            Invoke("SpawnObstacle", obstacleTimer);
            Invoke("SpawnStars", starTimer);
        }
        else
        {
            acceleration = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

    }

    public void GroundDisabled(Ground ground)
    {

        ground.transform.position = initialPos;

    }

    public void ObstacleDisabled(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);

    }

    void SpawnObstacle()
    {
        Vector3 obsPosition = initialPos;
        obsPosition.y += 1;
        obsPosition.x += Random.Range(-25, 25);

        GameObject obs = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)];
        obs = Instantiate(obs, obsPosition, Quaternion.identity) as GameObject;
        obs.GetComponent<Obstacle>().manager = this;
        Invoke("SpawnObstacle", Random.Range(obstacleTimer-obstacleTimerBounds, obstacleTimer + obstacleTimerBounds));
        if (obstacleTimer > minObstacleTimer)
        {
            obstacleTimer -= obstacleTimerDecrease;
        }
        
    }

    void SpawnStars()
    {
        Vector3 starPosition = initialPos;
        starPosition.x += Random.Range(-20, 20);
        starPosition.y += 5;
        //starPosition.y += Random.Range(-0.1f, 0.3f);
        GameObject star = starsPrefabs[Random.Range(0, starsPrefabs.Count)];
        star = Instantiate(star, starPosition, Quaternion.identity) as GameObject;

        if (star.transform.childCount > 0)
        {
            foreach(Star s in star.GetComponentsInChildren<Star>())
            {
                s.manager = this;
            }
        }
        else
        {
            star.GetComponent<Star>().manager = this;
        }
        Invoke("SpawnStars", Random.Range(starTimer - starTimerBounds, starTimer + starTimerBounds));
        if (starTimer > minStarTimer)
        {
            starTimer -= starTimerDecrease;
        }
    }

    public void ChangeSpeed(float change)
    {
        currentSpeed += change;
    }

    public void StopGame()
    {
        acceleration = 0;
        CancelInvoke();
    }


}
