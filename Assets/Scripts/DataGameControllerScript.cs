using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataGameControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public string saveFile;
    public GameData gamedata = new GameData();

    void Awake()
    {
        saveFile = Application.dataPath+"/gameData.json";

    }

    public void load(){
        if(isFileSaved()){
            string content = File.ReadAllText(saveFile);
            gamedata = JsonUtility.FromJson<GameData>(content);
            SceneManager.LoadScene("Level"+gamedata.actualLevel);
        }
    }
    public void save(){
        GameData newGameData = new GameData(){actualLevel=level};
        string json = JsonUtility.ToJson(newGameData);
        File.Delete(saveFile);
        File.WriteAllText(saveFile, json);
        Debug.Log(saveFile);
    }
    public bool isFileSaved(){
        return File.Exists(saveFile);
    }
    

}
