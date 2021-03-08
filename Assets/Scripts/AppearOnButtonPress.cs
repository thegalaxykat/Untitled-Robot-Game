using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnButtonPress : MonoBehaviour{

    public GameObject Canvas;
    private bool buttonActivated;


    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ButtonCollison>().buttonActivated == true)
        {
            Canvas.SetActive(true);
            print ("pressed");
        }
        else{
            Canvas.SetActive(false);
        }
    }
}
