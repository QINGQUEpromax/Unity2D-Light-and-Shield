using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 5.0f;
    public float damage = 10.0f;
    public Vector2 direction = new Vector2(1, 0);
    private Rigidbody2D rb;
    private bool isReleased = false; // 新增标志�?

    public ObjectPool<GameObject> arrowPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Initialize();
    }

    public void Initialize()
    {
        rb.velocity = direction * speed;
        // 替换 Destroy，使�? Invoke 延迟回收
        Invoke(nameof(ReleaseArrow), lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            collision.GetComponent<PlayerController>().PlayerHurt(damage);
        }

        CancelInvoke(nameof(ReleaseArrow)); // 取消延迟回收
        ReleaseArrow(); // 立即回收
    }

    private void ReleaseArrow()
    {
        if (!isReleased && arrowPool != null)
        {
            isReleased = true;
            arrowPool.Release(gameObject);
        }
    }

    public void ResetState()
    {
        isReleased = false;
        if(rb==null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        CancelInvoke(nameof(ReleaseArrow));
        Invoke(nameof(ReleaseArrow), lifetime);
    }
}
