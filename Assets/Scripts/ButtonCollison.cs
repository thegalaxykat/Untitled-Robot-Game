using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollison : MonoBehaviour{

    private Animator animate;

    public bool buttonActivated; //true the entire time the button is being pressed
    public bool buttonBeenPressed; //the very first time the button is pressed

    

    void Start()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("ButtonPressed", false);
        buttonActivated = false;
        buttonBeenPressed = false;
    }

        private void OnTriggerStay2D(Collider2D other)
        {
            animate.SetBool("ButtonPressed", true);
            buttonActivated = true;
            buttonBeenPressed = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            animate.SetBool("ButtonPressed", false);
            buttonActivated = false;
        }


}
