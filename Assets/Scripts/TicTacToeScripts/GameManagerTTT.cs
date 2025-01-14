using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTTT : MonoBehaviour
{
    public static GameManagerTTT instance;

    public string[] grid;

    public int indexOfCell;

    public int mTurnCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            grid = new string[9];

            for (int i = 0; i < grid.Length; i++)
                grid[i] = "";

            instance = this;

            DontDestroyOnLoad(gameObject); // Keeps this object alive between scenes
            //DontDestroyOnLoad(myCanvas.gameObject);
        }
    }

    public void AddWinningPlayer(string winningPlayer)
    {
        mTurnCount++;
        grid[indexOfCell] = winningPlayer;
        Debug.Log(grid[indexOfCell]);
    }
}
