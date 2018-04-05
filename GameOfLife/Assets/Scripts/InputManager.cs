using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestatus
{
    stop,
    pause,
    unPause,
    next,
    start,
}

public class InputManager : MonoBehaviour {

    TimeManager timeManagerScript;
    Neighbour neighbourScript;

    public int gameStatus;
 
    public int GameStatus
    {
        get { return gameStatus; }
        set { gameStatus = value; }
    }

    // Use this for initialization
    private void Awake()
    {
        timeManagerScript = GetComponent<TimeManager>();
        neighbourScript = GameObject.FindGameObjectWithTag("Neighbours").GetComponent<Neighbour>();
    }

    private void Update()
    {
        CheckInput();
    }

    public void StartGame()
    {
        GameStatus = (int)Gamestatus.start;
    }

    public void PauseGame()
    {
        GameStatus = (int)Gamestatus.stop;
    }

    public void NextStep()
    {
        GameStatus = (int)Gamestatus.next;
    }

    public void CheckInput()
    {
        if (GameStatus == (int)Gamestatus.start)
        {
            timeManagerScript.SetFrameRate();
        }
        else if (GameStatus == (int)Gamestatus.stop)
        {
            Time.timeScale = 0;
        }
        else if (GameStatus == (int)Gamestatus.next)
        {
            neighbourScript.IterateEachCell();
            GameStatus = (int)Gamestatus.stop;
        }
    }
}
