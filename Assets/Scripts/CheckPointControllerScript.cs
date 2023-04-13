using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControllerScript : MonoBehaviour
{
    
    private SoundManagerControllerScript soundManager;
    public bool positionSaved;
    // Start is called before the first frame update
     void Start()
    {
        positionSaved=false;
        soundManager = FindObjectOfType<SoundManagerControllerScript>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player")){
            GetComponent<Animator>().enabled=true;
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            positionSaved=true;
            if(soundManager!=null)
                soundManager.selectAudio(4,2f);
                
        }
    }
}
