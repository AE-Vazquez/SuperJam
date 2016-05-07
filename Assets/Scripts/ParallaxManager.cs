using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

    public float acceleration = 1;

    public float initialSpeed = 5;

    public float groundSize = 30;

    public float obstacleTimer;

    public float obstacleTimerBounds;

    public float obstacleTimerDecrease;

    public float starTimer;

    public float starTimerBounds;

    public float starTimerDecrease;

    private Vector3 initialPos;

    public List<GameObject> obstaclesPrefabs;

    public List<GameObject> starsPrefabs;

    [HideInInspector]
    public float currentSpeed;

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
        GameObject obs = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)];
        obs = Instantiate(obs, initialPos, Quaternion.identity) as GameObject;
        obs.GetComponent<Obstacle>().currentSpeed = currentSpeed;
        obs.GetComponent<Obstacle>().acceleration = acceleration;
        Invoke("SpawnObstacle", Random.Range(obstacleTimer-obstacleTimerBounds, obstacleTimer + obstacleTimerBounds));
        obstacleTimer -= obstacleTimerDecrease;
    }

    void SpawnStars()
    {
        GameObject obs = starsPrefabs[Random.Range(0, starsPrefabs.Count)];
        obs = Instantiate(obs, initialPos, Quaternion.identity) as GameObject;
        obs.GetComponent<Star>().currentSpeed = currentSpeed;
        obs.GetComponent<Star>().acceleration = acceleration;
        Invoke("SpawnStars", Random.Range(starTimer - starTimerBounds, starTimer + starTimerBounds));
        starTimer -= starTimerDecrease;
    }


}
