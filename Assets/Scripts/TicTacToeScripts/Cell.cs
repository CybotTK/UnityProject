using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    public TextMeshProUGUI mLabel;
    public Button mButton;
    public TicTacToeMain mMain;

    public void Fill()
    {
        mButton.interactable = false;

        mLabel.text = mMain.GetTurnCharacter();

        mMain.Switch();
    }
}
