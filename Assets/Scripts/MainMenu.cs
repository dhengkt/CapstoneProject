using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Functions for Start Menu of the game; they all linked with buttons
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartGame()
    {
		SceneManager.LoadScene("PolishedGame");
    }
	public void QuickGame()
    {
		Application.Quit();
	}
}
