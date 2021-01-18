using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze1Select : MonoBehaviour
{
    
    public void maze1_easy() {
        StartGame.game_type = "Maze1_easy";
        SceneManager.LoadScene("Maze1_easy");
    }

    public void maze1_medium() {
        StartGame.game_type = "Maze1_medium";
        SceneManager.LoadScene("Maze1_medium");
    }

    public void maze1_hard() {
        StartGame.game_type = "Maze1_hard";
        SceneManager.LoadScene("Maze1_hard");
    }

    public void maze1_superhard() {
        StartGame.game_type = "Maze1_superhard";
        SceneManager.LoadScene("Maze1_superhard");
    }

    public void goback() {
        SceneManager.LoadScene("Start");
    }
}
