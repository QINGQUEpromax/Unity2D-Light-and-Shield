using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop_up : MonoBehaviour
{
    public Transform StartPosition;
    public Transform EndPosition;
    public float moveSpeed;
    private float moveTime;
    private bool isMoving=false;
    private void Start()
    {
    }
    private void OnEnable()
    {
        gameObject.transform.position = StartPosition.position;
        isMoving = true;
    }
    private void Update()
    {
        moveTime += Time.unscaledDeltaTime;
        if (transform.position.y - EndPosition.position.y < 1f)
        {
            isMoving = false;
        }
        if (isMoving)
        {
            Vector3 direction = (EndPosition.position-transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.unscaledDeltaTime);
        }
        if (!isMoving)
        {
            if (transform.position.y - EndPosition.position.y < 1f)
            {
                transform.position = new Vector2(transform.position.x,EndPosition.position.y);
            }
        }
    }
    private void OnDisable()
    {
        gameObject.transform.position = StartPosition.position;
    }
}
