using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {


    private Vector3 direction;
    [HideInInspector]
    public float currentSpeed=20;

    [HideInInspector]
    public float acceleration = 1;

    public float size = 40;

    public Transform previousGround;

    private ParallaxManager manager;
	// Use this for initialization
	void Start () {
        manager = GetComponentInParent<ParallaxManager>();
        direction = new Vector3(0, 0, -1);

	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(direction * manager.currentSpeed * Time.deltaTime,Space.World);
	}

    public void ResetPosition()
    {
        transform.position = previousGround.transform.position + new Vector3(0, 0, size);
    }

    
}
