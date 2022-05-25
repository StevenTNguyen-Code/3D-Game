using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieAI : MonoBehaviour
{
    //This intializes the variable used for the 
    // AI zombie
    public Transform target;
    public float speed = 1f;
    public float nextWaypointDistance = 1.2f;
    public Transform zombieGFX;
    Path path;
    int currentWaypoint = 1;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;


    //This function starts the AI sequence path for the path to player
    //This also checks which difficulty the player has set and will adjust 
    //the zombie speed
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Amateur:
                speed = 300f;
                break;
            case GameValues.Difficulties.Expert:
                speed= 600f;
                break;
        }
  

    }

    //Actively checking the fastest path to the player
    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    //Checks if the zombie has made it to its target
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //Sets the path from the zombie to the player
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;

        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
          currentWaypoint++;  
        }

        if(force.x >= 0.01f)
        {
            zombieGFX.localScale = new Vector3(-1f, 1f, 1f);

        } else if (force.x <= -0.01f)
        {
           zombieGFX.localScale = new Vector3(1f, 1f, 1f); 
        }

       
    }

    
}
