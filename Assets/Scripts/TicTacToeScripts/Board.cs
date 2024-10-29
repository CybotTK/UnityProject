using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject mCellPrefab;

    private Cell[] mCells = new Cell[9];

    public void Build(TicTacToeMain main)
    {
        for(int i = 0; i<=8; i++)
        {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            mCells[i] = newCell.GetComponent<Cell>();
            mCells[i].mMain = main;
        }
    }

    public void Reset()
    {
        foreach(Cell cell in mCells)
        {
            cell.mLabel.text = "";

            cell.mButton.interactable = true;
        }
    }

    public bool CheckForWinner()
    {
        int i = 0; 

        //orizontal
        for(i=0;i<=6; i+= 3)
        {
            if (!CheckValues(i, i + 1))
                continue;

            if (!CheckValues(i, i + 2))
                continue;

            return true;
        }

        //vertical
        for (i = 0; i <= 2; i ++)
        {
            if (!CheckValues(i, i + 3))
                continue;

            if (!CheckValues(i, i + 6))
                continue;

            return true;
        }

        //diagonala stanga
        if(CheckValues(0,4) && CheckValues(0,8))
            return true;

        //diagonala dreapta
        if (CheckValues(2, 4) && CheckValues(2, 6))
            return true;

        return false;
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
