using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPipe : MonoBehaviour
{
//note: this script is attatched to the pipe

private ButtonCollison button_script;

public GameObject gooCan; //which type of goo can
public GameObject button; //which button triggers it

public bool dropStart; // if you want a can to drop when the level starts

    void Start()
    {
        button_script = button.GetComponent<ButtonCollison>();

        if (dropStart == true)
        {    
            DropCan(); //drop a can when the level starts
        }
    }

    void Update()
    {
        if(button_script.buttonBeenPressed == true)
        {
            DropCan();
        }
    }

    void DropCan()
    {
        //instantiate a can
        Instantiate(gooCan, new Vector3(transform.position.x, transform.position.y , transform.position.z), Quaternion.identity);
    }

    void DeleteCan()
    {
        //delete the last can the pipe instantiated
    }
}

