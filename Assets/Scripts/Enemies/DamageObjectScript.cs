using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("lol");
        if(other.transform.CompareTag("Player")){
            Debug.Log("player damage");
        }
    }
}
