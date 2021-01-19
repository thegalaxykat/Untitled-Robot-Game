using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour{

    public GameObject Button;
    private ButtonCollison button_script;

    private float distTraveled = 0f;
    //where positive is up and negative is down

    //private float distTraveledDown = 0f;
    private float distLimitUp = 1f;
    private float distLimitDown = 0f;

    void Start()
    {
        button_script = Button.GetComponent<ButtonCollison>();
    }

    void Update()
    {
        
    //pillar up
        if(button_script.buttonActivated == true 
        && distTraveled < distLimitUp)
        //&& distTraveledDown < distLimitDown)
        {
            transform.position += new Vector3(0, 2.5f * Time.deltaTime, 0);
            //add the distance moved to distTravled
            distTraveled += Time.deltaTime;
        }

    //pillar down
        if(button_script.buttonActivated == false
        && distTraveled > distLimitDown
        && button_script.buttonBeenPressed == true)
        {
            transform.position += new Vector3(0, -2.5f * Time.deltaTime, 0);
            //subtract the distance moved down from distTravled
            distTraveled += -1 * Time.deltaTime;
        }

        if(distTraveled == distLimitUp)
        {
            
        }
    }
}