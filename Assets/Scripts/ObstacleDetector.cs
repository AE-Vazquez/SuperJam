using UnityEngine;
using System.Collections;

public class ObstacleDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ship"))
        {
            ShipBase shipBase = col.GetComponent<ShipBase>();
            if (!shipBase.boosted)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                shipBase.TakeHit();
            }
            else
            {
                StartCoroutine(GetComponent<TriangleExplosion>().SplitMesh(true));
                
            }
        }
    }
}
