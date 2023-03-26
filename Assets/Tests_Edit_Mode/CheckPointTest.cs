using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckPointTest
{
    private GameObject checkpoint;
    private GameObject player;

    [SetUp]
    public void Setup()
    {
        checkpoint = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/CheckPoint"),new Vector3(20, 20, 0), Quaternion.identity);
        player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Theo"),new Vector3(100, 100, 0), Quaternion.identity);
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;

    }
    [TearDown]
    public void TearDown()
    {
              
        GameObject.Destroy(checkpoint);
        GameObject.Destroy(player);
        PlayerPrefs.DeleteAll();

    }


    [UnityTest]
    public IEnumerator CheckPointIsCreatedProperlyTest()
    {
        
        GameObject checkpointInstantiate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/CheckPoint"), new Vector3(100, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(checkpointInstantiate);    
    }
    [UnityTest]
    public IEnumerator CheckPointIsActivatedTest()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.position = checkpoint.transform.position;
        yield return new WaitForSeconds(0.1f);
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
