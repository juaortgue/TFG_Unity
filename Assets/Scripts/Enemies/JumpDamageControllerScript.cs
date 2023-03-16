using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamageControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public SpriteRenderer spriteRenderer;
    //public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes =1;
    public GameObject destroyParticle;
    public SoundManagerControllerScript soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManagerControllerScript>();

    }
   
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
