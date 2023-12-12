using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{  
    public void LoadScene(int sceneNum)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
