using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject robot;
    public bool objectPickedUp;
    public bool canTip;

    // offset transform distances from robot
    private Vector3 aboveHead; 
    private Vector3 translateRight;
    private Vector3 translateLeft;
   
    Rigidbody2D rb;

    float distance;
    float closestDist;
    float pickUpDistance;
    GameObject closestObj;

    // Start is called before the first frame update
    void Start()
    {
        aboveHead.y = 1.09f;
        translateRight.x = 1.1f;
        translateLeft.x = -1.1f;

        rb = GetComponent<Rigidbody2D>();

        // set closest distance to some arbitrary giant number initially 
        closestDist = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        //if the object has been picked up then put it on the robot's head
        if (objectPickedUp == true){
            transform.position = robot.transform.position + aboveHead;

        }
        //Press key to release and put down object
        if (Input.GetKeyUp(KeyCode.W) && objectPickedUp == true){ 
            objectPickedUp = false;
            rb.isKinematic = false; //enable rigidbody

            PlaceObject();
            //if the object is a can, this is where it would tip
            canTip = true;
        }
    }
    

   void OnTriggerStay2D(Collider2D collisionPartner)
   {
        //if the object collides with the character and the character isn't holding anything
        if (collisionPartner.gameObject.GetComponent<CharacterMovement>() != null && objectPickedUp == false)
        {
            //get the distance of the object from the player
            distance = Vector3.Distance(collisionPartner.transform.position, gameObject.transform.position);
            //Debug.Log("Distance between robot and object is: " + distance);

            if (distance < closestDist)
            {
                //set new closest object
                closestObj = gameObject;
                closestDist = distance;
                //Debug.Log("closest object detected is: " + gameObject);

            }
            // if W is pressed and the object is the closest to the player then pick it up
            if (Input.GetKeyDown(KeyCode.W)
            && gameObject == closestObj)
            {
                Debug.Log("trying to pick up " + gameObject);
                objectPickedUp = true;
                rb.isKinematic = true; //disable rigidbody and colliders
            }

        }
    }

    private void PlaceObject()
    {
        //if robot facing right then drop to the right
        if(robot.GetComponent<CharacterMovement>().facingRight == true){
            transform.position = robot.transform.position + translateRight;
        }
       //if robot facing left then drop to the left
        if(robot.GetComponent<CharacterMovement>().facingRight == false){
            transform.position = robot.transform.position + translateLeft;
        }
    }
}