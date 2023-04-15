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
    public float xLeftLimit;
    public float xRightLimit;
    public float yLimit;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        life = Hearts.Length;
        nextCollision = 0f;
        rb2D = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManagerControllerScript>();
        CheckPointControllerScript checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPointControllerScript>();
        if (!checkpoint.positionSaved)
        {
            PlayerPrefs.DeleteAll();

        }

    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }
    public void MoveRight()
    {
        if (transform.position.x >= xRightLimit)
        {

            transform.position = new Vector3(xRightLimit, transform.position.y, 0);
        }
        rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
        Debug.Log(rb2D.velocity);
        spriteRenderer.flipX = true;
        animator.SetBool("run", true);
    }
    public void MoveLeft()
    {
        if (transform.position.x <= xLeftLimit)
        {

            transform.position = new Vector3(xLeftLimit, transform.position.y, 0);
        }
        rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        spriteRenderer.flipX = false;
        animator.SetBool("run", true);
    }
    public void NotMove()
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        animator.SetBool("run", false);
    }
    void Move()
    {
        if (Input.GetKey("d"))
        {
            MoveRight();
        }
        else if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        else
        {
            NotMove();
        }



    }
    void Jump()
    { if (transform.position.y >= yLimit)
        {

            transform.position = new Vector3(transform.position.x, yLimit, 0);
        }
        if (Input.GetKey("space") && CheckGroundControllerScript.isGrounded)
        {
            GoUp();
            if (soundManager != null)
                soundManager.selectAudio(6, 1);
        }



    }
    public void GoUp()
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
    public void TakeDamage(int amount)
    {

        life -= amount;
        if (soundManager != null)
            soundManager.selectAudio(1, 3f);
        if (life < 0)
        {
            life = 0;
        }
        else if (life > 3)
        {
            life = 3;
        }


        if (life < 1)
        {
            Hearts[0].SetActive(false);
            Hearts[2].SetActive(false);
            Hearts[3].SetActive(false);
        }
        else if (life < 2)
        {
            Hearts[1].SetActive(false);
            Hearts[2].SetActive(false);
        }
        else if (life < 3)
        {
            Hearts[2].SetActive(false);
        }



    }
    void Die()
    {
        if (soundManager != null)
        {
            soundManager.selectAudio(0, 0.3f);
        }
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
        Hearts[0].SetActive(false);
        Hearts[1].SetActive(false);
        Hearts[2].SetActive(false);

    }
    public int getLife()
    {
        return life;
    }
    public void setLife(int life)
    {
        this.life = life;
    }


}


