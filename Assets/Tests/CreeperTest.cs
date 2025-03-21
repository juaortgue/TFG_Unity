using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CreeperTest
{
    private GameObject creeper;
    private GameObject player;
    private PlayerControllerScript script;
    [SetUp]
    public void SetUp()
    {
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
    public IEnumerator CreeperFoundedTest()
    {

        creeper = GameObject.Find("Creeper");
        Assert.NotNull(creeper, "El objeto de la enredadera no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
   


    [UnityTest]
    public IEnumerator PlayerIsEliminatedTest()
    {
        yield return ScriptPlayerFoundedTest();
        yield return CreeperFoundedTest();
        float x = creeper.transform.position.x;
        float y = creeper.transform.position.y;
        player.transform.position = new Vector3(x, y, 0);
        
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(script.getLife(), 0);




    }

}
