using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float damage = 10;

    private bool isPlayerIn = false;

    List<PlayerController> player = new List<PlayerController>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            isPlayerIn = true;
            player.Add(collision.GetComponent<PlayerController>());
        }
    }

    private void Update()
    {
        if (isPlayerIn)
        {
            for(int i=0; i < player.Count; i++)
            {
                player[i].PlayerHurt(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            player.Remove(collision.GetComponent<PlayerController>());
        }
        if (player.Count == 0)
        {
            isPlayerIn = false;
        }
    }
}
