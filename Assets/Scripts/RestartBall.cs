using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBall : MonoBehaviour {

    public Transform prefab;
    public int ballNumber;

    public List<GameObject> balls;

    [SerializeField] private int counter;
    [SerializeField] private Vector3 initialPosition;

    public float nextBall;
    public float timeOfRespawn = 3.0f;
    public float disappear;
    public float timeOfDisappear = 50.0f;
    public bool activeDisappear = false;
    public GameObject tmp;

    // Use this for initialization
    void Start()
    {
        initialPosition = new Vector3(0, 0.12f, -1.3f);


        tmp = Instantiate(prefab, initialPosition, Quaternion.identity).gameObject;


        balls.Add(tmp);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (counter <= ballNumber)
        {
            int size = balls.Count - 1;

            SwipeBall1 s = balls[size].GetComponent<SwipeBall1>();

            if (s.ballThrown == true)
            {
                nextBall++;

                if (nextBall >= timeOfRespawn)
                {
                    nextBall = 0;
                    CreateBall();
                }
            }
        }

    }

    private void CreateBall()
    {
        GameObject tmp = Instantiate(prefab, initialPosition, Quaternion.identity).gameObject;
        //Destroy(tmp, 5);

        //DestroyBall();

        balls.Add(tmp);
        counter++;
    }

    private void DestroyBall()
    {
        if(balls.Count > 0)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if(balls[i] == null)
                {
                    continue;
                }
                SwipeBall1 s = balls[i].GetComponent<SwipeBall1>();

                if (s.timeOfLife <= 0)
                {
                    GameObject tmp = balls[i];
                    balls.RemoveAt(i);
                    Destroy(tmp);
                }
            }
        }
    }



}
