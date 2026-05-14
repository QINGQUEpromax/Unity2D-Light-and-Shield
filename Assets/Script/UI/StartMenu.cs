using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
