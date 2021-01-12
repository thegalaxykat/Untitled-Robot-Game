using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    
    public float speed; //speed variable
    public float jump; //jump variable

    private float move;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform BottomPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJump;

    public bool facingRight;
    
    private Animator animate;

    public GameObject can;
    private Vector3 tRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        facingRight = true;
        tRight.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)){
            Instantiate(can, new Vector3(transform.position.x + tRight.x,transform.position.y, transform.position.z), Quaternion.identity);
            
        }
       
       //move left and right
            move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);  

            //flip the character left or right when changing direction
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0) {
                characterScale.x = -0.7523607f;
                facingRight = false;

            }
            if (Input.GetAxis("Horizontal") > 0) {
                characterScale.x = 0.7523607f;
                facingRight = true;
            }
            transform.localScale = characterScale;

            //set driving animation if the arrow keys are pressed
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)){
            animate.SetBool("isDriving", true);
            } else {
            animate.SetBool("isDriving", false);
            }

            if(Input.GetKeyDown(KeyCode.LeftShift)){
                speed += 2.5f;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                speed -= 2.5f;
            }

        //jump
            isGrounded = Physics2D.OverlapCircle(BottomPos.position, checkRadius, whatIsGround);

            if(isGrounded == true){
                extraJump = 1;
            }

            if(Input.GetKeyDown(KeyCode.Space) && extraJump > 0){
                rb.velocity = Vector2.up * jump;
                extraJump--;
            }else if(Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true){
                rb.velocity = Vector2.up * jump;
                animate.SetBool("isJumping", true);
            }
            if(Input.GetKeyUp(KeyCode.Space)){
                animate.SetBool("isJumping", false);
            }
    }
}
