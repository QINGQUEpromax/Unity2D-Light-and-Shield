using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0,0,0);
    public bool isPlayingVFX = false;

    private void Update()
    {
        UpdateVFXState();
    }

    public void SetPosition(PlayerController player)
    {
        transform.position = player.gameObject.transform.position + offset;
        isPlayingVFX = true;
    }

    public void SetAnimPlay()
    {
        isPlayingVFX = false;
    }

    public void UpdateVFXState()
    {
        if (!isPlayingVFX)
        {
            gameObject.SetActive(false);
        }
    }
}
