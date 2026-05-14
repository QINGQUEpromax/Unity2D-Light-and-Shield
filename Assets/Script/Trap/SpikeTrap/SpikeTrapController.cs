using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    private bool playerInSide = false;
    public GameObject Spike;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
            playerInSide = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
            playerInSide = false;
    }
    private void Update()
    {
        if (playerInSide && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Spike.SetActive(false);
        }
    }
}
