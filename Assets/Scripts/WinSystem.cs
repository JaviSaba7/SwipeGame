using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class WinSystem : MonoBehaviour {

    public SwipeBall1 swipeSystem;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (swipeSystem.activeTime) swipeSystem.timeGame -= 0.1f;
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
