using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIActions : MonoBehaviour {

     public void GoToCredits(){
          SceneManager.LoadScene ("Credits");
     }

     public void GoToColaborativeGame(){
          PlayerPrefs.SetString("gameMode" , "COLABORATIVE");
          SceneManager.LoadScene ("VRGame");
     }

     public void GoToNormalGame(){
          PlayerPrefs.SetString("gameMode" , "NORMAL");
          SceneManager.LoadScene ("VRGame");
     }

     public void GoToVRAlert(){
          SceneManager.LoadScene ("VRAlert");
     }

     public void GoToVRGame(){
          PlayerPrefs.SetString("gameMode" , "VR");
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
