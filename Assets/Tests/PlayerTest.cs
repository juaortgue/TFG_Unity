using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTest
{
    private GameObject player;
  
    [TearDown]
    public void TearDown()
    {

        //GameObject.Destroy(player);
        //PlayerPrefs.DeleteAll();

    }

    [UnityTest]
    public IEnumerator PlayerIsCreatedProperlyTest()
    {
        GameObject playerInstantiate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Theo"), new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        
    }
    [SetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("TestScene");
        
    }
    [UnityTest]
    public IEnumerator PlayerJumpTest()
        
    {
        player = GameObject.Find("Theo");
        yield return new WaitForSeconds(0.1f);
        float yOld = player.GetComponent<Rigidbody2D>().position.y;
        var script = player.GetComponent<PlayerControllerScript>();

        script.GoUp();
        yield return new WaitForSeconds(0.1f);

        float yNew = player.GetComponent<Rigidbody2D>().position.y;
        Assert.Greater(yNew, yOld);
        yield return new WaitForSeconds(0.1f);

    }
}
