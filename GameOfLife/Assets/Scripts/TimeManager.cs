using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    GameManager gameManagerScript;
    Neighbour neighbourScript;
    public float timer = 0f;

    // Use this for initialization
    void Start () {
        neighbourScript = GameObject.FindGameObjectWithTag("Neighbours").GetComponent<Neighbour>();
        gameManagerScript = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();

    }
	
    public void SetFrameRate()
    {
        if (timer < gameManagerScript.gameRate)
        {
           timer ++;
        }
        else
        {
            timer = 0f;
            neighbourScript.IterateEachCell();
        }
    }
}
