using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void StartScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}
