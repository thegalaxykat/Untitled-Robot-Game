using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

/* NOTE TO SELF: 
This script works together with RobotPickUpObject to pick up and put down objects.
The functions that control pickup are here but are triggered by the RobotPickUpObjectScript.
This script handles the details of placement and sets RobotPickUpObject RobotOccupied to false.
*/

    public GameObject robot;
    public bool objectPickedUp; //if this specific obj is being held
    public bool canTip;

    // offset transform distances from robot
    private Vector3 aboveHead; 
    private Vector3 translateRight;
    private Vector3 translateLeft;
   
    public bool tipRight;

    Rigidbody2D rb;

    void Start()
    {
        aboveHead.y = 1.09f;
        translateRight.x = 1.1f;
        translateLeft.x = -1.1f;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //check if picked up
        if (objectPickedUp == true)
        {
            PickUp();
        }
    }
    
    public void PickUp()
    {
        transform.position = robot.transform.position + aboveHead; //transform above head
        rb.isKinematic = true; //disable rigidbody
    }
   

    public void Place()
    {
        objectPickedUp = false; //duh
        rb.isKinematic = false; //enable rigidbody

        //set RobotOccupied to false in RobotPickUpObject
        robot.GetComponent<RobotPickUpObject>().PickedUpObj = null;

        //if robot facing right then drop to the right
        if(robot.GetComponent<CharacterMovement>().facingRight == true){
            transform.position = robot.transform.position + translateRight;
            tipRight = true;
        }
       //if robot facing left then drop to the left
        if(robot.GetComponent<CharacterMovement>().facingRight == false){
            transform.position = robot.transform.position + translateLeft;
            tipRight = false;
        }
    }
}