using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooSpill : MonoBehaviour
{
//when the can is tipped the goo is instantiated
//this script is attached to the tipped can

public GameObject goo;

    void Start()
    {
        Spill();
    }

    void Update()
    {
        
    }

    void Spill()
    //yep, this is the spilly bit!
    {
        if (CharacterMovement.current.facingRight == true) //direction specific
        {
            //to the right
            Instantiate(goo, new Vector3(transform.position.x + 1.7f, transform.position.y - .36f, transform.position.z), Quaternion.identity);
        }
        else
		{
			//to the left
			Instantiate(goo, new Vector3(transform.position.x - .4f, transform.position.y - .36f, transform.position.z), Quaternion.identity);
		}        
	}

	void Reset()
	//TODO if you try to pick up the can it deletes the can as well as the goo it created
	{

	}

}
