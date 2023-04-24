using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManageLevel : MonoBehaviour
{

    public Button[] buttons;
    private SoundManagerControllerScript soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManagerControllerScript>();
        
        for (int i = 0; i < buttons.Length; i++)
        {
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
        number=number+1;
        PlayerPrefs.DeleteAll();
        soundManager.selectAudio(3,1f);
        SceneManager.LoadScene(number);

    }


}
