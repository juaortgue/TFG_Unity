using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheoMovement : MonoBehaviour
{
    public float runSpeed=8;
    public float jumSpeed=7;
    Rigidbody2D rb2D;
    public bool betterJump;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier=1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d")){
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run", true);
        }
        else if(Input.GetKey("a")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run", true);
        }else{
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("run", false);
        }
        if(Input.GetKey("space") && CheckGround.isGrounded){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumSpeed);
            animator.SetBool("run", false);
        }
        if(CheckGround.isGrounded){
            animator.SetBool("jump", false);
        }else{
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
        }
        if(betterJump){
            if(rb2D.velocity.y<0){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*fallMultiplier*Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space")){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*lowJumpMultiplier*Time.deltaTime;

            }
        }
    }
     void Update()
    {
        
    }
    
}
