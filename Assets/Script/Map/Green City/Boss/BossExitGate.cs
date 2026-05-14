using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExitGate : MonoBehaviour
{
    [SerializeField] VoidEventChannel bossGateExitEventChannel;
    private void OnEnable()
    {
        bossGateExitEventChannel.Addlistener(EnterGateOpen);
    }
    private void OnDisable()
    {
        bossGateExitEventChannel.Removelistener(EnterGateOpen);
    }
    void EnterGateOpen()
    {
        Destroy(gameObject);
    }
}
