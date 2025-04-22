using UnityEngine;

/*
 * Author: Omar Samu
 * Last Modified: 4/21/2025
 * Description: Handles wumpaFruit that will be taken from the player like coins. 
*/
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
        if (other.TryGetComponent(out PlayerController plr))
        {
            //Add coin to player
            plr.AddFruit(1);

            //Remove the coin
            Destroy(gameObject);
        }
    }
}
