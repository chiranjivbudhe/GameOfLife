using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour {

    private Transform gridHolder;
    private GameObject grid;
    public Camera main;

    public int rows;
    public int cols;
    public Slider rowColSlider;
    public Cell cell;
    public List<List<Cell>> allCells; 

    void BoardSetup()
    {
        if (gridHolder != null)
        {
            Destroy(grid);
        }
        grid = new GameObject("Grid");
        gridHolder = grid.transform;
        allCells = new List<List<Cell>>();

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
    }
    public void ChangeNumberOfRowColValue()
    {
        Vector3 cameraPosition = new Vector3(main.GetComponent<Transform>().position.x, main.GetComponent<Transform>().position.y, main.GetComponent<Transform>().position.z);
        main.GetComponent<Transform>().position = new Vector3(cameraPosition.x + ((int)rowColSlider.value > rows ? (.02f * rows) : - (.02f * rows)), cameraPosition.y + ((int)rowColSlider.value > rows ?  (.02f * rows) : - (.02f * rows)), (main.GetComponent<Transform>().position.z + ((int)rowColSlider.value > rows ? -1 : +1 )));
        cols = rows = (int)rowColSlider.value;
        BoardSetup();
    }

}
