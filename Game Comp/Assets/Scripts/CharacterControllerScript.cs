using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    Rigidbody2D rigidbody2D;
    public float jumpForce = 700f;
    bool usedDoubleJump = false;
    Animator animator;

	void Start () {
	
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // trying to find the values for setting the jump animation
    bool debug = true;
    float lowestVertical = 0;
    float highestVertcal = 0;


	void FixedUpdate () {


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if(grounded){
            usedDoubleJump = false;
        }


        animator.SetBool("Ground", grounded);

        // how fast are we moving up or down
        animator.SetFloat("vSpeed", rigidbody2D.velocity.y);

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
       
        if(NeedsFlip(move)){
			Flip();
		}
	}

    private void Update() {


        // just doing this to get some values.
        if (debug){
            float currentV= rigidbody2D.velocity.y;
            if(currentV> highestVertcal){
                highestVertcal = currentV;
            }
            if (currentV < lowestVertical){
                lowestVertical = currentV;
            }

            Debug.Log("highest v=" + highestVertcal +" lowest v=" + lowestVertical);
        }

        if ((grounded || !usedDoubleJump) && Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        
            if(!usedDoubleJump && !grounded){
                usedDoubleJump = true;
            }
        }
    }


    bool NeedsFlip(float move){

        return (move > 0 && !facingRight)|| (move < 0 && facingRight);
    }

	void Flip(){
	
        facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
