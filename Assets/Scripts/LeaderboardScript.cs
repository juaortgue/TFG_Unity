using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class LeaderboardScript : MonoBehaviour
{
    public int coins;
    public int enemies;
    public Text scoreCoinText, scoreEnemyText;
    public float coinDisableTime = 0.05f; // Tiempo en segundos para desactivar el colisionador de la moneda
    public float enemyDisableTime = 0.1f; // Tiempo en segundos para desactivar el colisionador de la moneda

    private bool canCollectCoin = true; // Variable para verificar si se puede recoger una moneda
    private bool canKillEnemy = true;
    private int setosoHits = 0;

    void Start()
    {
        
        
        scoreCoinText.text = "Coins = "+PlayerPrefs.GetInt("coins");
        scoreEnemyText.text = "Enemies = "+PlayerPrefs.GetInt("enemies");
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            if (canCollectCoin) // Solo si se puede recoger una moneda
            {
                coins++;
                PlayerPrefs.SetInt("coins", coins);

                scoreCoinText.text = "Coins = " + coins;
                canCollectCoin = false; // Desactivar la recolección de monedas temporalmente
                Invoke("EnableCoinCollection", coinDisableTime); // Llamar a la función EnableCoinCollection después de coinDisableTime segundos
            }
        }
        if (collision.transform.name == "JumpDamaged")
        {

            if (canKillEnemy)
            {
                enemies++;
                PlayerPrefs.SetInt("enemies", enemies);
                scoreEnemyText.text = "Enemies = " + enemies;
                canKillEnemy = false;
                Invoke("EnableKillEnemy", enemyDisableTime); // Llamar a la función EnableCoinCollection después de coinDisableTime segundos
            }
        }



    }

    private void EnableCoinCollection()
    {
        canCollectCoin = true; // Activar la recolección de monedas nuevamente
    }
    private void EnableKillEnemy()
    {
        canKillEnemy = true;
    }


}
