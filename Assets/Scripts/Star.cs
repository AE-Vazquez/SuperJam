using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {


    public float pointReward;

    public float energyReward;

    [HideInInspector]
    public float currentSpeed = 20;

    [HideInInspector]
    public float acceleration = 1;

    private Vector3 direction;

    void Start()
    {

        direction = new Vector3(0, 0, -1);

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(direction * currentSpeed * Time.deltaTime,Space.World);
    }

    public void DestroyStar()
    {
        Destroy(gameObject);
    }
}
