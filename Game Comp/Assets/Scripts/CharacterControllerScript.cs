using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public Transform groundCheck;// an invisible game object that is placed at the character sprite's feet
    public LayerMask whatIsGround;// in the IDE set this to be every layer that is not in the "player" layer
    
    bool facingRight = true;
    bool grounded = false;
    float groundRadius = 0.2f;
    int jumpCount = 0;
    Rigidbody2D rBody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;


    void Start() {
     
        rBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if(grounded){
            jumpCount = 0;
        }

        float move = Input.GetAxis("Horizontal");

        MoveCharacter(move);
        AnimateChacter(move);
    }

    void MoveCharacter(float moveX){
      
        rBody2D.velocity = new Vector2(moveX * maxSpeed, rBody2D.velocity.y);
    }

    void AnimateChacter(float move){
    
        animator.SetBool("Ground", grounded);
        animator.SetFloat("vSpeed", rBody2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));

        if (NeedsFlip(move)) {
            Flip();
        }
    }

    // TODO don't really understand why the tutorial had some code in FixedUpdate and some in Update... need to investigate
    void Update() {

        // if pressing the jump button and you're grounded OR you haven't doubled jumped...
        if ( jumpCount < 1 && Input.GetButtonDown("Jump")) {

            // do the jump
            rBody2D.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }

        AnimateChacter(rBody2D.velocity.x);
    }

    bool NeedsFlip(float move){

        return (move > 0 && !facingRight)|| (move < 0 && facingRight);
    }

	void Flip(){

        facingRight = !facingRight;
        spriteRenderer.flipX =  !spriteRenderer.flipX;
	}
}
