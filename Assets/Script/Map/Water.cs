using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float enterBufferTime = 1f;

    public float exitWaterForce =  0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent<PlayerController>(out player))
        {
            if (!player.activeBreath) player.TakeDamage(100);
            if (gameObject.activeInHierarchy) StartCoroutine(PlayerInWaterCoroutine(player,enterBufferTime,true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent(out player))
        {
            player.ExitWater(exitWaterForce);
            player.isInWater = false;
        }
    }

    IEnumerator PlayerInWaterCoroutine(PlayerController player, float bufferTime, bool state)
    {
        yield return new WaitForSeconds(bufferTime);

        player.isInWater = state;
    }
}
