using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTrapManager_Ground : GolemTrapManager
{
    public GameObject GolemSpike;
    public List<GameObject> GolemSpikeList_Left = new List<GameObject>();
    public List<GameObject> GolemSpikeList_Right = new List<GameObject>();
    private int spikeIndex = 0;
    public override void TrapOpen()
    {
        if (spikeIndex<=(GolemSpikeList_Left.Count-1))
        {
            GolemSpikeList_Left[spikeIndex].SetActive(true);
            GolemSpikeList_Right[spikeIndex].SetActive(true);
            spikeIndex++;
        }
        else
        {
            spikeIndex = 0;
        }
    }
}

