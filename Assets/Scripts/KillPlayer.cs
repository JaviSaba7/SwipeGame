using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{//crear el gameobject cuando me deje

    public GameObject youLose;

    public GameObject player;


    void Start()
    {

    }

    //Update
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kill")
        {
            player.SetActive(false);
            youLose.SetActive(true);
        }
    }
}

