using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LeaderboardScript : MonoBehaviour
{
    public ArrayList coins;
    public int level;
    
    void Start()
    {
        coins = new ArrayList();
        coins.Insert(0,0);
        coins.Insert(1,0);
        coins.Insert(2,0);
        coins.Insert(3,0);
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.transform.CompareTag("Coin"))
            {
                int value = Convert.ToInt32(coins[level]);
                value+=1;
                coins.Insert(level,value);
            }

        
    }
   
    
}
