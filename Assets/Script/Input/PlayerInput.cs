using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public bool canInput = false;
    public virtual float AxesX { get; set; }
    public virtual bool Jump { get; set; }
    public virtual float Climb { get; set; }
    public virtual bool StopJump { get; set; }
    public virtual bool Move => AxesX != 0;
    public virtual bool Dash { get; set; } = false;

    public virtual bool Crouch { get; set; }
}
