using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPickUpObject : MonoBehaviour
{

/* NOTE TO SELF: 
This script works together with PickUpObject to pick up and put down objects.
This script determines the closest object to the robot and uses that to determine if it can be picked up.
If the player tries to pick something up and is in range, it triggers objectPickedUp true for that object (which causes it to be picked up via the object script) and sets PickedUpObj to null as well.
*/

    public GameObject PickedUpObj; //the game object the robot is holding (if nothing then null)
    public GameObject thingToPickUp;

    float distance;
    float closestDist;
    float pickUpDistance;
    GameObject closestObj;

    void Start()
    {
        closestDist = 10000; //set closest distance to some arbitrary giant number initially 
        PickedUpObj = null;
        thingToPickUp = null;
    }

    void Update()
    {
        UpOrDown();
    }

	void UpOrDown()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (PickedUpObj != null)
			//if holding something put down
			{
                //trigger the put down method on the object
                PickedUpObj.GetComponent<PickUpObject>().Place();
			}
			else //if holding nothing then pick up
            {
                //trigger pickup
                PickedUpObj = thingToPickUp;
                PickedUpObj.GetComponent<PickUpObject>().objectPickedUp = true;
            }
		}
	}

    public void OnTriggerStay2D(Collider2D collisionPartner) //distance calculations
   {
        //if the robot collides with the object and isn't currently holding something
        if (collisionPartner.gameObject.GetComponent<PickUpObject>() != null
        && PickedUpObj == null)
        {
            //store the distance of the object from the player in distance
            distance = Vector3.Distance(collisionPartner.transform.position, gameObject.transform.position);

            if (distance < closestDist)
            {
                closestObj = collisionPartner.gameObject; //set new closest object
                closestDist = distance;
            }

            //if the object collided with is the closest object it becomes the thing to pick up
            if (collisionPartner.gameObject == closestObj) 
            {
                thingToPickUp = collisionPartner.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collisionPartner) //when leaving the object's collider the closest obj and dist are reset
    {
        closestObj = null;
        thingToPickUp = null;
        closestDist = 10000;
    }
}
