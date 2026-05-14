using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourRain : MonoBehaviour
{
    [SerializeField] float damage = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent<PlayerController>(out player) && !player.isHaveUmbrella)
        {
            player.PlayerHurt(damage);
        }
    }
}
