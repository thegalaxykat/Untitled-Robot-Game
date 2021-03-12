using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(false);
    }

    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

	public void PauseGame()
	{
		Time.timeScale = 0;
        isPaused = true;
        Canvas.SetActive(true);
        Debug.Log("Paused");
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
        isPaused = false;
        Canvas.SetActive(false);
        Debug.Log("Unpaused");
	}

    public void MainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Title Screen");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Restart Level");
        SceneManager.LoadScene("Level 1");
    }

    public void exitgame()
	{
		Debug.Log("Quit game");
		Application.Quit();
	}

}
