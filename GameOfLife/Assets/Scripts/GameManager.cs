using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestatus
{
    stop,
    pause,
    unPause,
    start,
}

public class GameManager : MonoBehaviour {

    public GridManager gridManagerScript;
    TimeManager timeManagerScript;
    public bool startGame;
    public int gameStatus;
    public int numberOfGenerations;
    public float gameRate;

    public bool StartGame
    {
        get { return startGame;  }
        set { startGame = value; }
    }

    public int GameStatus
    {
        get { return gameStatus;  }
        set { gameStatus = value; }
    }

    private void Update()
    {
        GetInput();
        CheckInput();
    }

    private void Awake()
    {
        gridManagerScript = GetComponent<GridManager>();
        timeManagerScript = GetComponent<TimeManager>();
        InItGame();
    }

    void InItGame()
    {
        gameRate = 80f;
        gridManagerScript.SetUpScene();
    }

    void GetInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            GameStatus = (int)Gamestatus.start;
        else if (Input.GetKeyDown(KeyCode.S))
            GameStatus = (int)Gamestatus.stop;
        else if (Input.GetKeyDown(KeyCode.P))
            GameStatus = (int)Gamestatus.pause;
        else if (Input.GetKeyDown(KeyCode.U))
            GameStatus = (int)Gamestatus.unPause;
    }

    public void CheckInput()
    {
        if (GameStatus == (int)Gamestatus.start)
        {
            timeManagerScript.SetFrameRate();
        }
        else if (GameStatus == (int)Gamestatus.stop)
            Time.timeScale = 0;
    }


}
