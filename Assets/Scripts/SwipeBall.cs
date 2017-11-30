using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;

public class SwipeBall : MonoBehaviour
{
    //variables for swipe input detection
    private Vector3 firstFingerPosition; //First finger position
    private Vector3 lastFingerPosition; //Last finger position
    private Vector3 midFingerPosition;
    public float farXpos;
    private float dragDistance;  //Distance needed for a swipe to register


    public Vector3[] waypointsArray = new Vector3[3];

    public Vector3 midPosition;

    public float posX; //the mid position of the road
    public float posY; //the mid position of the road
    public float posZ; //the mid position of the road
    public float yo;
    public float yf;
    public float zo;
    public float zf;
    public float retry;

    bool retryActive;
    bool AddPointsToList = false;

    //variables for determining the shot power and position
    public float power;  //power at which the ball is shot
    private Vector3 footballPos; //initial football position for replacing the ball at the same posiiton
    public float timer = 0;
    public float saveTime;
    public bool canShoot = true;  //flag to check if shot can be taken

    public float factorX = 0.002f;

    Vector3 oppKickDir;   //direction at which the ball is kicked by opponent
    private bool returned = true;  //flag to check if the ball is returned to its initial position


    public float centerPosition =  537.0f;

    public Vector3 ballDirection; //direccion del balon determinado por el lastFingerPosition
    public float maxPositionX = 0.0f;
    public float minPositionX = 0.0f;
     
    public float distanceToObject = 10000.0f;
    public Rigidbody rb;
    bool ballThrowRight = false;
    bool ballThrowLeft = false;

    RaycastHit detection = new RaycastHit();

    // public Transform startMarker;
    // public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float swipeTime = 0;
    public List<float> pointsList;
    public bool canSwipe = false;
    public float MaxSwipeTime;

    void Start()
    {
        dragDistance = Screen.height * 20 / 100; //20% of the screen should be swiped to shoot

        footballPos = transform.position;  //store the initial position of the football

        startTime = Time.time;
        journeyLength = Vector3.Distance(rb.position, detection.point);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Checking min position  " + minPositionX);
        

        if (Input.GetButton("Fire1"))
        {
            rb.isKinematic = true;
            retryActive = true;
            saveTime = 0;
            timer = 0;
            retryActive = false;
            retry = 0.0f;
            rb.transform.position = new Vector3(0, 0.1f, -1.32f);
            maxPositionX = 0.0f;
            minPositionX = 0.0f;
            rb.isKinematic = false;
            Debug.Log("You are pressing R key!");
        }

        if (returned)
        {    
            playerLogic();   //call the playerLogic function
        }
       
        if (AddPointsToList) CheckMaxXPoint();//calling the function that determinates the X point.
       // if (AddPointsToList) CheckMinXPoint();//calling the function that determinates the X point.

    }

    void playerLogic() //All logic about the player
    {
        DoMouseTouch();
        return;
    }

    Vector3 RayCamera()
    {
        Ray rayDistance = Camera.main.ScreenPointToRay(Input.mousePosition);

        ballDirection = lastFingerPosition;

        if (Physics.Raycast(rayDistance, out detection, distanceToObject))
        {
            if (detection.collider.gameObject != null)
            {

                Debug.Log(detection.transform.name + "  " + detection.point);
               // ballThrowRight = false;
                return detection.point;
                
            }
        }

        Debug.LogError(" no world point found");
        return Vector3.zero;

        //if (ballThrowRight == true)
        //{
        //    //rb.isKinematic = true;
               
        //}

        //if (ballThrowLeft == true)
        //{
        //    //rb.isKinematic = true;
        //    if (Physics.Raycast(rayDistance, out detection, distanceToObject))
        //    {
        //        if (detection.collider.gameObject != null)
        //        {

        //            Debug.Log(detection.transform.name + "  " + detection.point);
        //            throwLeft(detection.point);
        //            ballThrowLeft = false;
        //        }
        //    }
        //}

    }

    private void throwRight(Vector3 EndPoint)
    {
        Vector3 iPosition = rb.position;
        Vector3 fPosition = EndPoint;

        /*float timeBall = 0.0f;
        float distanceBall = 1.0f;
 
        float result = timeBall / distanceBall;
        timeBall += Time.deltaTime;*/

        yo = 0.1080177f;
        yf = EndPoint.y;
        zo = 0;
        zf = EndPoint.z;

        posX = maxPositionX;
        posY = (saveTime / timer) * (yf - yo) + yo;
        posZ = (saveTime / timer) * (zf - zo) + zo;

        midPosition = new Vector3((posX)*factorX, posY, posZ);
                      

        waypointsArray = new Vector3[3];
        waypointsArray[0] = iPosition;
        waypointsArray[1] = midPosition;
        waypointsArray[2] = fPosition;

        rb.DOPath(waypointsArray, 2.0f, PathType.CatmullRom, PathMode.Full3D, 100, Color.blue);

        Debug.DrawRay(iPosition, fPosition, Color.red);
        retryActive = true;
    }

