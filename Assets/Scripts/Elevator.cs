using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Animator animate;
    public bool levelEnd;

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
        
    }

    void OnTriggerEnter2D(Collider2D other) 
	{
        if(other.gameObject.tag == ("Player")) // on player collision with trigger
        {
            if (levelEnd == true) // if at end of level close the door and end the level
            {
                Close();
                NextLevel();
            }
        }
	}

    void NextLevel()
    {

    }

    void Close()
    {
        animate.SetBool("Close", true);
    }

    void Open()
    {
        animate.SetBool("Open", true);
    }

}
