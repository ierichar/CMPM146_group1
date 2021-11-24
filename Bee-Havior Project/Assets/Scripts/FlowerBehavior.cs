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

    // Start is called before the first frame update
    void Start()
    {
        // consider frame rate and how fast bee consumes 1
        Nectar = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool suckNectar() {
        if (Nectar <= 0) {
            return false;
        } else {
            Nectar--;
            return true;
        }
    }
    private void OnTriggerEnter(Collider other){

    }
}
