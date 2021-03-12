using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void PauseGame()
	{
		Time.timeScale = 0;
        isPaused = true;
        Canvas.SetActive(true);
        Debug.Log("Paused");
	}

	void ResumeGame()
	{
		Time.timeScale = 1;
        isPaused = false;
        Canvas.SetActive(false);
        Debug.Log("Unpaused");
	}

    void MainMenu()
    {
        Canvas.SetActive(false);
        
    }
}
