using UnityEngine;
using System.Collections;

public class ShipCollisions : MonoBehaviour {

    ShipBase shipBase;
	// Use this for initialization
	void Start () {
        shipBase = GetComponent<ShipBase>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Obstacle"))
        {
            shipBase.TakeHit();
        }
        else if(col.gameObject.CompareTag("Star"))
        {
            shipBase.StarCollected(col.GetComponent<Star>());
            col.GetComponent<Star>().DestroyStar();
        }
    }
}
