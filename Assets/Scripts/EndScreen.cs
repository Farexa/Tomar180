using UnityEngine;
using UnityEngine.SceneManagement;

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
