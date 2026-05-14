using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] private VoidEventChannel bossExitGateEventChannel;
    EnemyController boss;

    private void Awake()
    {
        boss = GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (boss.isDie)
        {
            bossExitGateEventChannel.Broadcast();
        }
    }

}
