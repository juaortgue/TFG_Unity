using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

public class CollectableTest
{
    // A Test behaves as an ordinary method
    private GameObject coin;
    private GameObject player;
    private PlayerControllerScript script;
    private CollectableCollectedControllerScript coinScript;
    
    private LeaderboardScript leaderboardScript;
    [SetUp]
    public void SetUp()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("TestScene");
    }
    [UnityTest]
    public IEnumerator PlayerFoundedTest()
    {

        player = GameObject.Find("Theo");
        Assert.NotNull(player, "El objeto del jugador no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ScriptPlayerFoundedTest()
    {
        yield return PlayerFoundedTest();
        script = player.GetComponent<PlayerControllerScript>();
        Assert.NotNull(script, "El componente PlayerControllerScript no se ha encontrado en el jugador.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator CoinFoundedTest()
    {

        coin = GameObject.Find("Coin");
        Assert.NotNull(coin, "El objeto  coin no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator CoinScriptFoundedTest()
    {
        yield return CoinFoundedTest();
        coinScript = coin.GetComponent<CollectableCollectedControllerScript>();
        Assert.NotNull(coin, "El objeto  CollectableCollectedControllerScript no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator LeaderboardScriptFoundedTest()
    {
        yield return PlayerFoundedTest();
        leaderboardScript = player.GetComponent<LeaderboardScript>();
        Assert.NotNull(leaderboardScript, "El componente LeaderboardScript no se ha encontrado en el jugador.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator CoinCollectedTest()
    {
        yield return CoinScriptFoundedTest();
        yield return LeaderboardScriptFoundedTest();
        int oldValue = Convert.ToInt32(leaderboardScript.coins);
        coin.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        int newValue = Convert.ToInt32(leaderboardScript.coins);
        Assert.AreEqual(oldValue+1, newValue);
        yield return new WaitForSeconds(0.1f);
    }
}
