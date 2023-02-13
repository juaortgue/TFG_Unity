using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelScript : MonoBehaviour
{
    public void ChangeLevel(string name){
        SceneManager.LoadScene(name);
    }
    public void ChangeLevel(int number){
        SceneManager.LoadScene(number);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        ChangeLevel(4);
    }
    
}
