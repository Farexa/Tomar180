using UnityEngine;

public class PlayerController : MonoBehaviour
{
	static int lives = 5;

	void Start()
	{
		print("Lives when scene loaded: " + lives);
		lives--;
		print("Lives when player damaged: " + lives);
	}
}