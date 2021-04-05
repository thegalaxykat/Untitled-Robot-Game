using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script causes a can to tip over once it's been picked up.
When the can is released by the player and hits the ground the first time game object is deleted and a new object for the tipped can is created
*/

public class CanBehaviour : MonoBehaviour
{
    private PickUpObject pickUpScript;
    public GameObject TippedCan;
    public bool canCanTip;

    public GameObject newTippedCan;
    public GameObject robot;
    public GameObject pipe;
    public GameObject smoke;

    public bool independentCan; //check yes if the can is not assosiated with a pipe (placed by player)

    void Start()
    {
        pickUpScript = GetComponent<PickUpObject>();
        canCanTip = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)
        && pickUpScript.objectPickedUp == true)
        {
            //drop the can
            pickUpScript.Place();
  
            //at this point the can can be tipped when it hits the ground
            canCanTip = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collisionPartner)
    {
        //detect if collison with ground by checking layer tag (ground is 8)
        //if it hits the ground and the can can tip, it will (or, at least, it should)
        if (collisionPartner.gameObject.layer == 8
        && canCanTip == true)
        {
            TipCan();
        }      
    }

    //tippy-over bit
	void TipCan()
	{//at this point the can has been released and hit the ground

		//instantiate tipped can (RIGHT)
		if (pickUpScript.tipRight == true)
        {
            newTippedCan = Instantiate(TippedCan, new Vector3(transform.position.x + .2f, transform.position.y - .2f, transform.position.z), Quaternion.Euler(0, 0, 270));

            newTippedCan.GetComponent<GooSpill>().spillRight = true;
        }
        else
		//instantiate tipped can (LEFT)
        {
            newTippedCan = Instantiate(TippedCan, new Vector3(transform.position.x + -.2f, transform.position.y - .2f, transform.position.z), Quaternion.Euler(0, 0, 90));

            newTippedCan.GetComponent<GooSpill>().spillRight = false;
        }

		if (independentCan == false) //if the can was created by a pipe
		{
			//update the pipe with the new variables
			pipe.GetComponent<CanPipe>().tippedCan = newTippedCan;

			//transfer the pipe variable to the tipped can
			newTippedCan.GetComponent<GooSpill>().pipe = pipe;

			pipe.GetComponent<CanPipe>().switchedToTippedCan = true;
		}
        //delete the first can

        Destroy (gameObject);
	}
}