using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollison : MonoBehaviour{

    private Animator animate;

    void Start()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("ButtonPressed", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Button Pressed");
        animate.SetBool("ButtonPressed", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Button Released");
        animate.SetBool("ButtonPressed", false);
    }

}
