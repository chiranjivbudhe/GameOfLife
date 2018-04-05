using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCells : MonoBehaviour {

    GridManager gridManagerScript;
 
	// Use this for initialization
	void Start () {
        gridManagerScript = GameObject.FindGameObjectWithTag("Managers").GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateCellsOnBoard(List<List<int>> updateCellList)
    {
        for (int colIndex = 0; colIndex < gridManagerScript.cols; colIndex++)
        {
            for (int rowIndex = 0; rowIndex < gridManagerScript.rows; rowIndex++)
            {
                if (updateCellList[colIndex][rowIndex] == 0)
                {
                    gridManagerScript.allCells[colIndex][rowIndex].isAlive = false;
                    gridManagerScript.allCells[colIndex][rowIndex]._renderer.material = gridManagerScript.allCells[colIndex][rowIndex].isDeadMaterial;
                }
                else if (updateCellList[colIndex][rowIndex] == 1)
                {
                    gridManagerScript.allCells[colIndex][rowIndex].isAlive = true;
                    gridManagerScript.allCells[colIndex][rowIndex]._renderer.material = gridManagerScript.allCells[colIndex][rowIndex].isAliveMaterial;
                }
            }
        }
    }
}
