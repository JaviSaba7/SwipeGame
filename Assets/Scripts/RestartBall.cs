using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBall : MonoBehaviour {

    
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;

    public SwipeBall1 swipeSystem1;
    public SwipeBall2 swipeSystem2;

    public SwipeBall3 swipeSystem3;
    public SwipeBall4 swipeSystem4;
    public SwipeBall5 swipeSystem5;
    //public SwipeBall6 swipeSystem6;

    public float respawnBall2;
    public float respawnBall3;

    public float respawnBall4;
    public float respawnBall5;
    public float respawnBall6;


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
            if(respawnBall2 >= 10)
            {
                ball2.SetActive(true);
                swipeSystem1.ball1Thrown = false;
                respawnBall2 = 0;
            }
       }

       if (swipeSystem2.ball2Thrown == true)
        {
            respawnBall3++;
            if (respawnBall3 >= 10)
            {
                ball3.SetActive(true);
                swipeSystem2.ball2Thrown = false;
                respawnBall3 = 0;
            }
        }

       if (swipeSystem3.ball3Thrown == true)
        {
            respawnBall4++;
            if (respawnBall4 >= 10)
            {
                ball4.SetActive(true);
                swipeSystem3.ball3Thrown = false;
                respawnBall4 = 0;
            }
        }


        if (swipeSystem4.ball4Thrown == true)
        {
            respawnBall5++;
            if (respawnBall5 >= 10)
            {
                ball5.SetActive(true);
                swipeSystem4.ball4Thrown = false;
                respawnBall5 = 0;
            }
        }

    }
}
