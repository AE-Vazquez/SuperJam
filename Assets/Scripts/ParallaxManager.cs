using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{

    public float acceleration = 1;

    public float initialSpeed = 5;

    public int groundCount = 3;

    public float obstacleTimer;

    private Vector3 initialPos;

    public GameObject groundPrefabs;

    public GameObject obstaclesPrefabs;

    private List<Ground> disabledGrounds;

    private List<Ground> activeGrounds;

    private float currentSpeed;

    private bool spawnObstacle = false;


    // Use this for initialization
    void Start()
    {
        activeGrounds = new List<Ground>();
        disabledGrounds = new List<Ground>();
        int activeCount = 0;
        activeGrounds.AddRange(GetComponentsInChildren<Ground>());
        currentSpeed = initialSpeed;

        initialPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        currentSpeed += acceleration * Time.deltaTime;

        foreach (Ground g in activeGrounds)
        {
            g.currentSpeed = currentSpeed;
        }

    }

    public void GroundDisabled(Ground ground)
    {
        ground.gameObject.transform.position = initialPos;
        ground.gameObject.SetActive(false);

        activeGrounds.Remove(ground);
        disabledGrounds.Add(ground);
        CreateNewGround();
    }

    void CreateNewGround()
    {
        if(spawnObstacle)
        {

        }
        GameObject newGround = disabledGrounds[Random.Range(0, disabledGrounds.Count)].gameObject;

        newGround.SetActive(true);

        newGround.GetComponent<Ground>().currentSpeed = currentSpeed;
        activeGrounds.Add(newGround.GetComponent<Ground>());
        disabledGrounds.Remove(newGround.GetComponent<Ground>());
    }



}
