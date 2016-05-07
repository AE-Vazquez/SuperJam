using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {


    private Vector3 direction;
    [HideInInspector]
    public float currentSpeed=20;

    [HideInInspector]
    public float acceleration = 1;
	// Use this for initialization
	void Start () {
        acceleration = GetComponentInParent<ParallaxManager>().acceleration;
        currentSpeed = GetComponentInParent<ParallaxManager>().currentSpeed;
        direction = new Vector3(0, 0, -1);

	}
	
	// Update is called once per frame
	void Update () {
        currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(direction * currentSpeed * Time.deltaTime);
	}

    void OnEnable()
    {
        currentSpeed = GetComponentInParent<ParallaxManager>().currentSpeed;
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }

    
}
