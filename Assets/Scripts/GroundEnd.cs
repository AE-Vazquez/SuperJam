using UnityEngine;
using System.Collections;

public class GroundEnd : MonoBehaviour {

    private ParallaxManager manager;
           
    // Use this for initialization
    void Start () {
        manager = GetComponentInParent<ParallaxManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        manager.GroundDisabled(col.GetComponent<Ground>());


    }
}
