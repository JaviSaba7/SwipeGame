using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine.UI;


public class KillPlayer : MonoBehaviour
{//crear el gameobject cuando me deje

    public GameObject youLose;
    public SwipeBall1 swipeSystem;
    public GameObject player;


    void Start()
    {

    }

    //Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("YOU LOSE!");
            swipeSystem.activeTime = false;

        }
    }

 
public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kill")
        {
            player.SetActive(false);
            youLose.SetActive(true);
            Debug.Log("YOU LOSE");
        }
    }
}

