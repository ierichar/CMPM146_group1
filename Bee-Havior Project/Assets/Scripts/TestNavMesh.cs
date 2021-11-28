using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] flower;
    public float aggroRadius;
    private Vector3 startPos;
    private int flowerToPick;

    private bool foundFlower = false;
    private Vector3 flowerPos;


    //-------------------------

    //-------------------------
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        flower = GameObject.FindGameObjectsWithTag("Flower");
        startPos = transform.position;
        flowerToPick = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!foundFlower){
        //explore code
            agent.SetDestination(transform.position+transform.forward);
            float rotateChance = Random.Range(0.0f, 10.0f);
            float rotateAmount = Random.Range(-5.0f, 20.0f);
            if(rotateChance < 0.1f){
                Debug.Log("Rotated");
                transform.RotateAround(transform.position, Vector3.up, rotateAmount);
            }
        }else{
            agent.SetDestination(flowerPos);
            if(agent.position == agent.destination){
                //Pick up testing of suckNectar here
                //Need to get script of flower that was found
            }else{
                Debug.Log("Failed");
            }
        }


        //Test to see if navMesh is working
        /*
        Vector3 target = flower[flowerToPick].transform.position - transform.position;
        float dist = target.magnitude;
        if(dist <= aggroRadius){
            agent.SetDestination(flower[flowerToPick].transform.position);
        }else{
            agent.SetDestination(startPos);
        }
        */
    }

    public void foundFlowerFunc(Vector3 pos){
        foundFlower = true;
        flowerPos = pos;
    }
}
