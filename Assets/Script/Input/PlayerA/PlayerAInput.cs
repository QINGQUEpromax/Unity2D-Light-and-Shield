using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAInput : PlayerInput
{
    public override float AxesX => canInput ? Input.GetAxis("PlayerAHorizontal") : 0;
    public override bool Jump => canInput ? Input.GetKeyDown(KeyCode.UpArrow) ? true : false : false;
    public override float Climb => canInput ? Input.GetAxisRaw("PlayerAJump") : 0;
    public override bool StopJump => canInput ? Input.GetKeyUp(KeyCode.UpArrow) ? true : false : false;
    public override bool Crouch => canInput ? Input.GetAxis("PlayerACrouch") > 0 ? true : false : false;
}
