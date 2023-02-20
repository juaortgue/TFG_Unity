using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperScript : MonoBehaviour
{
    Renderer myRenderer;
    public SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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