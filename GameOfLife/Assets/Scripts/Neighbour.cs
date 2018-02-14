using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cellStatus
{
    isDead  = 0,
    isAlive = 1,
}

public class Neighbour : MonoBehaviour {

    public GridManager gridManagerScript;
    public GameManager gameManagerScript;
    public NewCells newCellScript;
    int cellStatus;
   // List<List<int>> updatedCellList = new List<List<int>>();
 
    public int CellStatus
    {
        get
        {
            return cellStatus;
        }

        set
        {
            cellStatus = value;
        }
    }


    // Use this for initialization
    void Start () {
        gridManagerScript = GameObject.FindGameObjectWithTag("Managers").GetComponent<GridManager>();
        gameManagerScript = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
        newCellScript = GameObject.FindGameObjectWithTag("NewCellList").GetComponent<NewCells>();
    }

    public void IterateEachCell()
    {

        List<List<int>> updatedCellList = new List<List<int>>();
        for (int colIndex = 0; colIndex < gridManagerScript.cols; colIndex++)
        {
            List<int> updateSublist = new List<int>();
            for (int rowIndex = 0; rowIndex < gridManagerScript.rows; rowIndex++)
            {
                bool isCellAlive = gridManagerScript.allCells[colIndex][rowIndex].isAlive;
                int noOfAliveNeighbours = CheckNeighbours(colIndex, rowIndex);
                CellStatus = 0;

                if (isCellAlive && noOfAliveNeighbours > 3)
                    CellStatus = 0;
                if (isCellAlive && noOfAliveNeighbours < 2)
                    CellStatus = 0;
                if (isCellAlive && (noOfAliveNeighbours == 3 || noOfAliveNeighbours == 2))
                    CellStatus = 1;
                if (!isCellAlive && noOfAliveNeighbours == 3)
                    CellStatus = 1;

                updateSublist.Add(CellStatus);
            }
            updatedCellList.Add(updateSublist);
        }
        newCellScript.UpdateCellsOnBoard(updatedCellList);
        gameManagerScript.numberOfGenerations++;
    }

    int CheckNeighbours(int colIndex, int rowIndex)
    {
      
        int counter = 0;
        if (colIndex != (gridManagerScript.cols -1) && gridManagerScript.allCells[colIndex + 1][rowIndex].isAlive)
            counter++;
        if (colIndex != (gridManagerScript.cols - 1) && rowIndex != (gridManagerScript.rows - 1) && gridManagerScript.allCells[colIndex + 1][rowIndex+1].isAlive)
            counter++;
        if (colIndex != (gridManagerScript.cols - 1) && rowIndex != 0 && gridManagerScript.allCells[colIndex + 1][rowIndex-1].isAlive)
            counter++;
        if (colIndex != 0 && gridManagerScript.allCells[colIndex - 1][rowIndex].isAlive)
            counter++;
        if (colIndex != 0 && rowIndex != (gridManagerScript.rows - 1) && gridManagerScript.allCells[colIndex - 1][rowIndex+1].isAlive)
            counter++;
        if (colIndex != 0 && rowIndex != 0 && gridManagerScript.allCells[colIndex - 1][rowIndex-1].isAlive)
            counter++;
        if (rowIndex != (gridManagerScript.rows - 1) && gridManagerScript.allCells[colIndex][rowIndex+1].isAlive)
            counter++;
        if (rowIndex != 0 && gridManagerScript.allCells[colIndex][rowIndex-1].isAlive)
            counter++;

        return counter;
    }
}
