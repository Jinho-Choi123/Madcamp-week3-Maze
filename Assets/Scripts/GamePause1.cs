using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause1 : MonoBehaviour
{

    public GameObject maincamera;
    public GameObject pauseCamera;
    private bool isPause = false;

    public void SetPause() {
        if(!isPause) {
            maincamera.SetActive(false);
            pauseCamera.SetActive(true);
            isPause = true;
            Time.timeScale = 0;
            //pausePanel.gameObject.SetActive(true);
        }
    }

    public void gotoMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

    public void playAgain() {
        Time.timeScale = 1;
        isPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue() {
        if(isPause) {
            maincamera.SetActive(true);
            pauseCamera.SetActive(false);
            isPause = false;
            Time.timeScale = 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            if(isPause == false) {
                SetPause();
            } else {
                Continue();
            }
        }

        
    }
}
