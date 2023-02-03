using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    void Start()
    {
        Debug.Log("Capa del cangrejo:"+ this.gameObject.layer);
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, rb.velocity.y);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        speed = speed*-1;
        this.transform.localScale  = new Vector2(this.transform.localScale.x*-1, this.transform.localScale.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Le pego al jugador");
            var player = other.gameObject.GetComponent<TheoMovement>();
            player.life-=1;
        }
    }


}
