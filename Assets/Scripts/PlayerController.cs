using UnityEngine;

/*
 * Author: Omar Samu
 * Last Modified: 4/21/2025
 * Description: Handles input and player actions in the scene.
*/

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public int speed = 7;
	public float jumpForce = 1;
	public int lives = 3;
	public int fruits = 0;
	public float killHeight = -5;
	public int wumpaFruit = 0;

	bool earnedExtraLife = false;

	public Vector3 respawnPoint;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		respawnPoint = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < killHeight)
		{
			LoseLife();
		}

		Move();
		Jump();

		AddLife();
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			//Move right
			rb.MovePosition(transform.position += (Vector3.right * speed * Time.deltaTime));
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
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
			LevelManager.LoadLevel(1);
		}
	}


	public void AddLife()
	{
		lives++;
	}

	public void AddFruit(int amount)
	{
		wumpaFruit += amount;
		
		if (wumpaFruit > 100 && !earnedExtraLife)
		{
			AddLife();
			earnedExtraLife = true;
		}
	}

	private bool OnGround()
	{
		bool onGround = false;

		RaycastHit hit;

		//Draws a ray downward 1.2 units from the player's center
		if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 1f + 0.2f))
		{
			onGround = true;
		}

		return onGround;
	}

	public void Bounce()
	{
		rb.velocity = new Vector3(rb.velocity.x, jumpForce * 0.666f, rb.velocity.z);
	}
}