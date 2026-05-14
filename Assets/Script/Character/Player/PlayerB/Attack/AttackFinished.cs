using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFinished : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerAttack>().canAttack = true;
    }
}
