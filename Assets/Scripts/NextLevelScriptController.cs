using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScriptController : MonoBehaviour
{
    public int nextScene;
   

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.CompareTag("Player"))
        {   
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("nextScene", nextScene);
            SceneManager.LoadScene("Map");

        }


    }
    
}
