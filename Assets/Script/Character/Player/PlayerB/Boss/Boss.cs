using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle, Attack, Dash, Hurt, Death
}
public class Boss : MonoBehaviour
{
    Transform bossTra;
    Transform mouth;
    Rigidbody2D rb;
    Animator animator;
    public AudioSource attackAudio;
    public AudioSource deathkAudio;
    public AudioSource bgm;
    public GameObject airWall;
    public GameObject Fireball;//火球的预制体

    public float checkRange;//检测范围
    public LayerMask playerLayer;

    Vector2 initial;

    BossState state;

    public float maxHp;
    public float currentHp;
    public float dashDamage;
    public float dashSpeed;
    public float idleTime;
   
    public int fireBallAttackTime;
   

    public bool isHurt;
    public bool isDead;

    void Awake()
    {
        bossTra = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mouth = transform.Find("Mouth");

        initial = bossTra.localScale;

        state = BossState.Idle;

       
    }
    void Update()
    {
        Collider2D[] chaseColiders = Physics2D.OverlapCircleAll(transform.position, checkRange, playerLayer);
        if (chaseColiders.Length > 0)//玩家在Boss感知范围内
        {
            CheckHp();
            switch (state)
            {
                case BossState.Attack:
                    {
                        FireBallAttack();
                        break;
                    }
                case BossState.Dash:
                    {
                        DashSkill();
                        break;
                    }
                case BossState.Idle:
                    {
                        IdleProccess();
                        break;
                    }
                case BossState.Hurt:
                    {
                        BeHitProccess();
                        break;
                    }
                case BossState.Death:
                    {
                        animator.Play("Death");
                        break;
                    }
            }
        }

        if(isDead)
        {
            airWall.SetActive(false);
        }
    }
    public void FireBallAttack() //吐火球
    {
        animator.Play("Attack");
        if (fireBallAttackTime <= 0 && !isDead)
        {
            state = BossState.Idle;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void FireBallCreate() //生成火球(动画帧事件)
    {
        if (bossTra.localScale.x == initial.x)
        {
            for (int i = -4; i < 8; i++)
            {
                GameObject fireball = Instantiate(Fireball, null);
                Vector3 dir = Quaternion.Euler(0, i * 15, 0) * -transform.right;
                fireball.transform.position = mouth.position + dir * -1.0f;
                fireball.transform.rotation = Quaternion.Euler(0, 0, i * 1015);
            }
        }
        else if (bossTra.localScale.x == -initial.x)
        {
            for (int i = -4; i < 8; i++)
            {
                GameObject fireball = Instantiate(Fireball, null);
                Vector3 dir = Quaternion.Euler(0, i * 15, 0) * transform.right;
                fireball.transform.position = mouth.position + dir * -1.0f;
                fireball.transform.rotation = Quaternion.Euler(0, 0, i * 15);
            }
        }
        fireBallAttackTime -= 1;
    }
    public void DashSkill()
    {
        if (!isDead)
        {
            Dash();
            idleTime = 5f;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void Dash()//冲撞 
    {
        if (bossTra.localScale.x == initial.x)
        {
           animator.Play("Dash");
            rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
        }
        else if (bossTra.localScale.x == -initial.x)
        {
            animator.Play("Dash");
            rb.velocity = new Vector2(-dashSpeed, rb.velocity.y);
        }
    }
    
    public void IdleProccess()
    {
        animator.Play("Idle");
        idleTime -= Time.deltaTime;
        if (currentHp <= maxHp / 2 && idleTime > 0)
        {
            fireBallAttackTime = 5;
        }
        else if (currentHp > maxHp / 2 && idleTime > 0)
        {
            fireBallAttackTime = 3;
        }
        if (idleTime <= 0 && !isHurt && !isDead)
        {
            state = BossState.Dash;
        }
        else if (isHurt && !isDead)
        {
            state = BossState.Hurt;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void BeHitProccess()
    {
        animator.Play("Hurt");
        idleTime -= Time.deltaTime;
        if (!isHurt && !isDead)
        {
            state = BossState.Idle;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void BeHit(float Damage)
    {
        currentHp -= Damage;
        isHurt = true;
    }
    public void BeHitOver()
    {
        isHurt = false;
    }
    public void CheckHp()
    {
        if (currentHp <= 0)
        {
            isDead = true;
            deathkAudio.Play();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void PlayAttackAudio()
    {
        attackAudio.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AirWall"))
        {
            bossTra.localScale = new Vector3(-bossTra.localScale.x, bossTra.localScale.y, bossTra.localScale.z);
            state = BossState.Attack;
        }
        else if ((collision.collider.CompareTag("PlayerA") || collision.collider.CompareTag("PLayerB")) && state == BossState.Dash)
        {
            GetComponent<PlayerController>().PlayerHurt(dashDamage);
        }
    }

    private void OnDrawGizmosSelected()//用于检测玩家是否进入boss范围
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRange);

    }
}
