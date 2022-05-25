using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask thisground, thisplayer; 

    //Idle
    public Vector3 walkDist;
    bool walkDistSet;
    public float walkDistAmt;

    //Hostile
    public float attackTime;
    bool attacked;
    
    public float sightRange, attackRange;
    public bool playerInRange, playerInAttack;

    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate(){
        playerInRange = Physics.CheckSphere(transform.position, sightRange, thisplayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, thisplayer);

        if (playerInRange){
            Debug.Log("chasing");
            chase();
        }
        if (playerInAttack){
            Debug.Log("attacking");
            attack();
        }
        else{
            chase();
            //idle();
        }


    }
        void OnTriggerEnter(Collider other){
            if (other.gameObject.name == "Player"){
            SceneManager.LoadScene(2);
            }
        }

    private void idle(){
        float randomZ = Random.Range(-walkDistAmt, walkDistAmt);
        float randomX = Random.Range(-walkDistAmt, walkDistAmt);

        walkDist = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkDist, -transform.up, 2f, thisground)){
            agent.SetDestination(walkDist);
        }

    }

    private void chase(){
        agent.SetDestination(player.position);
    }

    private void attack(){
        agent.SetDestination(transform.position);
            transform.LookAt(player);
            SceneManager.LoadScene(2);
    }

    private void OnDrawGizomsSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }

}
