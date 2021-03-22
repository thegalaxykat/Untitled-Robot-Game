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
