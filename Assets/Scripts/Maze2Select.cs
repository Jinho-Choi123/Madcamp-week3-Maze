using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze2Select : MonoBehaviour
{
    
    public void maze1_easy() {
        SceneManager.LoadScene("Maze2_easy");
    }

    public void maze1_medium() {
        SceneManager.LoadScene("Maze2_medium");
    }

    public void maze1_hard() {
        SceneManager.LoadScene("Maze2_hard");
    }

    public void maze1_superhard() {
        SceneManager.LoadScene("Maze2_superhard");
    }

    public void goback() {
        SceneManager.LoadScene("Start");
    }
}
