using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject robot;
    public bool objectPickedUp;

    // offset transform distances from robot
    private Vector3 aboveHead; 
    private Vector3 translateRight;
    private Vector3 translateLeft;
   
    private int wPressed; //counts the number of times w has been pressed

    // Start is called before the first frame update
    void Start()
    {
        aboveHead.y = 1.03f;
        translateRight.x = 1;
        translateLeft.x = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //if the object has been picked up (objectPickedUp = true) then put it on the robot's head
        if (objectPickedUp == true){
            transform.position = robot.transform.position + aboveHead;
        }
        //Press key to release object
        if (Input.GetKeyUp(KeyCode.W) && objectPickedUp == true){ 
            objectPickedUp = false;
            PlaceObject();
        }
    }
    
    //if the character hits the trigger and presses the "pick up" key then the bool objectPickedUp is set to true
    private void OnTriggerStay2D(Collider2D collisionPartner){
        if (Input.GetKeyDown(KeyCode.W) && collisionPartner.gameObject.GetComponent<CharacterMovement>() != null && objectPickedUp == false){ 
        
        //test to see it the object that it collided with has the charactermovement script, if it does, then it must be the character
        objectPickedUp = true;
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