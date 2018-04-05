using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    TimeManager timeManagerScript;

    public Text text;
    public GridManager gridManagerScript;

    public int numberOfGenerations;
    public float gameRate;
   
    private void Update()
    {
        SetUpGenerationCount();
    }

    private void Awake()
    {
        gridManagerScript = GetComponent<GridManager>();
        timeManagerScript = GetComponent<TimeManager>();
        InItGame();
    }

    void InItGame()
    {
        gameRate = 20f;
        gridManagerScript.SetUpScene();
    }

    public void SetUpGenerationCount()
    {
        text.text = "Generation Count: " + numberOfGenerations;
    }
}
