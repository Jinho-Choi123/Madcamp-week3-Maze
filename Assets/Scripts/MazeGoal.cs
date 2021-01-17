using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGoal : MonoBehaviour
{
    public void onCollisionEnter2D(Collision2D c) { 
        if(c.gameObject.GetComponent<SpriteRenderer>().material.color == Color.green) {
            Debug.Log("oncollision handling");
            SceneManager.LoadScene("Success");
        }

    }
}
