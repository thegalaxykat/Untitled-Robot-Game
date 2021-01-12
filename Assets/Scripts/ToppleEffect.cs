using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppleEffect : MonoBehaviour{

    public float speed; //speed variable
    public float jump; //jump variable
    public Transform topple;

    private float move;
    private Rigidbody2D rb; //stores reference to Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);  
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        //Debug.Log("roatation is: " + topple.localEulerAngles.z);

        //if it rotates more than the specified degree, set it back to that degree
        //if z is greater than 10 but less than 180, set to 10
        if (topple.eulerAngles.z > 10 && topple.eulerAngles.z < 180) 
        {
            topple.eulerAngles = new Vector3(topple.eulerAngles.x, topple.eulerAngles.y, 10);
        }
        //if z is less than 350 and greater than 180, set to 350
        if (topple.eulerAngles.z < 350 && topple.eulerAngles.z > 180)
        {
            topple.eulerAngles = new Vector3(topple.eulerAngles.x, topple.eulerAngles.y, 350);
        }

    }

}
