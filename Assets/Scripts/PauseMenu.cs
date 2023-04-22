using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;

    [SerializeField] private GameObject menu;

    public void Pause(){
        Time.timeScale=0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        menu.SetActive(true);
    }
    public void Resume(){
        Time.timeScale=1f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        menu.SetActive(false);
    }
    public void Exit(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale=1f;
        PlayerPrefs.DeleteAll();
    }

}
