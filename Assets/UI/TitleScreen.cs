using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
        public void Level1() {  
        SceneManager.LoadScene("Level 1");
    }  

	public void exitgame()
	{
		Debug.Log("exitgame");
		Application.Quit();
	}

}
