using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour
{
    private Rigidbody2D rb;
    BoxCollider2D bc;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        if(IsFacingRight()){
            //Move right
            rb.velocity = new Vector2(speed, 0f);
        }else{
            //Move left
            rb.velocity = new Vector2(-speed, 0f);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Turn
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);

    }
    private bool IsFacingRight(){
        return transform.localScale.x>Mathf.Epsilon;;
    }
    

    
    
}
   




