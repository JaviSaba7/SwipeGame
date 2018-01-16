using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public GameObject monkey;// Use this for initialization
    public bool activeShot = false;
    public int animInfo;
    public float animCounter;

    public Animator anim;
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
       

        if (Input.GetKeyDown(KeyCode.C))
        {
            //pasamos el bool al animator para que sea la condicion
            monkey.GetComponent<Animator>().SetTrigger("isChuting");
        }
    }
}
