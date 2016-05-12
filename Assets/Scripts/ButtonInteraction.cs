using UnityEngine;
using System.Collections;

public class ButtonInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
          if (!PlayerPrefs.GetString ("gameMode").Equals ("VR")) {
               if (PlayerPrefs.GetString ("gameMode").Equals ("COLABORATIVE")) {
                    gameObject.transform.parent.GetComponent<WebController> ().enabled = true;
               }

               Cardboard.SDK.VRModeEnabled = false;

               gameObject.transform.parent.GetComponent<MeshRenderer> ().enabled = true;
               GetComponent<MeshRenderer> ().enabled = false;
               transform.parent = null;
            //transform.position = new Vector3 (30.96f, 48.9f, 0.81f);
            transform.position = new Vector3(30.96f, 15.4f, 76.5f);
            CardboardHead cHead = GetComponentInChildren<CardboardHead> ();
               cHead.trackPosition = false;
               cHead.trackRotation = false;
               cHead.transform.rotation = Quaternion.Euler (new Vector3 (16.3f,0,0));
               //transform.LookAt (gameObject.transform.parent);

          }
          else
        {
            if(transform.parent.Find("nave")!= null)
            {
                transform.parent.Find("nave").GetComponent<Renderer>().enabled = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     void LateUpdate() {
          Cardboard.SDK.UpdateState();
          if (Cardboard.SDK.BackButtonPressed) {
               Application.Quit();
          }
     }

     public void SetGazedAt(bool gazedAt) {          
          GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
     }

     public void SetClick(){                    
          //Handheld.Vibrate();
          Debug.Log("Test Click");
     }

     #region ICardboardGazeResponder implementation

     /// Called when the user is looking on a GameObject with this script,
     /// as long as it is set to an appropriate layer (see CardboardGaze).
     public void OnGazeEnter() {
          SetGazedAt(true);
     }

     /// Called when the user stops looking on the GameObject, after OnGazeEnter
     /// was already called.
     public void OnGazeExit() {
          SetGazedAt(false);
     }

     // Called when the Cardboard trigger is used, between OnGazeEnter
     /// and OnGazeExit.
     public void OnGazeTrigger() {
          Vibration.Vibrate ();
          Debug.Log ("asdas");
     }

     #endregion
}