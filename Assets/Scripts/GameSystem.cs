using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    
    public float timeToStart = 3.0f;
    public float timeofGame = 60.0f;
    public float score;
    public Text scoreText;
    public Text counterToStartText;
    public Text gameTimeText;
    public bool startGame;
    public bool startToPlay;
    public GameObject reset;

    public float counter;
    public bool turnOff = false;
    // Use this for initialization
    void Start ()
    {
        score = 0;
        startGame = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (turnOff) counter++;
        if (counter > 60)
        {
            Debug.Log("TIME PASADO");

            counter = 0;
            turnOff = false;
        }

        if (startGame)
        {
            counterToStartText.text = timeToStart.ToString("0");
            timeToStart -= Time.deltaTime;
        }

        if(timeToStart < 0)
        {
            counterToStartText.enabled = false;
            gameTimeText.enabled = true;
            startToPlay = true;
            timeToStart = 3;
            startGame = false;
        }

        if(startToPlay)
        {
            gameTimeText.text = timeofGame.ToString("0");
            timeofGame -= Time.deltaTime;
            
        }

        if (timeofGame < 0.0f)
        {
            timeofGame = 0.0f;
            //reset.SetActive(true);
            //characters.SetActive(false);

        }

        scoreText.text = score.ToString("");

    }
}
    
