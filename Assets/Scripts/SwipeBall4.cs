using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class SwipeBall4 : MonoBehaviour
{
    [Header("Vector3")]
    public Vector3 firstFingerPosition;
    public Vector3 lastFingerPosition; 
    public Vector3[] waypointsArray = new Vector3[3];
    public Vector3 midPosition;
    public Vector3 midPosition2;
    public Vector3 initialPosition = new Vector3(0, 0.1f, -1.32f);
    public Vector3 footballPos;
    public Vector3 ballDirection;
    public Vector3 iPosition;
    public Vector3 fPosition;
    public GameObject ball1;
    public EnemyBehaviour enemyShoot;
    [Header("Floats")]
    public float timeForRestart = 0;
    public float timeForDoSwipe;
    public float maxTimeForDoSwipe = 60.0f;
    public float timer = 0;
    public float positionY;
    public float saveTime2;
    public float saveTime;
    public float factorX = 0.002f;
    public float positionX = 0.0f;
    Vector2 PosMaxX;
    Vector2 PosMaxY;
    public float posX;
    public float posY; 
    public float posZ; 
    public float yo;
    public float yf;
    public float zo;
    public float zf;
    public float xo;
    public float xf;
    public float distanceToObject = 10000.0f;
    public float speed = 1.0F;
    public float startTime;
    public float journeyLength;
    public float maxSwipeTime;
    public float swipeTime = 0;
    public float distance = 200.0f;
    [Header("Booleans")]
    public bool canSwipe;
    public bool retryActive;
    public bool AddPointsToList = false;
    public bool ballThrowRight = false;
    public bool ballThrowLeft = false;
    public bool playGame = true;
    public bool makeReal = false;
    public Rigidbody rb;
    public bool restartBall = false;
    public GameObject particles;
    RaycastHit detection = new RaycastHit();
    public Collider ball;
    public GameObject enemy;
    public bool activeTime;
    public AnimationManager anim;
    public GameObject enemy2;
    public GameObject enemy3;
    public float timeGame = 60.0f;
    public Text counterText;
    public float appearBall2 = 0;
    public GameObject ball2;
    public bool enemyShooting = false;
    public bool appearBall2Bool = false;
    public GameObject ball4;
    public RestartBall restartSystem;

    public bool ball4Thrown = false;
    public GameObject winText;
    //Start
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(rb.position, detection.point);
        canSwipe = false;
        timeGame = 60.0f;
    }

    //Update
    void Update()
    {
        if (Input.GetButton("Fire1")) Retry();
        if (playGame) playerLogic();
        if (AddPointsToList) CheckXPoint();
        MakeBallReal();

        if (makeReal == true)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            makeReal = false;
        }

        if (restartBall == true)
        {
            timeForRestart++;
            if(timeForRestart >= 10)
            {
                
                rb.position = new Vector3(0, 0.1f, -1.32f);
                restartBall = false;
                timeForRestart = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            enemy.GetComponent<Animator>().enabled = true;
            enemy2.GetComponent<Animator>().enabled = true;
            enemy3.GetComponent<Animator>().enabled = true;
            activeTime = true;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyShooting = true;

        }
        if(enemyShooting) enemyShoot.Shooting(); 

    }
            //Functions
    void playerLogic()
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
            if (detection.collider.gameObject != null) return detection.point;
        }
        return Vector3.zero;
    }

    public void TouchBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (ball.Raycast(ray, out hit, 100.0F))
        {
            transform.position = ray.GetPoint(100.0F);
          //  Debug.Log("Ball Touching");
            timeForDoSwipe++;
            canSwipe = true;
            if (timeForDoSwipe > maxTimeForDoSwipe)
            {
                canSwipe = false;
                timeForDoSwipe = 0;
            }
            else timeForDoSwipe = 0;
        }
        
    }

    private void ThrowingBall(Vector3 EndPoint)
    {
        iPosition = rb.position;
        fPosition = EndPoint;
        yo = initialPosition.y;
        yf = EndPoint.y;
        zo = initialPosition.z;
        zf = EndPoint.z;

        xo = rb.position.x;
        xf = EndPoint.x;

        CalculateWaypoints();
        DoTween();
    }

    public void MakeBallReal()
    {
        if(rb.position == fPosition)
        {
            restartSystem.respawnBall5++;
            ball4.SetActive(false);

            makeReal = true;
            canSwipe = false;
        }
    }

    
    private void DoTween()
    {
        rb.DOPath(waypointsArray, 2.0f, PathType.CatmullRom, PathMode.Full3D, 100, Color.blue);
    }

    private void DoMouseTouch()
    {
        TouchBall();
        if (canSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CalculateInitial();
            }

            if (Input.GetMouseButton(0))
            {
                CalculateWhenSwipes();
            }

            if (Input.GetMouseButtonUp(0))
            {
                Kick(Input.mousePosition);
                canSwipe = false;
            }

            //if (touch.phase == TouchPhase.Ended)
        }
    }

    private void CalculateWhenSwipes()
    {
        timer++;
        swipeTime++;
        if (swipeTime > maxSwipeTime)
        {
            Kick(Input.mousePosition);
            canSwipe = false;
        }
    }

    private void CalculateInitial()
    {
        firstFingerPosition = Input.mousePosition;
        lastFingerPosition = Input.mousePosition;
        AddPointsToList = true;
        positionX = 0;
        positionY = 0;

    }

   

    public void CalculateWaypoints()
    {
        posX = (PosMaxX.x + PosMaxY.x)/ 2 * 1.3f;
        posY = ((PosMaxX.y + PosMaxY.y)/2) * 0.5f;

        saveTime = ((saveTime2 - saveTime) /2) + saveTime;
        posZ = (saveTime / timer) * (zf - zo) + zo;

        //midPosition = new Vector3((posX) * factorX, posY, posZ);

        //posX = ((saveTime2 - saveTime) / (timer - saveTime)) * (xf - midPosition.x) + midPosition.x;

        //posX = (saveTime2 / timer) * (xf - xo) + xo;

       //posY = positionY * 0.5f;
        posZ = (saveTime / timer) * (zf - zo) + zo;
        
        midPosition = new Vector3(posX* factorX, (factorX) * posY, posZ);
        
        waypointsArray = new Vector3[3];
        waypointsArray[0] = iPosition;
        waypointsArray[1] = midPosition;
        waypointsArray[2] = fPosition;
    }

    private void Kick(Vector3 lastPosition)
    {
        anim.monkey.GetComponent<Animator>().SetTrigger("isChuting");

        ball4Thrown = true;
        appearBall2Bool = true;
        swipeTime = 0;
        lastFingerPosition = lastPosition;

       // ballThrowRight = (positionX > Screen.width / 2) ? true : false;

        AddPointsToList = false;

        var worldEndPoint = RayCamera();
        ThrowingBall(worldEndPoint);
    }

    void CheckXPoint()
    {
        var difToCenter = Input.mousePosition.x - Screen.width / 2;
        if (Mathf.Abs(difToCenter) > Mathf.Abs(PosMaxX.x))
        {
            PosMaxX.x = difToCenter;
            PosMaxX.y = Input.mousePosition.y;
            saveTime = timer;
        }
       
        if (Mathf.Abs(Input.mousePosition.y) > Mathf.Abs(PosMaxY.y))
        {
           
            PosMaxY.y = Input.mousePosition.y;
            PosMaxY.x = difToCenter;
            saveTime2 = timer;
           
        }
    }

    public void Retry()
    {
        particles.SetActive(false);
        rb.isKinematic = true;
        rb.useGravity = false;
        retryActive = true;
        saveTime = 0;
        saveTime2 = 0;
        timer = 0;
        retryActive = false;
        rb.transform.position = initialPosition;
        positionX = 0.0f;
        firstFingerPosition = new Vector3(0, 0, 0);
        lastFingerPosition = new Vector3(0, 0, 0);
        PosMaxY.x = 0;
        PosMaxX.y = 0;
        PosMaxY.y = 0;
        PosMaxX.x = 0;
        Debug.Log("You are pressing R key!");
    }

    IEnumerator DelayAdd()
    {
        yield return new WaitForSeconds(0.2f); 
    }

}