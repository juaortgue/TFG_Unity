using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckPointTest
{
    GameObject checkpoint;
    [SetUp]
    public void Setup()
    {
        GameObject checkpoint = Resources.Load<GameObject>("Prefabs/CheckPoint");

        GameObject checkpointInstance = Object.Instantiate(checkpoint, Vector3.zero, Quaternion.identity);
    }

    [UnityTest]
    public IEnumerator TestPrefab()
    {



        yield return null;
    }
}
