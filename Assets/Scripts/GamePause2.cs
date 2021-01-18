using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause2 : MonoBehaviour
{

    public GameObject maincamera1;
    public GameObject maincamera2;
    public GameObject maincamera3;
    public GameObject pauseCamera;
    private bool isPause = false;

    public void SetPause() {
        if(!isPause) {
            pauseCamera.SetActive(true);
            maincamera1.SetActive(false);
            maincamera2.SetActive(false);
            maincamera3.SetActive(false);
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
            maincamera1.SetActive(true);
            maincamera2.SetActive(true);
            maincamera3.SetActive(true);
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
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isPause == false) {
                SetPause()    ;
            } else {
                Continue();
            }
        }
        
    }
}
