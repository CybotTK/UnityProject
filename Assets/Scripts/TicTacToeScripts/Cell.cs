using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    public TextMeshProUGUI mLabel;
    public Image targetImage;
    public Sprite redChickenSprite;
    public Sprite cyanChickenSprite;
    public Button mButton;
    public TicTacToeMain mMain;

    public void Fill()
    {
        mButton.interactable = false;

        mLabel.text = mMain.GetTurnCharacter();
        Color color = mLabel.color;
        color.a = 0; // Fully transparent
        mLabel.color = color;

        if (mMain.GetTurnCharacter() == "X") {
            targetImage.sprite = redChickenSprite;
            color = targetImage.color;
            color.a = 1 ;
            targetImage.color = color;

        }
        else
        {
            targetImage.sprite= cyanChickenSprite;
            color = targetImage.color;
            color.a = 1;
            targetImage.color = color;
        }

        mMain.Switch();
    }
}
