using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpaFruit : MonoBehaviour
{
    public float rotSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        //Rotate the coin each frame
        transform.Rotate(0, rotSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if touched object was the player
        if (other.GetComponent<PlayerController1>())
        {
            //Add coin to player
            other.GetComponent<PlayerController1>().fruits++;

            //Remove the coin
            Destroy(gameObject);
        }
    }
}
