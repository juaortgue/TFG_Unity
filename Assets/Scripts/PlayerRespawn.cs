using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    void Start()
    {

        float x = PlayerPrefs.GetFloat("checkPointPositionX");
        float y = PlayerPrefs.GetFloat("checkPointPositionY");
        if(x!=0f && y!=0f){
            transform.position = new Vector2(x,y);
        }
    }
    public void ReachedCheckPoint(float x, float y){
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY",y);
    }
    public void PlayerDie(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
