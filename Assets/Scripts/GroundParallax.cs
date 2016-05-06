using UnityEngine;
using System.Collections;

public class GroundParallax : MonoBehaviour {

    public float acceleration;

    public GameObject groundPrefabs;

    private float currentSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void IncreaseSpeed()
    {
        currentSpeed += acceleration;
    }
}
