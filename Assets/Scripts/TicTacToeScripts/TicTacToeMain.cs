using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTacToeMain : MonoBehaviour
{
    public Board mBoard;
    public GameObject mWinner;

    private bool mXTurn = true;

    void Start()
    {
        mBoard.Build(this);
    }

    public void Switch ()
    {
        string hasWinner = mBoard.CheckForWinner();

        if (hasWinner != "noWinner" || GameManagerTTT.instance.mTurnCount == 9) 
        {
            //sfarsit joc
            StartCoroutine(EndGame(hasWinner));

            return;
        }

        mXTurn = !mXTurn;
    }

    public string GetTurnCharacter()
    {
        if(mXTurn)
        {
            return "X";
        }
        else
        {
            return "O";

        }
    }

    private IEnumerator EndGame(string hasWinner)
    {

        TextMeshProUGUI winnerLabel = mWinner.GetComponentInChildren<TextMeshProUGUI>();

        if(hasWinner != "noWinner")
        {
            winnerLabel.text = hasWinner + " " + "Won!";
        }
        else
        {
            winnerLabel.text = "Draw!";
        }

        mWinner.SetActive(true);

        WaitForSeconds wait = new WaitForSeconds(1.0f);
        yield return wait;

        mBoard.Reset();
        GameManagerTTT.instance.mTurnCount = 0;

        mWinner.SetActive(false);
    }
}
