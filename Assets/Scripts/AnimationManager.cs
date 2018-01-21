using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public GameObject monkey;// Use this for initialization

	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            monkey.GetComponent<Animator>().SetTrigger("isChuting"); //condition for doing the animation
        }
    }
}
