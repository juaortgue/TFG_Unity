using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class DataGameControllerTest
{
    private GameObject dataGameController;
    private DataGameControllerScript script;
    [SetUp]
    public void SetUp()
    {   
        SceneManager.LoadScene("TestScene");
    }
    [UnityTest]
    public IEnumerator DataGameControllerFoundedTest()
    {

        dataGameController = GameObject.Find("DataGameController");

        Assert.NotNull(dataGameController, "El controlador de datos del juego no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator DataGameControllerScriptFoundedTest()
    {
        yield return DataGameControllerFoundedTest();
        script = dataGameController.GetComponent<DataGameControllerScript>();
        Assert.NotNull(script, "El script  de datos del juego no se ha encontrado.");
        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator DataManagementTest()
    {
        yield return DataGameControllerScriptFoundedTest();
        script.save();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(script.isFileSaved());
        int oldLevel = script.gamedata.actualLevel;
        script.load();
        Scene loadedScene = SceneManager.GetActiveScene();
        Assert.AreEqual("TestScene", loadedScene.name);
        

    }

   
}
