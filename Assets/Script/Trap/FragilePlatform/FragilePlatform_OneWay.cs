using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform_OneWay : MonoBehaviour
{
    public float timeToBreak = 5;
    public float timeToReappear = 5;
    private bool playerAOnPlatform = false;
    private bool playerBOnPlatform = false;
    private bool isBroken = false;
    private float timer = 0;
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D platformCollider;
    public Collider2D platformColliderTrigger;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (playerAOnPlatform || playerBOnPlatform)
        {
            timer += Time.deltaTime;
            if (timer >= timeToBreak)
            {
                BreakPlatform();
            }
        }
        else if (isBroken)
        {
            timer += Time.deltaTime;
            if (timer >= timeToReappear)
            {
                ReappearPlatform();
            }
        }
        // 检测玩家是否在平台上方
        if (IsPlayerAbovePlatform())
        {
            if (!isBroken)
                platformCollider.enabled = true; // 启用碰撞检测
        }
        else
        {
            platformCollider.enabled = false; // 禁用碰撞检测
        }
    }

    private bool IsPlayerAbovePlatform()
    {
        // 获取玩家的位置
        GameObject playerA = GameObject.FindGameObjectWithTag("PlayerA"); // 假设你有一个 Player 类

        Vector2 playerPosition = playerA.transform.position;
        Vector2 platformPosition = transform.position;

        // 检测玩家是否在平台上方
        return playerPosition.y > platformPosition.y + platformCollider.size.y / 2;
    }


    private void BreakPlatform()
    {
        isBroken = true;
        timer = 0;
        spriteRenderer.enabled = false;
        platformCollider.enabled = false;
        platformColliderTrigger.enabled = false;
    }
    private void ReappearPlatform()
    {
        isBroken = false;
        timer = 0;
        spriteRenderer.enabled = true;
        platformCollider.enabled = true;
        platformColliderTrigger.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAOnPlatform = true;
            if (!playerBOnPlatform)
            { timer = 0; }
        }
        if (collision.CompareTag("PlayerB"))
        {
            playerBOnPlatform = true;
            if (!playerAOnPlatform)
            { timer = 0; }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAOnPlatform = false;
            if (!playerBOnPlatform)
                timer = 0;
        }
        if (collision.CompareTag("PlayerB"))
        {
            playerBOnPlatform = false;
            if (!playerAOnPlatform)
                timer = 0;
        }
    }
}
