using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellStatus
{
    isDead = 0,
    isAlive = 1,
}

public class Cell : MonoBehaviour {

    public int cellID;
    public Renderer _renderer;
    public bool isAlive;
    public Material isAliveMaterial;
    public Material isDeadMaterial;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        _renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
     
    }

    int GetCellID(RaycastHit hit)
    {
        return hit.collider.gameObject.GetComponent<Cell>().cellID;
    }

    bool CompareObjectMaterial(Material checkMaterial)
    {
        return checkMaterial == _renderer.sharedMaterial;
    }

    void GetInput(int cellID)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && cellID == GetCellID(hit) && CompareObjectMaterial(isDeadMaterial))
        {
            _renderer.material = isAliveMaterial;
            isAlive = true;
        }
        else if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit) && cellID == GetCellID(hit) && CompareObjectMaterial(isAliveMaterial))
        {
            _renderer.material = isDeadMaterial;
            isAlive = false;
        }
    }

    private void OnMouseOver()
    {
        int cellID = gameObject.GetComponent<Cell>().cellID;
        GetInput(cellID);
    }
}
