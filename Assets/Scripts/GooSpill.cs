using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooSpill : MonoBehaviour
{
//when the can is tipped the goo is instantiated
//this script is attached to the tipped can

public GameObject goo;
public GameObject createdGoo;
public GameObject pipe;
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
        if (spillRight == true) //direction specific //! base off of can direction instead, character may have changed direction by the time it spills
        {
            //to the right
            createdGoo = Instantiate(goo, new Vector3(transform.position.x, transform.position.y - .36f, transform.position.z), Quaternion.Euler(0, 180, 0));

            createdGoo.GetComponent<GooFlow>().facingLeft = false;
        }
        else
		{
			//to the left
			createdGoo = Instantiate(goo, new Vector3(transform.position.x - .4f, transform.position.y - .36f, transform.position.z), Quaternion.identity);

            createdGoo.GetComponent<GooFlow>().facingLeft = true;
		}
        pipe.GetComponent<CanPipe>().createdGoo = createdGoo;
        createdGoo.GetComponent<GooFlow>().pipe = pipe;
	}
}
