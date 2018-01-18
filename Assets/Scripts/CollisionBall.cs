using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBall : MonoBehaviour {
    // Use this for initialization
    public GameObject particles;
	void Start ()
    {

	}

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ball")
        Debug.Log("COLLISION!!!!!");
        particles.SetActive(true);
    }
}
