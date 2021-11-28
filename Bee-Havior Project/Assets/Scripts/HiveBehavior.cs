using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveBehavior : MonoBehaviour
{
    // Conversion 
    private float Honey;
    private float Nectar;
    public GameObject bee;
    private GameObject[] Bees;
    private Queue<GameObject> BeeQueue;
    public int maxBees;
    public float requiredNectar;
    public int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        //-------------------------------------------------------------
        // Ian's Code
        Honey = 0;
        Nectar = 0;
        enemyHealth = 5;

        Queue<GameObject> BeeQueue = new Queue<GameObject>();
        maxBees = 10;
        requiredNectar = 20;
        for (int i = 0; i < maxBees; i++) {
            createBee();
        }

        //-------------------------------------------------------------

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

    }

    void FixedUpdate(){
        //Does hive produce honey or bees?
        //If bees in hive produce honey?
        //for each bee increase rate of nectar to honey conversion
        if (Nectar >= 0 && BeeQueue.Count() > 0) {
            Nectar -= (BeeQueue.Count());
        }
        // From research: it requires nectar from 2 million flowers for
        //  1 lb of honey. That conversion rate is crazy small
        Honey += (BeeQueue.Count() * 0.012);
    }

    // Update is called once per frame for rendering
    void Update(){

    }

    // deployNBees()
    // This function dequeues n number of bees from the BeeQueue and 
    // accesses their recieveSignal() function with code 0. This 
    // function returns true if the hive has bees to deploy
    // Pre:  int : number of bees 
    // Post: bool : whether or not command executed properly
    //       true if command executed
    //       return false if no bees in hive
    bool deployNBees(int n) {
        if (BeeQueue.Count() == 0) return false;
        for (int i = 0; i < n; i++) {
            bee = BeeQueue.Dequeue();
            bee.GetComponent<BeeBehavior>().recieveSignal(0);
        }
        return true;
    }

    // canDefend()
    // A hive-based function that relies solely on the number of bees
    // currently in the hive to determine if the hive can defend itself
    // or not
    bool canDefend() {
        bool canDefend;
        (enemyHealth < BeeQueue.Count()) ? canDefend = false : canDefend = true;
        return canDefend;
    }

    // createBee()
    // Add new bee to BeeQueue
    void createBee() {
        GameObject clone = Instantiate(bee, transform.position + transform.forward * 2, Quaternion.identity);
        // set state
        RefrencedScript cloneScript = clone.GetComponent<BeeBehavior>();
        cloneScript.neutralState();
    }
}
