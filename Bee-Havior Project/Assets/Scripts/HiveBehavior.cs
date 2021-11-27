using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveBehavior : MonoBehaviour
{
    private float Honey;
    private float Nectar;
    private GameObject[] Bees;

    // Start is called before the first frame update
    void Start()
    {
        Bees = GameObject.FindGameObjectsWithTag("Bee");
        //test for future in case we need to dynamically resize Bees array capacity
        GameObject[] temp = new GameObject[Bees.Length*2];
        
        //copys Bees array starting at index 0 into temp array
        Bees.CopyTo(temp, 0);
        //Assign temp to bees, they should be same length and have same elements
        Bees = temp;
        //temp = null;

        Debug.Log("starting number of bees: " + Bees.Length);
        Debug.Log("starting number of temp: " + temp.Length);
        Debug.Log("temp @0: " + Bees[0]);

        //number of  times FixedUpdate runs per second
        Time.fixedDeltaTime = 50;
    }

    void FixedUpdate(){
        //Does hive produce honey or bees?
        //If bees in hive produce honey?
        //for each bee increase rate of nectar to honey conversion
    }

    // Update is called once per frame for rendering
    void Update()
    {
        
    }
}
