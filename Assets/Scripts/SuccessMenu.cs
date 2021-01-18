using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessMenu : MonoBehaviour
{
    public void playAgain() {
        SceneManager.LoadScene(StartGame.game_type);
    }

    public void gotoMenu() {
        SceneManager.LoadScene("Title");
    }

    public void exit(){
        Application.Quit();
    }
}
