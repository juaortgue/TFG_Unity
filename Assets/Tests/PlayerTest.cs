using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTest
{
    private GameObject player;
  
    

    [UnityTest]
    public IEnumerator PlayerIsCreatedProperlyTest()
    {
        GameObject playerInstantiate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Theo"), new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        
    }
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("TestScene");
        
    }
    [UnityTest]
    public IEnumerator PlayerJumpTest()
        
    {
        yield return new WaitForSeconds(0.1f);
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
    [UnityTest]
    public IEnumerator PlayerMoveLeftTest()

    {
        yield return new WaitForSeconds(1f);
        // Guardar la posición x inicial del jugador
        player = GameObject.Find("Theo");

        float oldSpeed=player.GetComponent<Rigidbody2D>().velocity.x;

        // Mover el jugador hacia la izquierda
        var script = player.GetComponent<PlayerControllerScript>();
        script.MoveLeft();
        float newSpeed = player.GetComponent<Rigidbody2D>().velocity.x;
        bool runAnimation = player.GetComponent<Animator>().GetBool("run");
        bool flipX = player.GetComponent<SpriteRenderer>().flipX;
        Assert.Greater(oldSpeed, newSpeed);
        Assert.IsTrue(runAnimation);
        Assert.IsFalse(flipX);
    }
    [UnityTest]
    public IEnumerator PlayerMoveRightTest()

    {
        yield return new WaitForSeconds(1f);
        // Guardar la posición x inicial del jugador
        player = GameObject.Find("Theo");

        float oldSpeed = player.GetComponent<Rigidbody2D>().velocity.x;

        // Mover el jugador hacia la izquierda
        var script = player.GetComponent<PlayerControllerScript>();
        script.MoveRight();
        float newSpeed = player.GetComponent<Rigidbody2D>().velocity.x;
        bool runAnimation = player.GetComponent<Animator>().GetBool("run");
        bool flipX = player.GetComponent<SpriteRenderer>().flipX;
        Assert.Less(oldSpeed, newSpeed);
        Assert.IsTrue(runAnimation);
        Assert.IsTrue(flipX);
    }
}
