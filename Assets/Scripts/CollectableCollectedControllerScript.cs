using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollectedControllerScript : MonoBehaviour
{
    private SoundManagerControllerScript soundManager;
    private LeaderboardScript leaderboardScript;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManagerControllerScript>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<Collider2D>().enabled = false; // Desactivar el colisionador de la moneda
            Destroy(gameObject, 0.5f);
            soundManager.selectAudio(2, 0.3f);

        }


    }
}
