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
    public bool objectPickedUp;
    public bool canTip;

    // offset transform distances from robot
    private Vector3 aboveHead; 
    private Vector3 translateRight;
    private Vector3 translateLeft;
   
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

        //Put down object
        if (Input.GetKeyUp(KeyCode.W) && objectPickedUp == true)
        {     
            Place();
            canTip = true; //if the object is a can, this is where it would tip
        }
    }
    
    public void PickUp()
    {
        transform.position = robot.transform.position + aboveHead; //transform above head
        rb.isKinematic = true; //disable rigidbody
    }
   

    private void Place()
    {
        objectPickedUp = false; //duh
        rb.isKinematic = false; //enable rigidbody

        //set RobotOccupied to false in RobotPickUpObject
        robot.GetComponent<RobotPickUpObject>().RobotOccupied = false;

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