using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BeeBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject currentTarget;
    GameObject hive;
    GameObject currentFlower;
    private bool foundFlower;
    private bool isExploring;
    private bool goingHome;
    private bool atTarget;
    private int nectar;
    // NOTE: here we potentially include "Boid" behavior
    //       and check other bees in our radius to prevent
    //       collision and simulate a swarm

    // Start is called before the first frame update
    void Start()
    {
        // Bee is at hive
        agent = GetComponent<NavMeshAgent>();
        atTarget = true;
        foundFlower = false;
        isExploring = false;
        goingHome = false;

        nectar = 0;

        currentTarget = null;
        hive = GameObject.FindGameObjectWithTag("Hive");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null && !atTarget) {
            // go to target
            agent.SetDestination(currentTarget.transform.position);
        }
        if (atTarget && !currentTarget==null && nectar < 100) {
            if(currentTarget.CompareTag("Flower")){
                // slurp nectar
                nectar += 1;
            }
        }
        if (nectar >= 100) {
            // go home
            atTarget = false;
            goingHome = true;
            currentTarget = hive;
        }
        // Impliment:
        // drop off nectar at hive
    }

    // recieveSignal()
    // Transition event handler
    // Pre:  int - signal code:
    //             0 for "go find flower"
    //             1 for "go home"
    // Post: bool - true if signal was recieved, else false
    bool recieveSignal(int signal) {
        
        // 0: Find flower
        if (signal == 0) {
            foundFlower = false;
            isExploring = true;
            atTarget = false;
            return true;
        }
        // 1: Go home
        else if (signal == 1) {
            goingHome = true;
            currentTarget = hive;
            atTarget = false;
            return true;
        }
        return false;
    }

    private void explore(){

    }


    private void OnCollisionEnter(Collision other) {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Hive")) {
            goingHome = false;
            atTarget = true;
        }
        if (other.gameObject.CompareTag("Flower")) {

            isExploring = false;
            foundFlower = true;
            atTarget = true;
            currentTarget = other.gameObject;
            currentFlower = other.gameObject;
        }
    }
}
