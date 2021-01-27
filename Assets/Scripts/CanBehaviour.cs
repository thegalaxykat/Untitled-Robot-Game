using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script causes a can to tip over once it's been picked up.
When the can is realeased by the player and hits the ground the first time game object is deleted and a new object for the tipped can is created
*/

public class CanBehaviour : MonoBehaviour
{
    private PickUpObject pickUpScript;
    public Transform tippedCan;
    public bool canCanTip;

    private GameObject robot;

    void Start()
    {
        pickUpScript = GetComponent<PickUpObject>();
        canCanTip = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
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
            Instantiate(tippedCan, new Vector3(transform.position.x + .2f, transform.position.y - .2f, transform.position.z), Quaternion.Euler(0, 0, 270));

            //goo will spill right
            tippedCan.GetComponent<GooSpill>().spillRight = true;
        }
        else
		//instantiate tipped can (LEFT)
        {
            Instantiate(tippedCan, new Vector3(transform.position.x + -.2f, transform.position.y - .2f, transform.position.z), Quaternion.Euler(0, 0, 90));      
           
            //goo will spill left
            tippedCan.GetComponent<GooSpill>().spillRight = false;      
        }

        //delete the first can
        Destroy (gameObject);
	}
}