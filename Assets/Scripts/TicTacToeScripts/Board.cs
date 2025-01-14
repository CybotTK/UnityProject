using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject mCellPrefab;

    public Cell[] mCells = new Cell[9];

    public void Build(TicTacToeMain ticTacToeMain)
    {
        for (int i = 0; i <= 8; i++)
        {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            mCells[i] = newCell.GetComponent<Cell>();
            mCells[i].mMain = ticTacToeMain;
            mCells[i].index = i;
            mCells[i].minigameIndex = i;
        }

        if (GameManagerTTT.instance.grid == null || GameManagerTTT.instance.grid.Length != 9)
        {
            Debug.LogError("Grid is not properly initialized.");
            return; // Exit if grid is not initialized
        }

        for (int i = 0; i < 9; i++)
        {
            if (mCells[i] != null)
            {
                mCells[i].Fill(GameManagerTTT.instance.grid[i]);
            }
            else
            {
                Debug.LogError($"Cell {i} is null.");
            }
        }
    }

    public void Reset()
    {
        foreach(Cell cell in mCells)
        {
            cell.mLabel.text = ""; 
            UnityEngine.Color color = cell.targetImage.color;
            color.a = 0;
            cell.targetImage.color = color;
            cell.targetImage = null;
            cell.mButton.interactable = true;
        }

        for (int i = 0; i < 9; i++)
        {
            GameManagerTTT.instance.grid[i]="";
        }
    }

    public string CheckForWinner()
    {
        int i = 0; 

        //orizontal
        for(i=0;i<=6; i+= 3)
        {
            if (!CheckValues(i, i + 1))
                continue;

            if (!CheckValues(i, i + 2))
                continue;

            return mCells[i].mLabel.text;
        }

        //vertical
        for (i = 0; i <= 2; i ++)
        {
            if (!CheckValues(i, i + 3))
                continue;

            if (!CheckValues(i, i + 6))
                continue;

            return mCells[i].mLabel.text;
        }

        //diagonala stanga
        if(CheckValues(0,4) && CheckValues(0,8))
            return mCells[0].mLabel.text;

        //diagonala dreapta
        if (CheckValues(2, 4) && CheckValues(2, 6))
            return mCells[2].mLabel.text;

        return "noWinner";
    }

    private bool CheckValues(int firstIndex, int secondIndex)
    {
        string firstValue = mCells[firstIndex].mLabel.text;
        string secondValue = mCells[secondIndex].mLabel.text;

        if (firstValue == "" || secondValue == "")
            return false;

        if (firstValue == secondValue)
            return true;
        else
            return false;
    }
}
