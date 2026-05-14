using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemPlayerDetector : MonoBehaviour
{
    private Collider2D Collider;
    public GameObject bossDoor;
    public bool playerIn = false;
    public Golem golem;
    public Transform PlayerAPosition;
    public Transform PlayerBPosition;
    private bool playerAIn = false;
    private bool playerBIn = false;
    private GameObject playerA;
    private GameObject playerB;
    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerA")
        {
            playerAIn = true;
            playerA = collision.gameObject;
        }
        if (collision.gameObject.tag == "PlayerB")
        {
            playerBIn = true;
            playerB = collision.gameObject;
            //golem.getPlayerPosition(collision.transform);
        }
    }
    private void Update()
    {
        if (playerAIn && playerBIn)
        {
            if (!playerIn)
            {
                playerA.transform.position = PlayerAPosition.position;
                playerB.transform.position = PlayerBPosition.position;
            }
            playerIn = true;
            bossDoor.SetActive(true);
        }
        else
        {
            playerIn = false;
            bossDoor.SetActive(false);
        }
    }
}
