using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabControllerScript : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 2f;
    private float waitTime;
    public float startWaitTime = 0.5f;
    public Transform[] moveSpots;
    private int i=0;
    private Vector2 actualPos;

    void Start()
    {
        waitTime=startWaitTime;
    }
    void Update()
    
    {
        
       Move();
    }
    private void Move(){
        //StartCoroutine(CheckEnemyMoving());
        transform.position=Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed*Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[i].transform.position)<1f){
            if(waitTime<=0){
                if(moveSpots[i]!=moveSpots[moveSpots.Length-1]){
                    i++;
                    
                }else{
                    i=0;
                }
                spriteRenderer.flipX=!spriteRenderer.flipX;
                waitTime=startWaitTime;
            }else{
                waitTime-=Time.deltaTime;
            }
        }
    }
    
    IEnumerator CheckEnemyMoving(){
        actualPos=transform.position;
        yield return new WaitForSeconds(0.5f);

        if(Vector2.Distance(transform.position, actualPos)<1){
            spriteRenderer.flipX=true;
        }else if(transform.position.x<actualPos.x+1){
            
            spriteRenderer.flipX=false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Waypoint")){
        CheckEnemyMoving();

        }
    }

   


    

    
    
}
   




