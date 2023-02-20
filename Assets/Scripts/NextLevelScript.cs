using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public int nextScene;
  

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("nextScene", nextScene);
            SceneManager.LoadScene(4);

        }


    }
}
