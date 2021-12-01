using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void EndGame(){
        SceneManager.LoadScene("EndGame");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Debug.Log("quitting");
        Application.Quit(0);
    }
}
