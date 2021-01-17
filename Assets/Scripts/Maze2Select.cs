using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maze2Select : MonoBehaviour
{
    public static bool map_select = false;

    public GameObject toggle;
    //public Toggle tog;


    public void maze1_easy() {
        
        Debug.Log(toggle.GetComponent<Toggle>().isOn);
        map_select = toggle.GetComponent<Toggle>().isOn;
        SceneManager.LoadScene("Maze2_easy");
    }

    public void maze1_medium() {
        map_select = toggle.GetComponent<Toggle>().isOn;
        SceneManager.LoadScene("Maze2_medium");
    }

    public void maze1_hard() {
        map_select = toggle.GetComponent<Toggle>().isOn;
        SceneManager.LoadScene("Maze2_hard");
    }

    public void maze1_superhard() {
        map_select = toggle.GetComponent<Toggle>().isOn;
        SceneManager.LoadScene("Maze2_superhard");
    }

    public void goback() {
        SceneManager.LoadScene("Start");
    }
}
