﻿using UnityEngine;
using System.Collections;

public class WebController : MonoBehaviour {
     public string url = "http://www.costacar.com/unityTest.php";

     private bool loading = false;
     public float lastPost;

     // Use this for initialization
     void Start () {          
          GetWeb ();
     }

     // Update is called once per frame
     void Update () {
          if (!loading) {               
               GetWeb ();
          }
     }

     public void GetWeb(){
          WWWForm form = new WWWForm();
          form.AddField("action", "2");
          WWW www = new WWW(url, form);

          loading = true;
          StartCoroutine(WaitForRequest(www));
     }

     IEnumerator WaitForRequest(WWW www)
     {
          yield return www;

          // check for errors
          if (www.error == null)
          {
               Debug.Log("WWW Ok!: " + www.data);
               Vector2 newVelocity = JsonUtility.FromJson<Vector2> (www.data);
//
//               transform.position = newPosition;

               GetComponent<ShipController> ().ModifyVelocity (newVelocity.x);

          } else {
               Debug.Log("WWW Error: "+ www.error);
          }

          loading = false;
          lastPost = Time.time;
     }   
}
