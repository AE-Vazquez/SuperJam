using UnityEngine;
using System.Collections;

public class StarDetector : MonoBehaviour {

    Star star;
	// Use this for initialization
	void Start () {
        star = GetComponent<Star>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ship"))
        {
            col.GetComponent<ShipBase>().StarCollected(star);
            star.DestroyStar();
        }
    }
}
