using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{

    public GameObject player;
    public GameObject gun;
    public Vector2 PickPosition;

    //Invoked when a button is pressed.
    public void SetParent(GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        player.transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Player's Parent: " + player.transform.parent.name);
        player.transform.localPosition = Vector2.zero;
        player.transform.localEulerAngles = Vector2.zero;
        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + player.transform.parent.parent.name);
        }

    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }

  
    
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SetParent(gun);
        }
            
    }
}
