using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    private Animator animate;
    public bool levelEnd;
    public string nextLevelName;
    public bool goToNextLevel;

    void Awake()
    {
        animate = GetComponent<Animator>();

        if (levelEnd == true)
        {
            animate.SetBool("StartOpen", true); // if at end of level start open
        }
        else
        {
            animate.SetBool("StartOpen", false); // if at beginning of level start closed
        }
    }

    void Start()
    {
        // if at the beginning of the level just open the doors and that's it
        if (levelEnd == false)
        {
            Open();
        }
    }

    void Update()
    {
        if (goToNextLevel == true)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
	{
        if(other.gameObject.tag == ("Player")) // on player collision with trigger
        {
            if (levelEnd == true) // if at end of level close the door and end the level
            {
                Close();
                //wait for animation to finish and go to next level
            }
        }
	}

    void Close()
    {
        //todo stop character movement
        animate.SetBool("Close", true);
    }

    void Open()
    {
        animate.SetBool("Open", true);
    }
}
