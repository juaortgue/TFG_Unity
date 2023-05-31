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
        Debug.Log("cargo "+gamedata.actualLevel);
        if(isFileSaved()){
            Debug.Log("existe");
            string content = File.ReadAllText(saveFile);
            gamedata = JsonUtility.FromJson<GameData>(content);
            Debug.Log("mapa="+gamedata);
            SceneManager.LoadScene("Level"+gamedata.actualLevel);
        }else{
            Debug.Log("no existe");
        }
    }
    public void save(){
        Debug.Log("guardo el nivel="+level);
        GameData newGameData = new GameData(){actualLevel=level};
        string json = JsonUtility.ToJson(newGameData);
        
        File.Delete(saveFile);
        File.WriteAllText(saveFile, json);
        Debug.Log("archivo guardado");
        Debug.Log(saveFile);
    }
    public bool isFileSaved(){
        return File.Exists(saveFile);
    }
    

}
