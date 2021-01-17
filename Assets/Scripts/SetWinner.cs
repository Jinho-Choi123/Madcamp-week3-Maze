using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWinner : MonoBehaviour
{
    string winner;
    public Text txt;

    void Start()
    {
        if(BasicMove.winner == "") {
            winner = BasicMoveRed.winner;
        }
        else {
            winner = BasicMove.winner;
        }
        txt.GetComponent<UnityEngine.UI.Text>().text = winner;
    }

}
