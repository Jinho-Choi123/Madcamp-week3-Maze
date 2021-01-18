using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void startgame() {
        SceneManager.LoadScene("Start");

    }

    public void singleplayer() {
        SceneManager.LoadScene("Maze1_select");
    }

    public void twoplayer() {
        SceneManager.LoadScene("Maze2_select");
    }
    
    public void back() {
        SceneManager.LoadScene("Title");
    }

    public void exit() {
        Application.Quit();
    }
    public void setting() {
        SceneManager.LoadScene("Setting");
    }

    public void info() {
       SceneManager.LoadScene("Info");
    }

}
