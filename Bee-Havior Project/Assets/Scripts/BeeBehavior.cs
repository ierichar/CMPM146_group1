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
    public bool foundFlower;
    public bool isExploring;
    public bool goingHome;
    public bool atTarget;
    public int nectar;
    private int maxNectar;
    // NOTE: here we potentially include "Boid" behavior
    //       and check other bees in our radius to prevent
    //       collision and simulate a swarm

    // Start is called before the first frame update
    void Start()
    {
        // Bee is at hive
        agent = GetComponent<NavMeshAgent>();

        foundFlower = false;
        isExploring = false;
        goingHome = false;
        atTarget = true;

        nectar = 0;

        currentTarget = null;
        hive = GameObject.FindGameObjectWithTag("Hive");
    }

    // Update is called once per frame
    void Update()
    {
        // Go to target
        if (currentTarget != null && !atTarget) {
            agent.SetDestination(currentTarget.transform.position);
        }
        // Slurp nectar from currentFlower (AKA currentTarget)
        if (atTarget && currentTarget.CompareTag("Flower") && nectar < maxNectar) {
            if (currentTarget.GetComponent<FlowerBehavior>().suckNectar()) {
                nectar++;
            } else {
                isExploring = true;
                foundFlower = false;
                atTarget = false;
                goingHome = false;
            }
        }
        // Go home
        if (nectar >= maxNectar) {
            isExploring = false;
            atTarget = false;
            goingHome = true;
            currentTarget = hive;
        }

        // Impliment:
        // drop off nectar at hive

        // Impliment:
        // isExploring pathfinding
    }

    // recieveSignal()
    // Transition event handler
    // Pre:  int - signal code:
    //             0 for "go find flower"
    //             1 for "go home"
    // Post: bool - true if signal was recieved, else false
    bool recieveSignal(int signal) {
        // 0: Exploring
        if (signal == 0) {
            // Maintain state
            foundFlower = false;
            isExploring = true;
            goingHome = false;
            atTarget = false;
            
            return true;
        }
        // 1: Go home
        else if (signal == 1) {
            // Maintain state
            goingHome = true;
            currentTarget = hive;
            atTarget = false;

            return true;
        }
        return false;
    }

    // dropOffNectar()
    // Called by Hive
    // Pre:  none
    // Post: returns nectar in inventory
    public int dropOffNectar() {
        int temp = nectar;
        nectar = 0;
        return temp;
    }

    private void OnCollision(Collision other) {
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
