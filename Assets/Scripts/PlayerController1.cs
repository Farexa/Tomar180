using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{

    private Rigidbody rigidbody;
    public int speed = 7;
    public float jumpForce = 1;
    public int lives = 3;
    public int fruits = 0; 
    public float killHeight = -5;
    public int wumpaFruit = 0;

    public Vector3 respawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();


        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (transform.position.y < killHeight)
            LoseLife();

        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Move right
            rigidbody.MovePosition(transform.position += (Vector3.right * speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move right
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move right
            transform.position += Vector3.back * speed * Time.deltaTime;
        } 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move right
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround()) 
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void LoseLife()
    {
        //Reduces player's lives by 1
        lives--;

        //Check if lives > 0
        if (lives > 0)
        {
            //Respawn - sets the player's position to the pos of the respawn point
            transform.position = respawnPoint;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    private bool OnGround()
    {
        bool onGround = false;


        RaycastHit hit;

        //Draws a ray downward 1.2 units from the player's center
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }



        return onGround;
    }
}
/*
	static int lives = 5;

	void Start()
	{
<<<<<<< HEAD

=======
		print("Lives when scene loaded: " + lives);
		lives--;
		print("Lives when player damaged: " + lives);
>>>>>>> 9ee77db91c5b540660d9c9d2b6b125b6be0ef81f
*/
