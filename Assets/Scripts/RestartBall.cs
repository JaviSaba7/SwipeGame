using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBall : MonoBehaviour {

    
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;

    public SwipeBall1 swipeSystem1;
    public SwipeBall2 swipeSystem2;

    public SwipeBall3 swipeSystem3;


    public float respawnBall2;
    public float respawnBall3;

    public float respawnBall4;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(swipeSystem1.ball1Thrown == true)
       {
            respawnBall2++;
            if(respawnBall2 > 10)
            {
                ball2.SetActive(true);
            }
       }

        if (swipeSystem2.ball2Thrown == true)
        {
            respawnBall3++;
            if (respawnBall3 > 10)
            {
                ball3.SetActive(true);
            }
        }

        if (swipeSystem3.ball3Thrown == true)
        {
            respawnBall4++;
            if (respawnBall4 > 10)
            {
                ball4.SetActive(true);
            }
        }

    }
}
