using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    public static bool inSameMap = false;
    public static bool itemEnable = true;
    public GameObject sameMap_toggle;
    public GameObject itemEnable_toggle;

    public void goback() { 
        SceneManager.LoadScene("Title");
    
    }

    void Start() {

        sameMap_toggle.GetComponent<Toggle>().isOn = inSameMap;
        itemEnable_toggle.GetComponent<Toggle>().isOn = itemEnable;
        sameMap_toggle.GetComponent<Toggle>().onValueChanged.AddListener((bool bOn) => {
            Debug.Log("hello world");

            inSameMap = bOn;
        });

        itemEnable_toggle.GetComponent<Toggle>().onValueChanged.AddListener((bool bOn) => {
            Debug.Log("hello world");
            itemEnable = bOn;
        });

    }

}
