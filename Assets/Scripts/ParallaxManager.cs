using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

    public float acceleration = 1;

    public float initialSpeed = 5;

    public float currentSpeed;

    public float groundSize = 30;


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



    //private bool spawnObstacle = false;
    void Awake()
    {
        currentSpeed = initialSpeed;

        initialPos = transform.Find("GroundStart").position;
    }

    // Use this for initialization
    void Start()
    {

        Invoke("SpawnObstacle", obstacleTimer);
        Invoke("SpawnStars", starTimer);

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;

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
        //obsPosition.y += 1;
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
        GameObject star = starsPrefabs[Random.Range(0, starsPrefabs.Count)];
        star = Instantiate(star, starPosition, Quaternion.identity) as GameObject;
        
        star.GetComponent<Star>().manager = this;
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


}
