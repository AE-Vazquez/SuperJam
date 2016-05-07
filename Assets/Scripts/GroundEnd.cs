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
        if (col.GetComponent<Ground>() != null)
        {
            col.GetComponent<Ground>().ResetPosition();
            manager.GroundDisabled(col.GetComponent<Ground>());
        }
        else
        {
            Destroy(col.gameObject);
        }

        /*
        if(col.GetComponentInParent<Obstacle>()!=null)
        {
            manager.ObstacleDisabled(col.GetComponentInParent<Obstacle>());
        }
        */

    }
}
