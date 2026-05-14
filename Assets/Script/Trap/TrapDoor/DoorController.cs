using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public TrapDoor_CannotClose TrapDoor;//门的代码
    public bool playerInside = false;//玩家是否在门内

    //检测玩家是否进入门内
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
            //如果是可以关闭的门，则离开时自动关闭
            if (TrapDoor is TrapDoor_CanClose trapDoor_CanClose)
            { 
                trapDoor_CanClose.CloseDoor();
            }
        }
    }
    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.DownArrow))
        {
            TrapDoor.OpenDoor();
        }
    }
}


