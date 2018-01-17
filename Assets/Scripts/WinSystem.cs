using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class WinSystem : MonoBehaviour {

    public SwipeBall1 swipeSystem;
    public float timeToStart = 3.0f;
    public Text counterToStart;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(swipeSystem.startGame)
        {
            counterToStart.text = timeToStart.ToString("0") + "s";
        }


        if(timeToStart < 0)
        {
            counterToStart.enabled = false;
            swipeSystem.activeTime = true;
        }

        if (swipeSystem.startGame) timeToStart -= Time.deltaTime;

        if (swipeSystem.activeTime) swipeSystem.timeGame -= Time.deltaTime;
        //Debug.Log("TIME GAME = " + timeGame);
        swipeSystem.counterText.text = swipeSystem.timeGame.ToString("00.00") + "s";

        if (swipeSystem.timeGame <= 0)
        {
            swipeSystem.winText.SetActive(true);
            swipeSystem.timeGame = 0;
            swipeSystem.activeTime = false;
        }
        if (swipeSystem.timeGame == 0) Debug.Log("YOU WIN!");
        if (Input.GetKeyDown(KeyCode.W))
        {
            swipeSystem.timeGame = 0;
            if (swipeSystem.timeGame == 0)
            {
                Debug.Log("YOU WIN!");

            }
            swipeSystem.activeTime = false;


        }

    }
}
