using UnityEngine;
using System.Collections;

public class GroundEnd : MonoBehaviour {

    private ParallaxManager manager;
    ShipBase shipBase;
           
    // Use this for initialization
    void Start () {
        shipBase = GameObject.Find("Ship").GetComponent<ShipBase>();
        manager = GetComponentInParent<ParallaxManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        
        if (col.GetComponent<Ground>() != null)
        {
            if (!shipBase.dead)
            {
                shipBase.points++;
                shipBase.hudManager.UpdatePoints((int)shipBase.points);
            }
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
