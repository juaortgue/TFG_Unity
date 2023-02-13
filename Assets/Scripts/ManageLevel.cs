using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManageLevel : MonoBehaviour
{

    public Button[] buttons;
    private SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log("boton = " + i);
            if (i <= PlayerPrefs.GetInt("nextScene"))
            {
                buttons[i].interactable = true;
            }else{
                buttons[i].interactable = false;
            }
        }
        
    }
    public void ChangeLevel(int number)
    {
        soundManager.selectAudio(1,1f);
        SceneManager.LoadScene(number);

    }


}
