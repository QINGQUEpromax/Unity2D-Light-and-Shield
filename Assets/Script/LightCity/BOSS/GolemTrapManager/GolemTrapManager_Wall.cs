using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTrapManager_Wall : GolemTrapManager
{
    public GameObject TrapWall_Left;
    public GameObject TrapWall_Right;
    public override void TrapOpen()
    {
        TrapWall_Left.SetActive(true);
        TrapWall_Right.SetActive(true);
    }
}
