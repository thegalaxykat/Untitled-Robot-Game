using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour{

    public GameObject Button;
    private ButtonCollison button_script;

    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        button_script = Button.GetComponent<ButtonCollison>();

        animate = GetComponent<Animator>();
        animate.SetBool("PillarUp", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(button_script.buttonActivated == true){
            Debug.Log("Button Pressed");

            //make the pillar go up if the button is being pressed
            animate.SetBool("PillarUp", true);
        }

        if(button_script.buttonActivated == false){
            Debug.Log("Button Not Pressed");

            //make the pillar go down if the button is not being pressed
            animate.SetBool("PillarUp", false);
        }
    }
}
