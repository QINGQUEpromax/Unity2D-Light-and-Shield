using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform playerA;
    public Transform playerB;
    public Transform[] destinations; // ����Ŀ��λ������

    public void TransfToD(int index)
    {
        if (index >= 0 && index < destinations.Length)
        {
            if (GetComponent<GouHuo>().isActive)
            {
                playerA.position = destinations[index].position;
                playerB.position = destinations[index].position;
                GetComponent<GouHuo>().portalPanel.SetActive(false);
                GetComponent<GouHuo>().isPanel = false;
            }
        }
    }
}
