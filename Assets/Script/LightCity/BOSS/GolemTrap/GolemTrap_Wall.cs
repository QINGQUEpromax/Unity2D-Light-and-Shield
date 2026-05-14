using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolemTrap_Wall : MonoBehaviour
{
    public float moveSpeed; 
    private Rigidbody2D rb; 
    private float moveTime;
    public  Transform target;
    public Transform start;
    private bool isReturning = false;
    private bool stop = false;
    private Vector3 targetPosition;
    private float goingTimer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = target.position;
        //targetPosition = new Vector3(1.85f, 4.92f, 0.21f);
    }
    private void OnEnable()
    {
        targetPosition = target.position;
    }
    private void FixedUpdate()
    {
        goingTimer += Time.deltaTime;
        if (goingTimer >= 5)
        {
            targetPosition = start.position;
            isReturning = true;
            stop=false;
        }
        if (stop && !isReturning)
        {
            return;
        }
        moveTime += Time.deltaTime;
        Vector2 currentPosition = transform.position;
        Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, moveTime * moveSpeed);
        Vector2 direction = (targetPosition - transform.position).normalized;
        rb.MovePosition(newPosition);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            targetPosition = start.position;
            isReturning = true;
        }

        if (Vector3.Distance(transform.position, start.position) < 0.1f && isReturning)
        {
            targetPosition = target.position;
            isReturning = false;
            moveTime = 0;
            goingTimer = 0;
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerB"))
        {
            collision.GetComponent<PlayerController>().PlayerHurt(1);
        }
        if (!isReturning)
        {
            if (collision.CompareTag("GolemTrap"))
            {
                stop = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isReturning)
        {
            if (collision.CompareTag("GolemTrap"))
            {
                stop = false;
            }
        }

    }
}
