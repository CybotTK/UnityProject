using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour
{
    public TextMeshProUGUI mLabel;
    public Image targetImage;
    public Sprite redChickenSprite;
    public Sprite cyanChickenSprite;
    public Button mButton;
    public TicTacToeMain mMain;

    public string[] MinigameScenes;
    public int minigameIndex = 0;

    public int index = 0;

    public void LoadMinigame()
    {
        GameManagerTTT.instance.indexOfCell = index;
        SceneManager.LoadScene(MinigameScenes[minigameIndex]);
    }

    public void Fill(string winningPlayer)
    {
        mButton.interactable = false;

        mLabel.text = winningPlayer;
        Color color = mLabel.color;
        color.a = 0; // Fully transparent
        mLabel.color = color;

        if (mLabel.text == "Red")
        {
            targetImage.sprite = redChickenSprite;
            color = targetImage.color;
            color.a = 1;
            targetImage.color = color;

            mMain.Switch();
        }
        else if (mLabel.text == "Cyan")
        {
            targetImage.sprite = cyanChickenSprite;
            color = targetImage.color;
            color.a = 1;
            targetImage.color = color;

            mMain.Switch();
        }
        else 
        { 
            mButton.interactable = true;
        }
    }
}
