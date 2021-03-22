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
	public bool facingLeft;

	public GameObject GreenGooFinishFlowPrefab;
	public GameObject fallenGoo;
	public GameObject pipe;

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
			//every time this line is run the sprite will increase by the stretch factor
			GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);
			distTraveled += stretchFactor; //add the distance moved to distTraveled

      GooSpreadingTip.transform.Translate(new Vector2(-stretchFactor, 0)); //translate the checking point
		}
	}

	void checkForLedge() //check to see if the tip of the expanding goo is still on the ground
	{
		isGrounded = Physics2D.OverlapCircle(GooSpreadingTip.position, checkRadius, whatIsGround); //isGrounded = true if the spreading tip touching ground

    if (isGrounded == false
    && distTraveled < LimitFlowDist) //if it's not on the ground and the distance hasn't reached the limit it must have hit a ledge
    {
      FinishFlowing();
    }
	}

  void FinishFlowing() //instantiate new object and expand for remaining distance
  {
    if (fallenGoo == null) //hopefully prevents new instances of goo being created every frame
    {
      if(facingLeft == true) //make sure new object inherits direction
      {//LEFT
        fallenGoo = Instantiate(GreenGooFinishFlowPrefab, new Vector3(GooSpreadingTip.transform.position.x,GooSpreadingTip.transform.position.y, 0), Quaternion.identity);

        fallenGoo.GetComponent<FinishFlow>().facingLeft = true;
      }
      else
      {//RIGHT
        fallenGoo = Instantiate(GreenGooFinishFlowPrefab, new Vector3(GooSpreadingTip.transform.position.x,GooSpreadingTip.transform.position.y, 0), Quaternion.Euler(0, 180, 0));

        fallenGoo.GetComponent<FinishFlow>().facingLeft = false;
      }

      pipe.GetComponent<CanPipe>().FallenGoo = fallenGoo; //so pipe can keep track of what it needs to delete
    }

    //New distance is (LimitFlowDist - distTraveled) of original goo
    fallenGoo.GetComponent<FinishFlow>().remainingFlowDist = (LimitFlowDist - distTraveled);
    fallenGoo.GetComponent<FinishFlow>().pipe = pipe;
  }
}