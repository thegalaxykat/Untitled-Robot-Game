using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooFlow : MonoBehaviour
{// this script attatched to the goo itself

    public float stretchFactor; // where 1 is a whole tile
    
    // Start is called before the first frame update
    void Start()
    {

        //*Flow();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0); //(test)
    }

 void Flow() //goo spreads out on level ground (if it hits a ledge or a change in height it just stops)
    {
        //sprite width increased by .25 each frame 12 times (that should be 3 tiles)
        
        //every time this line is run the sprite will increase by the stretch factor
        GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);


        //! note: to change flow direction, flip sprite


    }
    
}
