using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformController : MonoBehaviour
{
    [SerializeField] MovePlatform movePlatform;

    List<PlayerController> players = new List<PlayerController>();

    bool isPlayerAInPlatform = false;
    bool isPlayerBInPlatform = false;
    bool isPlayerIn = false;

    private void Update()
    {
        if (isPlayerIn)
        {
            if ((isPlayerAInPlatform && Input.GetKeyDown(KeyCode.DownArrow)) || (isPlayerBInPlatform && Input.GetKeyDown(KeyCode.S)))
            {
                movePlatform.isActive = !movePlatform.isActive;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            isPlayerIn = true;
            isPlayerAInPlatform = true;
            players.Add(collision.GetComponent<PlayerController>());
        }
        else if(collision.CompareTag("PlayerB"))
        {
            isPlayerIn = true;
            isPlayerBInPlatform = true;
            players.Add(collision.GetComponent<PlayerController>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            isPlayerAInPlatform = false;
            players.Remove(collision.GetComponent<PlayerController>());
        }
        else if (collision.CompareTag("PlayerB"))
        {
            isPlayerBInPlatform = false;
            players.Remove(collision.GetComponent<PlayerController>());
        }

        if (players.Count==0)
        {
            isPlayerIn = false;
        }
    }
}
