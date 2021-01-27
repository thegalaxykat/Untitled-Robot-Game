using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooSpill : MonoBehaviour
{
//when the can is tipped the goo is instantiated
//this script is attached to the tipped can

public GameObject goo;
public bool spillRight;

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
        if (spillRight == true) //direction specific
        {
            //to the right
            Instantiate(goo, new Vector3(transform.position.x + 1.7f, transform.position.y - .36f, transform.position.z), Quaternion.identity);
        }
        else

		{
			//to the left
			Instantiate(goo, new Vector3(transform.position.x - .4f, transform.position.y - .36f, transform.position.z), Quaternion.identity);
		}

		//TODO: if the goo is on a platform it will fall down to the ground below (not float in air) for anything spilled beyond the edge of the platform

	}

	void Reset()
	//if you try to pick up the can it deletes the can as well as the goo it created
	{

	}

}
