using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0,0,0);

    public void SetPosition(PlayerController player)
    {
        transform.position = player.gameObject.transform.position + offset;


    }
}
