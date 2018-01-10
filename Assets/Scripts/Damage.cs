using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{//crear el gameobject cuando me deje


    public GameObject particles;



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
            //lose.setActive(true);
        }
    }
}

