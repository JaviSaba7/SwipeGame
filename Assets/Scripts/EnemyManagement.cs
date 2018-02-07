using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour {

    public GameSystem gameSystem;
    public GameObject enemy1;
    public GameObject particles;

    public GameObject particles2;
    public GameObject particles3;
    public GameObject particles4;
    public GameObject particles5;
    public GameObject particles6;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    public GameObject enemy1_air;
    public GameObject enemy2_air;
    public GameObject enemy1_particles;
    public GameObject enemy2_particles;
    public GameObject enemy3_air;
    public GameObject enemy3_particles;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy7_particles;
    public GameObject enemy8_particles;

    public GameObject enemy9;
    public GameObject enemy9_particles;
    public GameObject enemy10;
    public GameObject enemy10_particles;
    public GameObject enemy11;
    public GameObject enemy11_particles;
    public GameObject enemy12;
    public GameObject enemy12_particles;
    public GameObject enemy13;
    public GameObject enemy13_particles;


    public GameObject enemy4_air;
    public GameObject enemy5_air;
    public GameObject enemy4_particles;
    public GameObject enemy5_particles;
    public GameObject enemy6_air;
    public GameObject enemy6_particles;

    public bool firstEnemy = false;
    public bool secondEnemy = false;
    public bool thirdEnemy = false;

    public bool fourEnemy = false;
    public bool fiveEnemy = false;
    public bool sixEnemy = false;

    public bool seventh = false;

    public bool eighth = false;
    public bool nine = false;
    public bool ten = false;
    public bool eleven = false;
    public bool twelve = false;


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameSystem.timeofGame <= 59)
        {

            firstEnemy = true;

        }

        if (gameSystem.timeofGame <= 55)
        {

            secondEnemy = true;
            thirdEnemy = true;


        }

        if (gameSystem.timeofGame <= 50)
        {

            fourEnemy = true;
            fiveEnemy = true;
            sixEnemy = true;


        }

        if (gameSystem.timeofGame <= 45)
        {
            seventh = true;       
        }
        if (gameSystem.timeofGame <= 40)
        {
            eighth = true;
        }
        if (gameSystem.timeofGame <= 38)
        {
            nine = true;
        }
        if (gameSystem.timeofGame <= 34)
        {
            ten = true;
        }
        if (gameSystem.timeofGame <= 30)
        {
            eleven = true;
        }

        if (gameSystem.timeofGame <= 25)
        {
            twelve = true;
        }

        if (firstEnemy)
        {
            enemy1.SetActive(true);
            particles.SetActive(true);
            enemy1.GetComponent<Animator>().enabled = true;
            firstEnemy = false;
        }

        if (secondEnemy)
        {
            enemy2.SetActive(true);
            particles2.SetActive(true);
            enemy2.GetComponent<Animator>().enabled = true;
            secondEnemy = false;
        }

        if (thirdEnemy)
        {
            enemy3.SetActive(true);
            particles3.SetActive(true);
            enemy3.GetComponent<Animator>().enabled = true;
            thirdEnemy = false;
        }

        if (fourEnemy)
        {
            enemy4.SetActive(true);
            particles4.SetActive(true);
            enemy4.GetComponent<Animator>().enabled = true;
            fourEnemy = false;
        }

        if (fiveEnemy)
        {
            enemy5.SetActive(true);
            particles5.SetActive(true);
            enemy5.GetComponent<Animator>().enabled = true;
            fiveEnemy = false;
        }

       /* if (sixEnemy)
        {
            enemy6.SetActive(true);
            particles6.SetActive(true);
            enemy6.GetComponent<Animator>().enabled = true;
            sixEnemy = false;
        }*/

        //AIR ENEMIES
        if (seventh)
        {
            enemy1_air.SetActive(true);
            enemy1_particles.SetActive(true);
            enemy1_air.GetComponent<Animator>().enabled = true;

            enemy2_air.SetActive(true);
            enemy2_particles.SetActive(true);
            enemy2_air.GetComponent<Animator>().enabled = true;
            seventh = false;
        }

        //5
        if (eighth)
        {
            enemy7.SetActive(true);
            enemy7_particles.SetActive(true);
            enemy7.GetComponent<Animator>().enabled = true;

            enemy8.SetActive(true);
            enemy8_particles.SetActive(true);
            enemy8.GetComponent<Animator>().enabled = true;
            eighth = false;
        }

        //6
        if (nine)
        {
            enemy3_air.SetActive(true);
            enemy3_particles.SetActive(true);
            enemy3.GetComponent<Animator>().enabled = true;
            nine = false;
        }

        //7   1
        if (ten)
        {
            enemy9.SetActive(true);
            enemy9_particles.SetActive(true);
            enemy9.GetComponent<Animator>().enabled = true;
            ten = false;
        }

        //8   2 y 2
        if (eleven)
        {
            enemy10.SetActive(true);
            enemy10_particles.SetActive(true);
            enemy10.GetComponent<Animator>().enabled = true;
            enemy11.SetActive(true);
            enemy11_particles.SetActive(true);
            enemy11.GetComponent<Animator>().enabled = true;
            enemy12.SetActive(true);
            enemy12_particles.SetActive(true);
            enemy12.GetComponent<Animator>().enabled = true;
            enemy13.SetActive(true);
            enemy13_particles.SetActive(true);
            enemy13.GetComponent<Animator>().enabled = true;
            eleven = false;
        }

        //9  3 voladores
        if (twelve)
        {
            enemy4_air.SetActive(true);
            enemy4_particles.SetActive(true);
            enemy4_air.GetComponent<Animator>().enabled = true;

            enemy5_air.SetActive(true);
            enemy5_particles.SetActive(true);
            enemy5_air.GetComponent<Animator>().enabled = true;

            enemy6_air.SetActive(true);
            enemy6_particles.SetActive(true);
            enemy6_air.GetComponent<Animator>().enabled = true;
            twelve = false;
        }




    }



}
