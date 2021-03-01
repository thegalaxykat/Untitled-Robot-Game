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
    private bool isGrounded;
    public Transform BottomPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJump;
    private bool gooCollison;

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

		if (isGrounded == true
		&& gooCollison == false)
		{
			//extraJump = 1; //double jump
		}

		if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
		{
			rb.velocity = Vector2.up * jump;
			animate.SetTrigger("isJumping");
			extraJump--;
		}
		else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
		{
			rb.velocity = Vector2.up * jump;
			animate.SetTrigger("isJumping");
		}
	}

    private void testgooCollison() //*placeholder for currently unused code
        {
        // void OnCollisionStay2D(Collider2D collisionPartner)
        // {
        //     if(collisionPartner.gameObject.tag == "goo")
        //     {
        //         gooCollison = true;
        //         Debug.Log("hitting goo");
        //     }
        // }
        // void OnCollisionExit2D(Collider2D collisionPartner)
        // {
        //     if(collisionPartner.gameObject.tag == "goo")
        //     {
        //         Debug.Log("not on goo");
        //         gooCollison = false;
        //     }
        }
}
