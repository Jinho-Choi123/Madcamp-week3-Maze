using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maze2Select : MonoBehaviour
{
    public Button easymode;
    
    public void maze1_easy() {
        SceneManager.LoadScene("Maze2_easy");
    }

    public void maze1_medium() {
        SceneManager.LoadScene("Maze2_medium");
    }

    public void maze1_hard() {
        Destroy(easymode);
        SceneManager.LoadScene("Maze2_hard");
    }

    public void maze1_superhard() {
        SceneManager.LoadScene("Maze2_superhard");
    }

    public void goback() {
        SceneManager.LoadScene("Start");
    }
}
