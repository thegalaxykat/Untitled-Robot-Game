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

public bool dropStart; // if you want a can to drop when the level 
private bool previousCanDeleted;

    void Start()
    {
        button_script = button.GetComponent<ButtonCollison>();

        previousCanDeleted = true;

        if (dropStart == true)
        {   //drop a can when the level starts
            DropCan(); 
        }
    }

    void Update()
    {
        if(button_script.buttonTrigger == true
        && previousCanDeleted == false)
        {
            DeleteCan();
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

        //there is currently a can
        previousCanDeleted = false;
    }

    void DeleteCan()
    {
        Destroy(pipeCan);

        //there is no longer a can
        previousCanDeleted = true;
    }

    //TODO- delete tipped cans & respective goo when button pressed
    void Reset() // delete tipped goo can and respective goo
    {
        
    }
}

