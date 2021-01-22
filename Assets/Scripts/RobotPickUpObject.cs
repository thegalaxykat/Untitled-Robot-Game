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

    float distance;
    float closestDist;
    float pickUpDistance;
    GameObject closestObj;

    void Start()
    {
        closestDist = 10000; //set closest distance to some arbitrary giant number initially 
        PickedUpObj = null;
    }

    void Update()
    {
        PutDown();
    }

    void PutDown()
    {
        //put down
         if (Input.GetKeyUp(KeyCode.W)
         && (PickedUpObj?.GetComponent<PickUpObject>()?.objectPickedUp ?? false))
         {
            //trigger the put down method on the object
            PickedUpObj.GetComponent<PickUpObject>().Place();
         }
    }

    void OnTriggerStay2D(Collider2D collisionPartner) //where collisonPartner is the object the robot collides with
   {
        //if the robot collides with the object and isn't currently holding something
        if (collisionPartner.gameObject.GetComponent<PickUpObject>() != null
        && PickedUpObj == null)
        {
            //store the distance of the object from the player in distance
            distance = Vector3.Distance(collisionPartner.transform.position, gameObject.transform.position);
            ////Debug.Log("Distance between the object and robot is: " + distance);

            if (distance < closestDist) //might have to try a list here if it doesn't work
            {
                //set new closest object
                closestObj = collisionPartner.gameObject;
                closestDist = distance;
                ////Debug.Log("closest object detected is: " + collisionPartner.gameObject);
            }

        //pickup (if W is pressed and the object is the closest to the player)
            if (Input.GetKeyDown(KeyCode.W) 
            && collisionPartner.gameObject == closestObj)
            {
                PickedUpObj = collisionPartner.gameObject;

            //set the collision Partner's objectPickedUp bool to true (which picks up the object)
            collisionPartner.GetComponent<PickUpObject>().objectPickedUp = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collisionPartner) //when leaving the object's collider the closest obj and dist are reset
    {
        closestObj = null;
        closestDist = 10000;
    }
}
