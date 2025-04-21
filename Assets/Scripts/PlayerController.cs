using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();


        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killHeight)
            LoseLife();

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
            SceneManager.LoadScene(1);
        }
    }

    
     private bool lifeAdded = false; // A flag to track if a life has been added

    public void AddLife()
    {
        if (fruits == 100 && !lifeAdded) // Check if fruits equal 100 and a life hasn't been added
        {
            lives++;       
            lifeAdded = true; 
        }
        else if (fruits != 100) // Reset the flag if fruits no longer equal 100
        {
            lifeAdded = false;
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