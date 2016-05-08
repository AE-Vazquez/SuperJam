using UnityEngine;
using System.Collections;

public class WebController : MonoBehaviour {     
     public string url = "http://www.costacar.com/unityTest.php";

     private bool loading = false;
     public float lastSpeed = 0;

     // Use this for initialization
     void Start () {          
          GetWeb ();
     }

     // Update is called once per frame
     void Update () {
          if (!loading) {               
               GetWeb ();
          }

          GetComponent<ShipController> ().ModifyVelocity (lastSpeed);
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
               Debug.Log("WWW Ok!: " + www.text);
               Vector2 newVelocity = JsonUtility.FromJson<Vector2> (www.text);

               if (newVelocity.x > 0) {
                    lastSpeed = -1;
               }else if(newVelocity.x < 0){
                    lastSpeed = 1;
               }
               //GetComponent<ShipController> ().ModifyVelocity (newVelocity.x);

          } else {
               Debug.Log("WWW Error: "+ www.error);
          }

          loading = false;       
     }   
}
