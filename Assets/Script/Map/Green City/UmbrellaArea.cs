using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaArea : MonoBehaviour
{
    PlayerAInput playerA;
    public Vector3 offset;

    private void OnEnable()
    {
        playerA=FindAnyObjectByType<PlayerAInput>();
    }
    private void Update()
    {
        transform.position = playerA.transform.position+offset;
    }
}
