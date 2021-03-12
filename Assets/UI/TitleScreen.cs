using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
//button fucnctions

	public void Level1()
	{
        Debug.Log("Level 1");
		SceneManager.LoadScene("Level 1");
	}

	public void exitgame()
	{
		Debug.Log("exitgame");
		Application.Quit();
	}

    public void credits()
    {
        Debug.Log("credits");
		SceneManager.LoadScene("Credits");
    }

    public void settings()
    {
        Debug.Log("settings");
		SceneManager.LoadScene("Settings");
    }
}
