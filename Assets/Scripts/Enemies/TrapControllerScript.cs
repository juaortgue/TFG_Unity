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

                if (soundManager != null)
                {
                    soundManager.selectAudio(1, 3f);

                }
                if (other.gameObject != null)
                {
                    other.gameObject.GetComponent<PlayerControllerScript>().TakeAllDamage();
                    
                }

               
            }
        }

    }

}