using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWay : MonoBehaviour
{
    private BoxCollider2D platformCollider;
    private bool isPlayerAbovePlatform_A;
    private bool isPlayerAbovePlatform_B;
    private GameObject  playerA;
    private Transform playerA_Transform;
    private GameObject playerB;
    private Transform playerB_Transform;
    private BoxCollider2D playerA_Collider;
    private BoxCollider2D playerB_Collider;
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<BoxCollider2D>();
        //triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        //triggerCollider.isTrigger = true;
        playerA = GameObject.FindGameObjectWithTag("PlayerA");
        playerB = GameObject.FindGameObjectWithTag("PlayerB");
        if (playerA != null)
        {
            playerA_Collider = GameObject.FindGameObjectWithTag("PlayerA").GetComponent<BoxCollider2D>();
            playerA_Transform = playerA.transform.Find("Ground Detector");
        }
        if (playerB != null)
        {
            playerB_Transform = playerB.transform.Find("Ground Detector");
            playerB_Collider = GameObject.FindGameObjectWithTag("PlayerB").GetComponent<BoxCollider2D>();
        }
    }
    private void Update()
    {
        if (playerA != null)
        {
            isPlayerAbovePlatform_A = (playerA_Transform.position.y > (transform.position.y + platformCollider.size.y / 2));

            if (isPlayerAbovePlatform_A)
            {
                Physics2D.IgnoreCollision(platformCollider, playerA_Collider, false);
                sr.color = Color.green;
            }
            else
            {
                Physics2D.IgnoreCollision(platformCollider, playerA_Collider, true);
                sr.color = Color.white;
            }
        }
        if (playerB != null)
        {
            isPlayerAbovePlatform_B = (playerB_Transform.position.y > (transform.position.y + platformCollider.size.y / 2));
            if (isPlayerAbovePlatform_B)
            {
                Physics2D.IgnoreCollision(platformCollider, playerB_Collider, false);
            }
            else
            {
                Physics2D.IgnoreCollision(platformCollider, playerB_Collider, true);
            }
        }
    }
    //private bool isPlayerAbovePlatform(string playerTag)
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag(playerTag);
    //    if (player == null)
    //        return false;
    //    Vector2 playerPosition = player.transform.position;
    //    Vector2 platformPosition = transform.position;
    //    return playerPosition.y > (platformPosition.y + platformCollider.size.y / 2);
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (playerLayer==(playerLayer|(1<<collision.gameObject.layer)))
    //    {
    //        if (collision.transform.position.y > transform.position.y + platformCollider.size.y / 2)
    //        {
    //            platformCollider.isTrigger = false;
    //        }
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (playerLayer == (playerLayer | (1 << collision.gameObject.layer)))
    //    {
    //        platformCollider.isTrigger = true;

    //    }
    //}
}
