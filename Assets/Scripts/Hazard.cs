using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Omar Samu
 * Last Modified: 4/21/2025
 * Description: Handles damage towards player.
*/
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
