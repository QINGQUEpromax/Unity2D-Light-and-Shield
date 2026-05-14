using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobliePlatformController : MonoBehaviour
{
    public MobilePlatform platform;
    private bool playerInSide = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerInSide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerInSide = false;
            platform.isMoving = false;
        }
    }
    private void Update()
    {
        if (playerInSide&& Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (platform.isMoving==false)
            { platform.isMoving = true; }
            else
            { platform.isMoving = false; }
        }
    }
}
