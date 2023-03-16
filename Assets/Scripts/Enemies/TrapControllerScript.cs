using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControllerScript : MonoBehaviour
{
    Renderer myRenderer;
    public SoundManagerControllerScript soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManagerControllerScript>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform != null)
        {
            if (other.transform.CompareTag("Player"))
            {
                soundManager.selectAudio(1,3f);
                Destroy(other.gameObject);
                
                other.gameObject.GetComponent<PlayerRespawn>().PlayerDie();
            }
        }

    }
   
}