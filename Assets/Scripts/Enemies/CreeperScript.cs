using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperScript : MonoBehaviour
{
    Renderer myRenderer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform != null)
        {
            if (other.transform.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }

    }
   
}