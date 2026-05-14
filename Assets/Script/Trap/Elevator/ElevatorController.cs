using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Elevator elevator;//电梯的代码
    private bool playerInside = false;//玩家是否在电梯内
    public int currentFloor;//电梯控制器当前所在楼层
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerInside = false;
        }
    }
    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.DownArrow)&&currentFloor!=elevator.floor)
        {
            elevator.MoveElevator();
        }
    }
}


