using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapTest
{
    private GameObject player, endCheckPoint;
    private PlayerControllerScript script;
    private ManageLevel mapScript;
    private NextLevelScriptController endCheckPointScript;
    private Button level2Button;
    private Button level3Button;
    private Button level4Button;

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
    public IEnumerator EndCheckPointFoundedTest()
    {

        endCheckPoint = GameObject.Find("EndCheckPoint");
        Assert.NotNull(endCheckPoint, "El objeto del endCheckPoint no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ScriptEndCheckPointFoundedTest()
    {
        yield return EndCheckPointFoundedTest();
        endCheckPointScript = endCheckPoint.GetComponent<NextLevelScriptController>();
        Assert.NotNull(endCheckPointScript, "El componente NextLevelScriptController no se ha encontrado en el endCheckPoint.");
        yield return new WaitForSeconds(0.1f);
    }
    
    [UnityTest]
    public IEnumerator MapOpenedTest()
    {
        yield return ScriptPlayerFoundedTest();
        yield return ScriptEndCheckPointFoundedTest();
        string sceneName = "Map";
        Vector3 newPosition = endCheckPointScript.transform.position;
        script.transform.position = newPosition;
        yield return new WaitForSeconds(0.1f);
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ButtonFoundedTest()
    {
        yield return MapOpenedTest();
        level2Button = GameObject.Find("ButtonLevel2").GetComponent<Button>();
        level3Button = GameObject.Find("ButtonLevel3").GetComponent<Button>();
        level4Button = GameObject.Find("ButtonLevel4").GetComponent<Button>();

        Assert.NotNull(endCheckPoint, "El objeto del level2Button no se ha encontrado.");
        Assert.NotNull(endCheckPoint, "El objeto del level3Button no se ha encontrado.");
        Assert.NotNull(endCheckPoint, "El objeto del level4Button no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator LoadNextSceneTest()
    {
        yield return ButtonFoundedTest();
        string sceneName = "Level2";
        level2Button.onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator NextLevelNegativeTest()
    {
        yield return ButtonFoundedTest();
        yield return new WaitForSeconds(0.1f);
        bool isActive = level3Button.interactable;
        Assert.IsFalse(isActive);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator NextLevelPositiveTest()
    {
        yield return ButtonFoundedTest();
        yield return new WaitForSeconds(0.1f);
        bool isActive = level2Button.interactable;
        Assert.IsTrue(isActive);
        yield return new WaitForSeconds(0.1f);
    }
}
