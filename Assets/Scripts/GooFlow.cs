using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooFlow : MonoBehaviour
{// this script attatched to the goo itself

	public float stretchFactor; // where 1 is a whole tile
	public float LimitFlowDist; // where 1 = 1 tile
	private float distTraveled = 1f; // includes initial length

	public LayerMask whatIsGround;
	public bool isGrounded;
	public float checkRadius;
	public Transform GooSpreadingTip;

	void Start()
	{
		whatIsGround = GameObject.Find("Robot").GetComponent<CharacterMovement>().whatIsGround; //the same thing the robot defines as ground
	}

	void Update()
	{
		checkForLedge();
		if (isGrounded == true) //as long as the tip is on the ground, keep flowing
		{
			Flow();
		}
	}

	void Flow() //goo spreads out on level ground (if it hits a ledge or a change in height it just stops)
	{
		if (distTraveled < LimitFlowDist) //as long as the distance is under the maximum, keep stretching
		{
			// every time this line is run the sprite will increase by the stretch factor
			GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);
			distTraveled += stretchFactor;// add the distance moved to distTraveled
		}
	}

	void checkForLedge() //check to see if the tip of the expanding goo is still on the ground
	{
		isGrounded = Physics2D.OverlapCircle(GooSpreadingTip.position, checkRadius, whatIsGround); //inGrounded = true if the spreading tip touching ground
	}
}