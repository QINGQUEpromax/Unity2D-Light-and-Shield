using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUnlockController : MonoBehaviour
{
    private bool playerInSide=false;
    public Elevator elevator;//电梯的代码
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerA"))
            playerInSide = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        playerInSide = false;
    }
    private void Update()
    {
        if (playerInSide && Input.GetKeyDown(KeyCode.DownArrow)&&!elevator.isUnlocked)
        {
            elevator.isUnlocked = true;//解锁电梯
        }
    }
}

