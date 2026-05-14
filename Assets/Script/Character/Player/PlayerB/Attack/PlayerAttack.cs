using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController pC;
    private int weaponIndex = 0;

    [Header("��ս����")]
    public bool canAttack = true;
    public float normalDamage;//�����˺�
    public  float currentDamage;//��ս�����˺�
    public Vector2 attackSize = new Vector2(1f, 1f);//������Χ�ĳߴ�
    public float offsetX = 1f;//X���ƫ����
    public float offsetY = 1f;//Y���ƫ����
    public LayerMask enemyLayer;//��ʾ����ͼ��
    public Vector2 AttackAreaPos;
    [Header("ǿ������")]
    public float strenthenDamage;//ǿ���󹥻�
    public float duration;
    private float time;
    public GameObject buff;

    [Header("����")]
    public GameObject[] shield;
    public GameObject VFX1;
    public GameObject VFX2;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer shieldSr;
    public PlayerBInput player;

    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerBInput>();
        pC = GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        buff.SetActive(false);
        currentDamage = normalDamage;
        time = duration;
    }

    private void Update()
    {
        if(canAttack && !pC.isDie && !pC.isHurt && !pC.isWallJumping && !pC.isWallSliding && player.canInput)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (weaponIndex == 0)
                {
                    anim.Play("Attack1");
                    canAttack = false;
                }
                else if (weaponIndex == 1)
                {
                    anim.Play("Attack2");
                    canAttack = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            for(int i = 0; i < shield.Length; ++i)
            {
                shield[i].SetActive(true);
            }
            shieldSr.enabled = true;
            sr.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            for (int i = 0; i < shield.Length; ++i)
            {
                shield[i].SetActive(false);
            }
            shieldSr.enabled = false;
            sr.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            weaponIndex++;
            if(weaponIndex > 1)
            {
                weaponIndex = 0;
            }
        }
    }

    void MeleeAttackAnimEvent()
    {
        //����ƫ����
        AttackAreaPos = transform.position;

        //�Ƿ�ת
        offsetX = transform.localScale.x <= 0 ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] enemyHitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, enemyLayer);

        foreach (Collider2D hitCollider in enemyHitColliders)
        {
            hitCollider.GetComponent<EnemyController>().EnemyHurt(currentDamage);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawCube(AttackAreaPos, attackSize);
    //}

    void SetAnim()
    {
        canAttack = true;
    }

    public void StrengthenPower()
    {
        currentDamage = strenthenDamage;
        duration = Time.deltaTime;
        buff.SetActive(true);
        if (duration <= 0.1f)
        {
            buff.SetActive(false);
            duration = time;
            currentDamage = normalDamage;
        }
    }
    public void Attack_anim_Begin1()
    {
        VFX1.SetActive(true);
    }
    public void Attack_anim_Begin2()
    {
        VFX2.SetActive(true);
    }
}
