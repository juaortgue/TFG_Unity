using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    public float runSpeed = 8;
    public float jumSpeed = 7;
    Rigidbody2D rb2D;
    public bool betterJump;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private int life = 3;
    private float nextCollision;
    private bool invencible = false;
    public float invincibilityTime = 3f;
    private SoundManagerControllerScript soundManager;
    public GameObject[] Hearts;

    void Start()
    {
        life = Hearts.Length;
        nextCollision = 0f;
        rb2D = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManagerControllerScript>();



    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run", true);
        }
        else if (Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("run", false);
        }


    }
    void Jump()
    {
        if (Input.GetKey("space") && CheckGroundControllerScript.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumSpeed);
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;

            }
            soundManager.selectAudio(6, 1);
        }



    }
    void Update()
    {
        if (CheckLife())
        {
            Die();

        }
        nextCollision += Time.deltaTime;

    }

    private bool CheckLife()
    {
        return life <= 0;
    }



    IEnumerator Invulnerability()
    {
        invencible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invencible = false;
    }
    IEnumerator DieInvulnerability()
    {
        yield return new WaitForSeconds(2);
        GetComponent<PlayerRespawn>().PlayerDie();
    }
    void TakeDamage(int amount)
    {

        life -= amount;
        soundManager.selectAudio(1, 3f);
        if (life < 1)
        {
            Destroy(Hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(Hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(Hearts[2].gameObject);
        }

    }
    void Die()
    {
        if(soundManager!=null)
            soundManager.selectAudio(0, 0.3f);
        animator.SetBool("die", true);
        StartCoroutine(DieInvulnerability());


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!invencible)
        {
            if (other.transform.CompareTag("Crab"))
            {

                TakeDamage(1);
                StartCoroutine(Invulnerability());
            }

        }
    }
    public void TakeAllDamage()
    {
        life = 0;
        Destroy(Hearts[0].gameObject);
        Destroy(Hearts[1].gameObject);
        Destroy(Hearts[2].gameObject);
    }
    public int getLife(){
        return life;
    }
}


