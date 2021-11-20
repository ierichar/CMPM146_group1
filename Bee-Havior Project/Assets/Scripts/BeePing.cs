using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePing : MonoBehaviour
{
    // 0: nothing
    // 1: get pollen
    // 2: defend hive
    // 3: make honey
    // 4: make wax
    int ping = 0;

    // radius of the ping
    float range = 50;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")){
            ping = 1;
        }else if (Input.GetKeyDown("2")){
            ping = 2;
        }else if (Input.GetKeyDown("3")){
            ping = 3;
        }else if (Input.GetKeyDown("4")){
            ping = 4;
        }
        foreach (var cur in Bees){
            float dist = Vector3.Distance (cur.position, player.position);
            if (dist < range){
                switch(ping){
                    case 1:
                        cur.state = collect;
                    case 2:
                        cur.state = defend;
                    case 3:
                        cur.state = produce;
                    case 4:
                        cur.state = build;
                }
            }
        }
        ping = 0;
    }
}
