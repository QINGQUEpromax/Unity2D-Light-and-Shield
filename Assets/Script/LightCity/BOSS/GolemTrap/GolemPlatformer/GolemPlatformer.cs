using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemPlatformer : MonoBehaviour
{
    public GameObject Platform;
    private bool playerAIn=false;
    float timer;
    bool isActive = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAIn=false;
        }
    }
    private void Update()
    {
        if (playerAIn)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Platform.SetActive(true);
                isActive = true;
            }
        }
        else Platform.SetActive(false);
        if (isActive)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3)
        { 
            Platform.SetActive(false);
            timer = 0;
        }
    }
}
