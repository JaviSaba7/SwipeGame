using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxRange;
    public int minRange;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    //public float speed;
    AudioSource audio;
    bool dispaross = false;
    private float nextFire = 0.0F;
    public float fireRate = 0.5F;
    public GameObject enemy;
    private Transform myTransform;
    public GameObject player;

    public GameObject bala;
    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }


    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);
        Ray shot = new Ray(myTransform.position, target.position);


    }
    public void Shooting()
    {
       // bala.active = true;
        bala.transform.LookAt(target.position);
        bala.transform.position = Vector3.MoveTowards(bala.transform.position, target.position, 0.08f);
        
        
    }
}