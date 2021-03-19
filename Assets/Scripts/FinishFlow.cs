using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlow : MonoBehaviour
{ //for extra goo flow

	public float stretchFactor; // where 1 = 1 tile
	public float remainingFlowDist; 
	private float distTraveled = 1f; // includes initial length

	public LayerMask whatIsGround;
    public bool hitGround;
	public bool isGrounded;
	public float checkRadius;
	public Transform GooSpreadingTip;

	public GameObject GreenGooFinishFlowPrefab;
	public GameObject fallenGoo;

	void Start()
	{
		whatIsGround = GameObject.Find("Robot").GetComponent<CharacterMovement>().whatIsGround; //the same thing the robot defines as ground

        //TODO MAKE IT FALL
	}

	void Update()
	{
		checkForLedge();
		if (isGrounded == true) //if the goo is on the ground then flow
		{
			Flow();
		}

		if (isGrounded == false) // if it's not on the ground
        {
            if(hitGround == true) // but was on the ground at some point
            {
                if(distTraveled < remainingFlowDist) // and it still has some distance to flow
                {
                    // then it probably hit a ledge
                    Debug.Log("Ledge detected");
                }
            }
        }
    }

    // check for initial collison with ground
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 8) //if it collides with ground
        hitGround = true;
    }

	void Flow() //goo spreads out on level ground (if it hits a ledge or a change in height it just stops)
	{
		if (distTraveled < remainingFlowDist) //as long as the distance is under the maximum, keep stretching
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
	}

	void FallLikeARock() //instantiate new object and expand for remaining distance
	{
		if (fallenGoo == null) //hopefully prevents new instances of goo being created every frame
		{
			fallenGoo = Instantiate(GreenGooFinishFlowPrefab, new Vector3(GooSpreadingTip.transform.position.x, GooSpreadingTip.transform.position.y, GooSpreadingTip.transform.position.z), Quaternion.identity);
		}
		//TODO make sure this new object is deleted when the pipe is reset

		//New distance is (LimitFlowDist - distTraveled) of original goo
		fallenGoo.GetComponent<FinishFlow>().remainingFlowDist = (remainingFlowDist - distTraveled);
	}
}