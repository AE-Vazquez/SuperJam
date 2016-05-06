using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {


    private Vector3 direction;
    [HideInInspector]
    public float currentSpeed=20;
	// Use this for initialization
	void Start () {
        direction = new Vector3(0, 0, -1);

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * currentSpeed * Time.deltaTime);
	}

    
}
