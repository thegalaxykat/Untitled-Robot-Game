using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooFlow : MonoBehaviour
{// this script attatched to the goo itself

    //private SpriteRenderer gooSize;


    public float stretchFactor; // where 1 is a whole tile
    //public Sprite gooSprite; // which sprite is being modified
    //* note to self: remember to remove the hardcoded variables after testing
    
    // Start is called before the first frame update
    void Start()
    {

        Flow();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);
    }

 void Flow() //goo spreads out on level ground (if it hits a ledge or a change in height it just stops)
    {
        //sprite width increased by .25 each frame 12 times (that should be 3 tiles)
        //!test GetComponent<SpriteRenderer>().size += new Vector2(stretchFactor, 0);



        
        
        
        //transform.localScale += new Vector3(3, 0, 0); changes the transform scale, I want to change the actual width value of the sprite


    }
    
}
