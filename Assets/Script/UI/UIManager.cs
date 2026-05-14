using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject DiePanel;
    public GameObject SettingPanel;
    private bool isPausing=false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_ContinueGame();
        }
    }
    public void Pause_ContinueGame()
    {
        if (!isPausing)
            PauseGame();
        else
            ContinueGame();
    }
    public void PauseGame()
    { 
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPausing=true;
    }
    public void Setting_Enter()
    { 
        SettingPanel.SetActive(true);
    }
    public void Setting_Exit()
    {
        SettingPanel.SetActive(false);
    }
    public void ContinueGame()
    {
        PausePanel.SetActive(false);        
        Time.timeScale = 1;
        isPausing=false;
    }
    public void ExitGame()
    { 
    
    
    }
    public void Die()
    { 
        DiePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resurrection()
    { 
        DiePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
