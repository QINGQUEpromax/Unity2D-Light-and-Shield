using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaProtected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent<PlayerController>(out player))
        {
            player.isHaveUmbrella = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player;
        if (collision.TryGetComponent<PlayerController>(out player))
        {
            player.isHaveUmbrella = false;
        }
    }
}
