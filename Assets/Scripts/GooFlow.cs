using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooFlow : MonoBehaviour
{// this script attatched to the goo itself

    public float stretchFactor; // where 1 is a whole tile
    public float LimitFlowDist; // where 1 = 1 tile

    private float distTraveled = 1f; //includes initial length

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
       Flow();
        ////GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0); //(test)
    }

 void Flow() //goo spreads out on level ground (if it hits a ledge or a change in height it just stops)
    {
		if (distTraveled < LimitFlowDist)
		{
			//every time this line is run the sprite will increase by the stretch factor
			GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);
			//add the distance moved to distTravled
			distTraveled += stretchFactor;
        }
    }
    
}
