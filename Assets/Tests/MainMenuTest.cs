using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuTest
{
    private GameObject mainMenu;
    private Button startButton;
    private Button exitButton;
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("MainMenu");
    }
    [UnityTest]
    public IEnumerator MainMenuLoadedTest()
    {
        string sceneName = "MainMenu";
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ButtonFoundedTest()
    {
        startButton = GameObject.Find("Start").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator StartTest()
    {
        string sceneName = "Level1";
        yield return ButtonFoundedTest();
        startButton.onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
    }

}
