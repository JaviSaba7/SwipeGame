using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject enemy;
    public float positionX;
    
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (enemy.transform.position.x <= -2)
        {
            
        }
        else
        {
            positionX--;
        }
       
        
	}
}
