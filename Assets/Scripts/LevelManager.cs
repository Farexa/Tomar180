using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] int mainMenuSceneIndex;
	[SerializeField] int gameOverSceneIndex;
	
	public void LoadLevel(int levelIndex)
	{
		SceneManager.LoadScene(levelIndex);
	}
	
	public void MainMenuScreen()
	{
		SceneManager.LoadScene(mainMenuSceneIndex);
	}
	
	public void GameOverScreen()
	{
		SceneManager.LoadScene(gameOverSceneIndex);
	}
}