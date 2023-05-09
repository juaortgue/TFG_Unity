using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyTest : MonoBehaviour
{
    private GameObject player;
    private PlayerControllerScript script;
    private CrabControllerScript crabScript;
    private CrabControllerScript setosoScript;
    private GameObject setoso;

    private GameObject crab;

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
    public IEnumerator CrabFoundedTest()
    {

        crab = GameObject.Find("Crab");
        Assert.NotNull(crab, "El objeto del cangrejo no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ScriptCrabFoundedTest()
    {

        yield return CrabFoundedTest();
        crabScript = crab.GetComponent<CrabControllerScript>();
        Assert.NotNull(crabScript, "El componente CrabControllerScript no se ha encontrado en el cangrejo.");
        yield return new WaitForSeconds(0.1f);
    }
    public IEnumerator SetosoFoundedTest()
    {

        setoso = GameObject.Find("Setoso");
        Assert.NotNull(setoso, "El objeto del setoso no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ScriptSetosoFoundedTest()
    {

        yield return SetosoFoundedTest();
        setosoScript = setoso.GetComponent<CrabControllerScript>();
        Assert.NotNull(setosoScript, "El componente setosoScript no se ha encontrado en el setoso.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator CheckEnemyMovingTest()
    {

        yield return ScriptCrabFoundedTest();
        crab.transform.position = Vector2.zero;
        var enemyMovement = new Vector2(-1, 0.5f);
        crab.GetComponent<Rigidbody2D>().velocity = enemyMovement;
        yield return new WaitForSeconds(1f);
        yield return crabScript.StartCoroutine(crabScript.CheckEnemyMoving());
        Assert.IsFalse(crabScript.spriteRenderer.flipX);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator MovesCrabThroughWaypoints()
    {
        yield return ScriptCrabFoundedTest();
        var spot = crabScript.moveSpots[0];
        crab.transform.position = spot.transform.position;
        yield return new WaitForSeconds(1f);
        crabScript.Move();
        Assert.IsTrue(crabScript.spriteRenderer.flipX);
        Assert.Less(spot.transform.position.x, crab.transform.position.x);
    }
    [UnityTest]
    public IEnumerator CrabIsEliminatedTest()
    {
        yield return ScriptPlayerFoundedTest();
        yield return ScriptCrabFoundedTest();
        crabScript.speed = 0;
        yield return new WaitForSeconds(1f);
        Vector3 newPosition = crab.transform.position;
        newPosition.y += 2;
        player.transform.position = newPosition;
        yield return new WaitForSeconds(1f);
        Assert.AreEqual(crab.ToString(), "null");
    }
    [UnityTest]
    public IEnumerator SetosoIsEliminatedTest()
    {
        yield return ScriptPlayerFoundedTest();
        yield return ScriptSetosoFoundedTest();
        setosoScript.speed = 0;
        yield return new WaitForSeconds(4f);
        Vector3 newPosition = setoso.transform.position;
        Vector3 oldPosition = player.transform.position;
        newPosition.y += 2;
        player.transform.position = newPosition;
        yield return new WaitForSeconds(0.5f);
        player.transform.position = oldPosition;
        yield return new WaitForSeconds(3f);
        Assert.AreEqual(setoso.ToString(), "null");
    }

}
