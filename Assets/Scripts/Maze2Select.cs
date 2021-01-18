using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maze2Select : MonoBehaviour
{
    public Button easymode;
    
    public void maze1_easy() {
        StartGame.game_type = "Maze2_easy";
        SceneManager.LoadScene("Maze2_easy");
    }

    public void maze1_medium() {
        StartGame.game_type = "Maze2_medium";
        SceneManager.LoadScene("Maze2_medium");
    }

    public void maze1_hard() {
        StartGame.game_type = "Maze2_hard";
        SceneManager.LoadScene("Maze2_hard");
    }

    public void maze1_superhard() {
        StartGame.game_type = "Maze2_superhard";
        SceneManager.LoadScene("Maze2_superhard");
    }

    public void goback() {
        SceneManager.LoadScene("Start");
    }
}
