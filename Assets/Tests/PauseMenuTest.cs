using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuTest
{
    // A Test behaves as an ordinary method
    private GameObject pauseMenu;
    private Button pauseButton;
    private Button resumeButton;
    private Button exitButton;
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("TestScene");
    }
    [UnityTest]
    public IEnumerator OpenMenuTest()
    {
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        pauseButton.onClick.Invoke();
        Time.timeScale=1f;
        yield return new WaitForSeconds(0.1f);
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        pauseMenu = GameObject.Find("PauseMenu");
        
        Assert.IsFalse(pauseButton.IsActive());
        Assert.IsTrue(resumeButton.IsActive());
        Assert.IsTrue(pauseMenu.activeSelf);

        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ExitButtonMenuTest()
    {        
        yield return OpenMenuTest();
        exitButton.onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        string sceneName = "MainMenu";
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator ResumeButtonMenuTest()
    {        
        yield return OpenMenuTest();
        resumeButton.onClick.Invoke();
        yield return new WaitForSeconds(0.1f);
        string sceneName = "TestScene";
        Scene activeScene = SceneManager.GetActiveScene();
        Assert.AreEqual(sceneName, activeScene.name);
        Assert.IsTrue(pauseButton.IsActive());
        Assert.IsFalse(resumeButton.IsActive());
        Assert.IsFalse(pauseMenu.activeSelf);
        yield return new WaitForSeconds(0.1f);
    }
    
    
}
