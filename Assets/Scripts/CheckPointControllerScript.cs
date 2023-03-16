using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControllerScript : MonoBehaviour
{
    private SoundManagerControllerScript soundManager;

    // Start is called before the first frame update
     void Start()
    {
        
        soundManager = FindObjectOfType<SoundManagerControllerScript>();
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
