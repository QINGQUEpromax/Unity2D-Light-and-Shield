using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public float detectionRadius = 0.1f;
    public LayerMask groundLayer;

    public Collider2D[] colliders = new Collider2D[1];

    public bool IsGrounded => Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    //private void Update()
    //{
    //    Debug.Log(IsGrounded);
    //    Debug.Log(colliders[0]);
    //}
}
