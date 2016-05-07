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
            
        }
        else
        {
            if (col.transform.parent != null)
            {
                Destroy(col.transform.parent.gameObject);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }


    }
}
