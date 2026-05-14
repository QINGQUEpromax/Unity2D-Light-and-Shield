using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropPanel : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
