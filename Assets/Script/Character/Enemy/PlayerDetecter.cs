using System.Collections;
using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    public Collider2D[] colliders = new Collider2D[2];
    public LayerMask playerLayer;

    public float chaseRadius = 5f;

    public float attackRadius = 2f;

    public bool CanChasePlayer => Physics2D.OverlapCircleNonAlloc(transform.position, chaseRadius, colliders, playerLayer) > 0;

    public bool CanAttackPlayer => Physics2D.OverlapCircleNonAlloc(transform.position, attackRadius, colliders, playerLayer) > 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    //private void Update()
    //{
    //    Debug.Log(IsDetectingPlayer);
    //    Debug.Log(colliders[0]);
    //}
}