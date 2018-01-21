using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBall : MonoBehaviour {

    public Transform prefab;
    public int ballNumber;
    public List<GameObject> balls;
    [SerializeField] private int counter;
    [SerializeField] private Vector3 initialPosition;
    // Use this for initialization
    void Start ()
    {
        initialPosition = new Vector3(0, 0.12f, -1.3f);
        GameObject tmp = Instantiate(prefab, initialPosition, Quaternion.identity).gameObject;
        balls.Add(tmp);
        counter = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(counter <= ballNumber)
        {
            int size = balls.Count - 1;
            
            SwipeBall1 s = balls[size].GetComponent<SwipeBall1>();

            if(s.ball1Thrown == true)
            {
                CreateBall();
            }
        }
           
    }

    private void CreateBall()
    {
        GameObject tmp = Instantiate(prefab, Vector3.zero, Quaternion.identity).gameObject;
        balls.Add(tmp);
        counter++;
    }
}
