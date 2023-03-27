using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreeperTest
{
    private GameObject creeper;
    private GameObject player;
    [SetUp]
    public void Setup()
    {
        creeper = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Creeper"),new Vector3(20, 20, 0), Quaternion.identity);
        player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Theo"),new Vector3(100, 100, 0), Quaternion.identity);
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;

    }
    [TearDown]
    public void TearDown()
    {
              
        GameObject.Destroy(creeper);
        GameObject.Destroy(player);
        PlayerPrefs.DeleteAll();

    }
    [UnityTest]
    public IEnumerator CreeperIsCreatedProperlyTest()
    {
        GameObject creeperInstantiate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Creeper"), new Vector3(100, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(creeperInstantiate);    
    }
    [UnityTest]
    public IEnumerator PlayerIsEliminatedTest()
    {   
        yield return new WaitForSeconds(0.1f);
        float x = creeper.transform.position.x;
        float y = creeper.transform.position.y;
        player.transform.position = new Vector3(x, y, 0);
        
        yield return new WaitForSeconds(0.1f);
        var script = player.GetComponent<PlayerControllerScript>();
        Assert.AreEqual(script.getLife(), 0);




    }

}
