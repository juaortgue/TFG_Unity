using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CheckPointTest
{
    private GameObject checkpoint;
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
    public IEnumerator CheckPointFoundedTest()
    {

        checkpoint = GameObject.Find("Checkpoint");
        Assert.NotNull(checkpoint, "El objeto del checkpoint no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }


   
    [UnityTest]
    public IEnumerator CheckPointIsActivatedTest()
    {
        yield return ScriptPlayerFoundedTest();
        yield return CheckPointFoundedTest();
        player.transform.position = checkpoint.transform.position;
        yield return new WaitForSeconds(2f);
        Animator animator = checkpoint.GetComponent<Animator>();
        Assert.True(animator.enabled);        

        

    }
     [UnityTest]
    public IEnumerator PlayerPositionIsSavedTest()
    {
        yield return new WaitForSeconds(0.1f);
        float xOld = PlayerPrefs.GetFloat("checkPointPositionX");
        float yOld = PlayerPrefs.GetFloat("checkPointPositionY");
        yield return  CheckPointIsActivatedTest();
        float xNew = PlayerPrefs.GetFloat("checkPointPositionX");
        float yNew = PlayerPrefs.GetFloat("checkPointPositionY");
        Assert.AreNotEqual(xOld, xNew);
        Assert.AreNotEqual(yOld, yNew);
    }
    
    
}