    private void throwLeft(Vector3 EndPoint)
    {
        Vector3 iPosition = rb.position;
        Vector3 fPosition = EndPoint;

       /* float timeBall = 0.0f;
        float distanceBall = 1.0f;

        float result = timeBall / distanceBall;
        timeBall += Time.deltaTime;*/

        yo = 0.1080177f;
        yf = EndPoint.y;
        zo = 0;
        zf = EndPoint.z;

        posX = minPositionX - centerPosition;
        posY = (saveTime / timer) * (yf - yo) + yo;
        posZ = (saveTime / timer) * (zf - zo) + zo;

        midPosition = new Vector3((posX) * factorX, posY, posZ);



        waypointsArray = new Vector3[3];
        waypointsArray[0] = iPosition;
        waypointsArray[1] = midPosition;
        waypointsArray[2] = fPosition;

        rb.DOPath(waypointsArray, 1.0f, PathType.CatmullRom, PathMode.Full3D, 5, Color.blue);

        Debug.DrawRay(iPosition, fPosition, Color.red);
        retryActive = true;

    }
    
    private void DoMouseTouch()
    {

        if (Input.GetMouseButtonDown(0))
        {
            canSwipe = true;

        }

        if (canSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {

                firstFingerPosition = Input.mousePosition;
                lastFingerPosition = Input.mousePosition;

                AddPointsToList = true;
                maxPositionX = 0;
                //maxPositionX = Input.mousePosition.x;
                // minPositionX = Input.mousePosition.x;

            }

            if (Input.GetMouseButton(0))
            {
                timer++;
                swipeTime++;
                if (swipeTime > MaxSwipeTime)
                {
                    
                    Kick(Input.mousePosition);

                    canSwipe = false;
                    Debug.Log("Do the swipe in less time");
                }
            }

            if (Input.GetMouseButtonUp(0))        //if (touch.phase == TouchPhase.Ended)
            {
                Kick(Input.mousePosition);
            }

        }

        if (retryActive) retry++;

        if (retry >= 50.0f)
        {
            saveTime = 0;
            timer = 0;
            retryActive = false;
            retry = 0.0f;
            rb.transform.position = new Vector3(0, 0.1f, 0);
            maxPositionX = 0.0f;
            minPositionX = 0.0f;

        }
        
       

    }

    private void Kick(Vector3 lastPosition)
    {
        swipeTime = 0;
        lastFingerPosition = lastPosition;

        ballThrowRight = (maxPositionX > Screen.width / 2) ? true : false;
        //if (maxPositionX <= Screen.width / 2) ballThrowLeft = true;


        Debug.Log("BALL THROW MAX RIGHT STATE  " + maxPositionX);
        Debug.Log("BALL THROW MIN LEFT  STATE  " + minPositionX);
        

        AddPointsToList = false;

        var worldEndPoint = RayCamera();
        throwRight(worldEndPoint);
    }

    void CheckMaxXPoint() //Which is the biggest point of X? (touhing the screen)
    {
        var difToCenter = Input.mousePosition.x - Screen.width / 2;
        Debug.Log(difToCenter + "  " + Input.mousePosition.x);
        if(Mathf.Abs(difToCenter) > Mathf.Abs(maxPositionX))
        {
            maxPositionX = difToCenter;
        }
        Debug.Log("Checking max position  " + maxPositionX);
        //if (maxPositionX < Input.mousePosition.x)
        //{
        //    maxPositionX = Input.mousePosition.x;
        //    saveTime = timer;

        //}
    }

    void CheckMinXPoint() //Which is the littlest point of X? (touhing the screen)
    {

        //minPositionX = Input.mousePosition.x;
        if (minPositionX < Input.mousePosition.x)
        {
           // minPositionX = minPositionX;

        }
        else
        {
            minPositionX = Input.mousePosition.x;
            saveTime = timer;

        }







    }

    IEnumerator DelayAdd()
    {
        yield return new WaitForSeconds(0.2f); 
    }

}