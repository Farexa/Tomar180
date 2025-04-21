using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
   
    //check if colliding object was the player
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the player collided with this hazard 
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().LoseLife();
        }
    }


    //Checks  for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().LoseLife();
        }
    }
}
