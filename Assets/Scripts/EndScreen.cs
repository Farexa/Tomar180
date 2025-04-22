using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Omar Samu
 * Last Modified: 4/21/2025
 * Description: Handles endscreen when game is over.
*/

public class EndScreen : MonoBehaviour
{
	 public void PlayButtonPressed(int sceneIndex)
	 {
		  SceneManager.LoadScene(sceneIndex);
		PlayerController.wumpaFruit = 0;
	 }

	 public void QuitButtonPressed()
	 {
		  print("Quit Game");
		  Application.Quit();
	 }
}
