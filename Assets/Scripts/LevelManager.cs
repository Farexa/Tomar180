using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	const int mainMenuSceneIndex = 0;
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			LoadLevel(1);
		}
	}
	
	public static void LoadLevel(int levelIndex)
	{
		SceneManager.LoadScene(levelIndex);
	}
	
	public static void MainMenuScreen()
	{
		SceneManager.LoadScene(mainMenuSceneIndex);
	}
}