using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] int mainMenuSceneIndex;
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			LoadLevel(1);
		}
	}
	
	public void LoadLevel(int levelIndex)
	{
		SceneManager.LoadScene(levelIndex);
	}
	
	public void MainMenuScreen()
	{
		SceneManager.LoadScene(mainMenuSceneIndex);
	}
}