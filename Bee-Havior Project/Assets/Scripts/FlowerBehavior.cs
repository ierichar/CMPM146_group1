using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehavior : MonoBehaviour
{
    // NOTES: 11/23/2021
    // bool to maintain if flower is depleted
    // change the state of collider based on depleted or not
    // timer for replenish Nectar
    private int Nectar;
    private bool depleted;
    SphereCollider collider;
    int replenishTime;
    int timer = 0;
    BeeBehavior beeScript;

    // Start is called before the first frame update
    void Start()
    {
        // consider frame rate and how fast bee consumes 1 nectar
        Nectar = Random.Range(1, 5);//amount of nectar
        replenishTime = Random.Range(1, 3);//num of minutes till replenish
        collider = GetComponent<SphereCollider>();
        beeScript = GetComponent<BeeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //Flower has no nectar left
        //disable its collider because its inactive
        //start incrementing timer
        if(depleted){
            collider.enabled = false;
            timer += Time.deltaTime;
        }
        //if  timer has reached the replenishTime minutes
        //enable the collider and reset variables such
        //as nectar, timer, depleted
        if(timer >= replenishTime*60){
            collider.enabled = true;
            depleted = false;
            Nectar = Random.Range(1, 5);
            timer = 0;
        }
    }
    public bool suckNectar() {
        if (Nectar <= 0) {
            depleted = true;
            return false;
        } else {
            Nectar--;
            return true;
        }
    }
    private void OnTriggerEnter(Collider other){
        //send signal to bee
        //beeScript.sendSignal(found_a_Flower);
    }
}