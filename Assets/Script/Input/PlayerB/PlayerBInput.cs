using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBInput : PlayerInput
{
    public override float AxesX => canInput ? Input.GetAxis("PlayerBHorizontal") : 0;
    public override bool Dash => canInput ? Input.GetKeyDown(KeyCode.LeftShift) : false;
    public override bool Jump => canInput ? Input.GetKeyDown(KeyCode.W) ? true : false : false;
    public override float Climb => canInput ? Input.GetAxisRaw("PlayerBJump") : 0;
    public override bool StopJump => canInput ? Input.GetKeyUp(KeyCode.W) ? true : false : false;
    public override bool Crouch => canInput ? Input.GetAxis("PlayerBCrouch") > 0 ? true : false : false;
}
