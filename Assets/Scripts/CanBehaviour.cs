using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBehaviour : MonoBehaviour
{

    public GameObject robot;
    public bool objectPickedUp;

    //offset transform distances from robot
    private Vector3 aboveHead; 
    private Vector3 translateRight;
    private Vector3 translateLeft;

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
        if (objectPickedUp == true){
            transform.position = robot.transform.position + aboveHead;
        }
        //press E to put down
        if (Input.GetKey(KeyCode.E) && objectPickedUp == true){ 
            objectPickedUp = false;
            PlaceObject();
            //transform.position = robot.transform.position + translateRight;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collisionPartner){
        if (collisionPartner.gameObject.GetComponent<CharacterMovement>() != null && objectPickedUp == false ){ //test to see it the object that it collided with has the charactermovement script, if it does, then it must be the character
            objectPickedUp = true;
        }
    }

    private void PlaceObject()
    {
        //robot facing right
        if(robot.GetComponent<CharacterMovement>().facingRight == true){
            transform.position = robot.transform.position + translateRight;
        }
       //robot facing left
        if(robot.GetComponent<CharacterMovement>().facingRight == false){
            transform.position = robot.transform.position + translateLeft;
        }
    }
}