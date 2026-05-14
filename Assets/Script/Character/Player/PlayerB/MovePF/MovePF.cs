using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePF : MonoBehaviour
{
    private PlayerController pC;
    public float moveSpeed;
    private float speed1;
    private float speed2;
    public Transform[] wayPoints;
    int pointIndex;
    private bool canMove;
    private bool isForward;

    private void Start()
    {
        pointIndex = 0;
        canMove = false;
        isForward = true;
        speed1 = pC.walkSpeed;
        speed2 = pC.runSpeed;
    }

    private void Update()
    { if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[pointIndex].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoints[pointIndex].position) < 0.1f && isForward)
            {
                pointIndex++;
            }
            if(pointIndex >= wayPoints.Length)
            {
                pointIndex = wayPoints.Length - 2;
                isForward = false;
            }
            Return();
        }
    }

    public void Return()
    {
        if(!isForward)
        {
            if(Vector2.Distance(transform.position, wayPoints[pointIndex].position) < 0.1f)
            pointIndex--;
            if(pointIndex <= 0)
            {
                isForward = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            canMove = true;
            pC.walkSpeed = moveSpeed + speed1;
            pC.runSpeed = moveSpeed + speed2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            collision.transform.SetParent(null);
            pC.walkSpeed = speed1;
            pC.runSpeed = speed2;
        }
    }
}
