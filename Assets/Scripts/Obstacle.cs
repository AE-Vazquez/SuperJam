using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    private Vector3 direction;
    [HideInInspector]
    public float currentSpeed = 20;

    [HideInInspector]
    public float acceleration = 1;

    void Start()
    {
        acceleration = GetComponentInParent<ParallaxManager>().acceleration;
        direction = new Vector3(0, 0, -1);

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }
}
