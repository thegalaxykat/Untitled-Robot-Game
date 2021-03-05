using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    
    public static CharacterMovement current;

    //driving
    public float speed; //speed of character
    private float move;
    private Rigidbody2D rb;
    public bool facingRight;
    private Animator animate;

    //jumping
    public float jump; //jump height of character
    private float stamina;
    public bool isGrounded;
    public Transform BottomPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJump;
    private bool gooCollison;

	//bouncing
	public float minBounceVelocity; //magnitude of downwards velocity (probably about 15)
	public float robotVelocity;

    public GameObject can;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        facingRight = true;
    }

	void Update()
	{
		Drive();
		Jump();
		////fallboost();

		robotVelocity = rb.velocity.y;
	}

    void Drive()
	{
		//move left and right
		move = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(move * speed, rb.velocity.y);

		//flip the character left or right when changing direction
		Vector3 characterScale = transform.localScale;
		if (Input.GetAxis("Horizontal") < 0)
		{
			characterScale.x = -0.7523607f;
			facingRight = false;

		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			characterScale.x = 0.7523607f;
			facingRight = true;
		}
		transform.localScale = characterScale;

		//set driving animation if the arrow keys are pressed
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
		{
			animate.SetBool("isDriving", true);
		}
		else
		{
			animate.SetBool("isDriving", false);
		}

        //speed boost on Lshift
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed += 2.5f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed -= 2.5f;
		}
	}

	void Jump()
	{
		isGrounded = Physics2D.OverlapCircle(BottomPos.position, checkRadius, whatIsGround);

		// if (isGrounded == true)
		// {
		// 	//extraJump = 1;
		// }

		if (Input.GetKeyDown(KeyCode.W) && extraJump > 0)
		{
			rb.velocity = Vector2.up * jump;
			animate.SetTrigger("isJumping");
			extraJump--;
		}
		else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true)
		{
			rb.velocity = Vector2.up * jump;
			animate.SetTrigger("isJumping");
		}
	}

    void fallboost() //increase gravity and fall faster
    {
		if (isGrounded == true //reset stamina when touching the ground
        && gooCollison == false) //if hitting the ground but not goo
        {
		   stamina = 40; //frames the effect should last
        }

        if (Input.GetKey(KeyCode.S)
        && stamina > 0 )
		{
			stamina -= 1f; //subtract stamina every frame fall boost is triggered
		}
        if (Input.GetKeyDown(KeyCode.S)
        && stamina > 0) 
        {
			rb.gravityScale = 4.5f; //increase gravity if stamina > 0
        }
        if (Input.GetKeyUp(KeyCode.S)
        || stamina == 0) //return to normal gravity
        {
			rb.gravityScale = 2.5f;
        }

        //TODO add animation (eyes change size or eyebrows suddenly appear and furrow or something)
    }

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "goo") //on robot contact with goo
		{
			// if robot velocity > minBounceVelocity (rb.velocity.y)
			if(robotVelocity < -minBounceVelocity)
			{
				rb.velocity = new Vector3 (0,-robotVelocity + .8f,0); //note: the added .8 accounts for lost speed 
			}
			else
			{
				rb.velocity = new Vector3 (0,jump + 2.5f,0);
			}
		}
	}
}