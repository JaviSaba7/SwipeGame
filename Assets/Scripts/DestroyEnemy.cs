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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            Debug.Log("COLLISION!!!!!");
            particles.SetActive(true);
            enemy.SetActive(false);
        }      
       
    }

}
