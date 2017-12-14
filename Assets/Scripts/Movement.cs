using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    public bool activeEnemies = true;

    public NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        
       
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (activeEnemies)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}