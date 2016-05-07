﻿using UnityEngine;
using System.Collections;

public class ButtonInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void SetGazedAt(bool gazedAt) {
          Debug.Log ("test move");
          GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
     }

     public void SetClick(){
          Debug.Log ("Clicked");
          Handheld.Vibrate();
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
          Debug.Log ("Clicked");
     }

     #endregion
}