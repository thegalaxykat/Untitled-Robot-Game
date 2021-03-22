using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPipe : MonoBehaviour
{
//note: this script is attatched to the pipe

private ButtonCollison button_script;

public GameObject gooCan; //which type of goo can
public GameObject button; //which button triggers it

private GameObject pipeCan;
public GameObject tippedCan; //newTippedCan in CanBehaviour script
public GameObject createdGoo; //createdGoo in GooSpill script
public GameObject FallenGoo; //created in GooFlow script
//TODO track this to be deleted ^

public bool switchedToTippedCan;
public GameObject smoke;

public bool dropStart; //if you want a can to drop when the level 
private bool previousCanDeleted;

    void Start()
    {
        button_script = button.GetComponent<ButtonCollison>();

        previousCanDeleted = true;

        if (dropStart == true)
        {//drop a can when the level starts
            DropCan(); 
            previousCanDeleted = false;
        }
    }

    void Update()
    {

    //button logic
        if(button_script.buttonTrigger == true
        && previousCanDeleted == false)
        {
            Reset(); //delete previous can
            DropCan();
        }
        if(button_script.buttonTrigger == true
        && previousCanDeleted == true)
        {
            DropCan();
        }
    }

    void DropCan()
    {   //instantiate a can
        pipeCan = Instantiate(gooCan, new Vector3(transform.position.x, transform.position.y , transform.position.z), Quaternion.identity);

        //sets the pipe that created it to the pipe variable
        pipeCan.GetComponent<CanBehaviour>().pipe = gameObject;

        //there is currently a can
        previousCanDeleted = false;
    }

    void Reset() //if the can hasn't been tipped then delete can, if can has been tipped, delete tipped can and goo
    {
        if(switchedToTippedCan == true)
        {
            DeleteTippedCanAndGoo();
            switchedToTippedCan = false;
        }
        else
        {
            DeleteCan();
        }
    }

    void DeleteCan() //just the regular can
	{
        SmokeEffect(pipeCan);

		Destroy(pipeCan);
		previousCanDeleted = true; //there is no longer a can
    }

    void DeleteTippedCanAndGoo() //destroy created can and created goo
    {
        SmokeEffect(tippedCan);
        Destroy(tippedCan);
        Destroy(createdGoo);
        Destroy(FallenGoo);

        previousCanDeleted = true;
    }

    void SmokeEffect(GameObject delObj)
    {
        Instantiate(smoke, new Vector3(delObj.transform.position.x, delObj.transform.position.y, delObj.transform.position.z), Quaternion.identity);
    }

}

