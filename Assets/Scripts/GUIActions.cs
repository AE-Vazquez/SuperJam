using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIActions : MonoBehaviour {

     public void GoToCredits(){
          SceneManager.LoadScene ("Credits");
     }

     public void GoToNormalGame(){
          SceneManager.LoadScene ("NormalGame");
     }

     public void GoToVRGame(){
          SceneManager.LoadScene ("VRGame");
     }

     public void GoToMainMenu(){
          SceneManager.LoadScene ("MainMenu");
     }

     public void RestartGame(){
          Scene scn = SceneManager.GetActiveScene ();
          SceneManager.LoadScene (scn.name);
     }

     public void OpenExitPanel(){
          
     }

     public void CloseExitPanel(){

     }

     public void ExitGame(){
          Application.Quit ();
          //UnityEditor.EditorApplication.isPlaying = false;
     }

     public void OpenMenuPanel(){
          
     }

     public void CloseMenuPanel(){
          
     }
}
