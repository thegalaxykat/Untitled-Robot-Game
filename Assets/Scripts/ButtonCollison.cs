using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollison : MonoBehaviour{

    private Animator animate;

    public bool buttonActivated;

    void Start()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("ButtonPressed", false);
        buttonActivated = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Button Pressed");
        animate.SetBool("ButtonPressed", true);
        buttonActivated = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Button Released");
        animate.SetBool("ButtonPressed", false);
        buttonActivated = false;
    }

}
