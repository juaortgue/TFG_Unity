using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamageScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public SpriteRenderer spriteRenderer;
    //public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes =1;
    public GameObject destroyParticle;
    public SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

    }
   /* void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player") ){
            soundManager.selectAudio(5,2f);
            other.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up)*jumpForce;
            LosseLifeAndHit();
            CheckLife();
        }
        
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Player") ){
            soundManager.selectAudio(5,2f);
            other.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up)*jumpForce;
            LosseLifeAndHit();
            CheckLife();
        }
    }
    public void LosseLifeAndHit(){
        lifes--;
            

    }
    public void CheckLife(){
        if(lifes==0){
            destroyParticle.SetActive(true);
            
            Invoke("EnemyDie", 0.2f);
        }
    }
    public void EnemyDie(){
        Destroy(gameObject.transform.parent.gameObject);
    }
}
