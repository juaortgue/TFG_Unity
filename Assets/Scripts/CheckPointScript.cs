using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private SoundManager soundManager;

    // Start is called before the first frame update
     void Start()
    {
        
        soundManager = FindObjectOfType<SoundManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player")){
            GetComponent<Animator>().enabled=true;
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            soundManager.selectAudio(4,2f);
        }
    }
}
