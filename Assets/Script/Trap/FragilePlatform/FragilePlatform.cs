using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    [SerializeField] VoidEventChannel bossVineVoidEventChannel;

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
        if (playerAOnPlatform||playerBOnPlatform)
        {
            timer += Time.deltaTime;
            if (timer >= timeToBreak)
            {
                BreakPlatform();
            }
        }
        else if(isBroken)
        {
            timer += Time.deltaTime;
            if (timer >= timeToReappear)
            {
                ReappearPlatform();
            }
        }
    }
    private void BreakPlatform()
    {
        if (CompareTag("BossFragile"))
        {
            bossVineVoidEventChannel.Broadcast();
        }
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
            {timer = 0;}
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
