using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LifeSystemTest
{
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
    public IEnumerator PlayerTakeAllDamageTest()
    {
        yield return ScriptPlayerFoundedTest();


        script.setLife(3);
        int lifeBefore = script.getLife();
        script.TakeAllDamage();

        yield return new WaitForSeconds(1f);
        int lifeAfter = script.getLife();

        Assert.AreEqual(lifeBefore, 3);
        Assert.AreEqual(lifeAfter, 0);
        Assert.False(script.Hearts[0].activeInHierarchy);
        Assert.False(script.Hearts[1].activeInHierarchy);
        Assert.False(script.Hearts[2].activeInHierarchy);


    }
    [UnityTest]
    public IEnumerator PlayerTakeDamageTest()
    {
        yield return ScriptPlayerFoundedTest();
        
      
        script.setLife(3);

        // Act
        script.TakeDamage(1);

        // Assert
        Assert.AreEqual(2, script.getLife());
        Assert.IsTrue(script.Hearts[0].activeSelf);
        Assert.IsTrue(script.Hearts[1].activeSelf);
        Assert.IsFalse(script.Hearts[2].activeSelf);

        


    }
}
