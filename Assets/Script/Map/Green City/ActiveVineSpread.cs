using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveVineSpread : MonoBehaviour
{
    public GameObject activedVine;
    public GameObject unActivedVine;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("PlayerB") && Input.GetKeyDown(KeyCode.S)) ||(collision.CompareTag("PlayerA") && Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if(activedVine != null) activedVine.SetActive(true);
            if(unActivedVine != null) unActivedVine.SetActive(false);
        }
    }
}
