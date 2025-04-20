using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void PlayButtonPressed(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }
}
