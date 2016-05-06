using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

    public float acceleration = 1;

    public float initialSpeed = 5;

    public float groundSize = 30;

    public float obstacleTimer;

    private Vector3 initialPos;

    private List<Ground> groundList;

    public List<GameObject> obstacleList;

    private float currentSpeed;

    private bool spawnObstacle = false;


    // Use this for initialization
    void Start()
    {
        groundList = new List<Ground>();
        groundList.AddRange(GetComponentsInChildren<Ground>());

        currentSpeed = initialSpeed;

        initialPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GroundDisabled(Ground ground)
    {
        ground.gameObject.SetActive(false);

        CreateNewGround();
    }

    public void ObstacleDisabled(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);

        CreateNewGround();
    }




    void CreateNewGround()
    {
        if (spawnObstacle)
        {
            //Instantiate
        }
        else
        {
            foreach (Ground g in groundList)
            {
                if (!g.gameObject.activeInHierarchy)
                {
                    g.transform.position = initialPos;
                    g.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }



}
