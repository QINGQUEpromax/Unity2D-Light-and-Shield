using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTrap_Ground : MonoBehaviour
{
    public GameObject GolemSpikeManager;
    public bool isLeft;
    private void OnEnable()
    {
        GetComponent<Animator>().Play("Open");
    }
    public void TrapOpen()
    {
        if (isLeft)
        {
            GolemSpikeManager.GetComponent<GolemTrapManager_Ground>().TrapOpen();
        }
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
