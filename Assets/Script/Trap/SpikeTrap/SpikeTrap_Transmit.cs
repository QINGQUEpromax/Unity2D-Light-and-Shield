using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap_Transmit : MonoBehaviour
{
    public float damage = 10;
    public Transform safePosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            collision.GetComponent<PlayerController>().PlayerHurt(damage);
            collision.transform.position = safePosition.position;
        }
    }
}
