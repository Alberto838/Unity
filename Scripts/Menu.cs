using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void Options(){

    }

    public void Exit(){
        Application.Quit();
    }

    public static void ChangeScene(int sceneIndex){
        SceneManager.LoadScene(1);
    }


}
