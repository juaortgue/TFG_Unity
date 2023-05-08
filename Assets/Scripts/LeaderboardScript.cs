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
    private bool canKillEnemy = true; // Variable para verificar si se puede recoger una moneda

    void Start()
    {
        coins = 0;
        enemies = 0;
        scoreCoinText.text = "Coins = 0";
        scoreEnemyText.text = "Enemies = 0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            if (canCollectCoin) // Solo si se puede recoger una moneda
            {
                coins++;
                scoreCoinText.text = "Coins = " + coins;
                canCollectCoin = false; // Desactivar la recolección de monedas temporalmente
                Invoke("EnableCoinCollection", coinDisableTime); // Llamar a la función EnableCoinCollection después de coinDisableTime segundos
            }
        }
        
        if (collision.transform.name == "JumpDamaged")
        {
            if (canKillEnemy)
            {Debug.Log("colisiono");
                enemies++;
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
    private void EnableKillEnemy(){
        canKillEnemy = true;
    }


}
