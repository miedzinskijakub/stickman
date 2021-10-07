using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
    public GameObject colliderw;
    public GameObject wbridge;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player") {
            wbridge.GetComponent<HingeJoint2D>().enabled = false;
      

        }


    }


}
