using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourPool : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent<PlayerController>(out player))
        {
            player.TakeDamage(100);
        }
    }
}
