using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    GameManager gameManagerScript;
    Neighbour neighbourScript;

    public Slider speedSlider;
    public float timer = 0f;
    float gameRate;

    // Use this for initialization
    void Start () {
        neighbourScript = GameObject.FindGameObjectWithTag("Neighbours").GetComponent<Neighbour>();
        gameManagerScript = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
        gameRate = gameManagerScript.gameRate;
        speedSlider.value = gameRate;
    }

    public void ChangeGameRate()
    {
        gameRate = speedSlider.value;
    }

    public void SetFrameRate()
    {
        if (timer < gameRate)
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
