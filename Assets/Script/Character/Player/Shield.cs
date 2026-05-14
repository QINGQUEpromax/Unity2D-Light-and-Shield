using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject player;
    PlayerController playerController;

    private bool isPlayerIn = false;

    private void Update()
    {
        transform.position = player.transform.position;

        if (isPlayerIn)
        {
            playerController.isShield = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            isPlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            isPlayerIn = false;
        }
    }
}
