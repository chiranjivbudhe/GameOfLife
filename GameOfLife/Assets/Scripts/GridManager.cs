using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public int rows;
    public int cols;
    public Cell cell;
    private Transform gridHolder;
    public List<List<Cell>> allCells = new List<List<Cell>>(); 

    void BoardSetup()
    {
       
        gridHolder = new GameObject("Grid").transform;
        for (int colIndex = 1; colIndex <= cols; colIndex++)
        {
            List<Cell> subList = new List<Cell>();
            for (int rowIndex = 1; rowIndex <= rows; rowIndex++)
            {
                cell.cellID = int.Parse(colIndex + "" + rowIndex);
                Cell toInstantiate = Instantiate(cell, new Vector3(colIndex, rowIndex, 0f), Quaternion.identity) as Cell;
                toInstantiate.name = "Cell" + colIndex + "" + rowIndex;
                subList.Add(toInstantiate);
                toInstantiate.transform.SetParent(gridHolder);
            }
            allCells.Add(subList);
        }
    }

    public void SetUpScene()
    {
        BoardSetup();
       // InitializeList();
    }
}
