using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {
    // Use this for initialization
    public GameObject enemy;
    public GameObject particles;

    void Start ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Kill")
        {
            Debug.Log("COLLISION!!!!!");
            particles.SetActive(true);
            enemy.GetComponent<Animator>().enabled = false;
            enemy.GetComponent<Renderer>().enabled = false;
            
        }
            
           
       
    }

}
