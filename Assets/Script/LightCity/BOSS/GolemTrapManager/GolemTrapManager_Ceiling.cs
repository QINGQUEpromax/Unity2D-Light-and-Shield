using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolemTrapManager_Ceiling : GolemTrapManager
{
    public List<GameObject> Arrow=new List<GameObject>();
    public override void TrapOpen()
    {
        for (int i = 0; i < Arrow.Count; i++) 
        { 
            Arrow[i].SetActive(true);
        }
    }
}
