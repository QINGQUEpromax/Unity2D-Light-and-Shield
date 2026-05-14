using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GolemTrapManager : MonoBehaviour
{
    public GameObject[] traps;
    public virtual void TrapOpen() { }
    public virtual void TrapUpdate() { }
    public virtual void TrapClose() { }
}
