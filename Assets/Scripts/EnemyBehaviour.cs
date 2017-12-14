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

    private Transform myTransform;

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

        //watching player when arrives at the correct position
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        if ((Vector3.Distance(transform.position, target.position) < maxRange) && (Vector3.Distance(transform.position, target.position) > minRange) && Time.time > nextFire)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            /*if (Input.GetKey(KeyCode "B"))
            {
                Fire();
            }*/
        }
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(bullet, 2f);
    }

}