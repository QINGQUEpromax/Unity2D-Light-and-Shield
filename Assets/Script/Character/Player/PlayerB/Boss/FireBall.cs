using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    GameObject boss;
    Animator animator;
    Collider2D collider2d;

    Vector3 dir;

    public float speed = 6f;

    public float damage;

    public float lifeTime;

    void Start()
    {
        boss = GameObject.Find("Boss");
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        dir = transform.localScale;

    }

    void Update()
    {
        Move();
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        if (boss.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-dir.x, dir.y, dir.z);
            transform.position += speed * -transform.right * Time.deltaTime;
        }
        else if (boss.transform.localScale.x > 0) 
        {
            transform.localScale = new Vector3(dir.x, dir.y, dir.z);
            transform.position += speed * transform.right * Time.deltaTime;
        }
    }
 
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            animator.Play("Hit");
            speed = 0;
            GetComponent<PlayerController>().PlayerHurt(damage);

        }
        else if (collision.CompareTag("Ground")) 
        {
            speed = 0;
            animator.Play("Hit");

        }
    }
}
