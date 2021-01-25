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

    void Start()
    {
       pickUpScript = GetComponent<PickUpObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpScript.canTip == true)
        {

            ////Debug.Log("can tipping");

            //TODO delete the first can and instantiate the tipped can in the same place

            Instantiate(tippedCan, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            //TODO instatiate goo

        }

    }
}