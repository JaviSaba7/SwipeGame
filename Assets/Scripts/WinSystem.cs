using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class WinSystem : MonoBehaviour {

    public float timeToStart = 3.0f;
    public float timeofGame = 30.0f;
    public float score;
    public Text scoreText;
    public Text counterToStartText;
    public Text gameTimeText;
    public bool startGame;
    public bool startToPlay;

    public float timeOfGame = 30.0f;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            startGame = true;

        }

        if (startGame)
        {
            counterToStartText.text = timeToStart.ToString("0") + "s";
            timeToStart -= Time.deltaTime;
        }

        if(timeToStart < 0)
        {
            counterToStartText.enabled = false;
            gameTimeText.enabled = true;
            startToPlay = true;
        }

        if(startToPlay)
        {
            gameTimeText.text = timeofGame.ToString("0");
            timeofGame -= Time.deltaTime;
        }

        scoreText.text = score.ToString("");
        

        score = 3;




        if (timeOfGame == 0) Debug.Log("YOU WIN!");
      
    }
}
