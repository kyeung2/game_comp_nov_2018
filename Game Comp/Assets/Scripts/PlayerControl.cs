using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Transform groundCheck; // an invisible game object that is placed at the character sprite's feet
    public LayerMask whatIsGround; // in the IDE set this to be every layer that is not in the "player" layer
    public bool facingRight = true;
    bool grounded = false;
    float groundRadius = 0.2f;
    Rigidbody2D rBody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    PlayerStats playerStats;




    void Start() {
     
        rBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerStats>();
    }

    void FixedUpdate () {
    
        bool newGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // have to add this guard in place only when transitioning into grounded we set this. As the jump count messes up due to timing issues
        // with FixedUpdate and Update being called.
        if(newGrounded && !grounded){
            playerStats.jumpCount = 0;
        }
        grounded = newGrounded;

        float move = Input.GetAxis("Horizontal");
        MoveCharacter(move);
        AnimateChacter(move);
    }

    void MoveCharacter(float moveX){
      
        rBody2D.velocity = new Vector2(moveX * playerStats.maxSpeed, rBody2D.velocity.y);
    }

    void AnimateChacter(float move){
    
        animator.SetBool("ground", grounded);
        animator.SetFloat("vspeed", rBody2D.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(move));

        if (NeedsFlip(move)) {
           
            Flip();
        }
    }

    void Update() {

        // detection of imput, use Update
        if (Input.GetButtonDown("Jump") && ((playerStats.jumpCount == 0 || (playerStats.jumpCount== 1 && playerStats.doubleJumpEnabled))) ) {

            playerStats.jumpCount++;
            rBody2D.AddForce(new Vector2(0, playerStats.jumpForce * 100));
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
