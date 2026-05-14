using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();

    public float moveSpeed = 1.5f;

    public int pointNum = 0;

    public bool isActive = false;

    Vector3 lastPosition;
    List<Rigidbody2D> rb = new List<Rigidbody2D>();

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[pointNum].transform.position, moveSpeed * Time.deltaTime);

            for (int i=0; i<rb.Count; i++)
            {
                rb[i].transform.Translate(transform.position-lastPosition,transform);
            }
        }

        if (Vector3.Distance(transform.position, points[pointNum].transform.position) < 0.1f)
        {
            pointNum = (pointNum+1>=points.Count) ? 0 : pointNum+1;
            isActive = false;
        }

        lastPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            rb.Add(collision.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            rb.Remove(collision.GetComponent<Rigidbody2D>());
        }
    }
}
