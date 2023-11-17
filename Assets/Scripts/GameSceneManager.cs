using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsBttn, returnBttn, playBttn, exitBttn, soundSettingsBttn, titleText, credits;
    
    public void LoadScene(int sceneNum)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        playBttn.SetActive(false);
        settingsBttn.SetActive(false);
        exitBttn.SetActive(false);
        titleText.SetActive(false);

        soundSettingsBttn.SetActive(true);
        returnBttn.SetActive(true);
        credits.SetActive(true);
    }
    public void HideSettings()
    {
        playBttn.SetActive(true);
        settingsBttn.SetActive(true);
        exitBttn.SetActive(true);
        titleText.SetActive(true);

        soundSettingsBttn.SetActive(false);
        returnBttn.SetActive(false);
        credits.SetActive(false);
    }


}
