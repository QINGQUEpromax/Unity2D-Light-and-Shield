using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapDoor_CanClose : TrapDoor_CannotClose
{
    public void CloseDoor ()//关闭门
    {
        isOpen = false;
        SpriteRenderer.sprite = closedDoorSprite;
        boxCollider2D.enabled = true;
    }
}

