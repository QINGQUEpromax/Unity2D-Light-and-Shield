using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [Header("盾牌防御")]
    [SerializeField] private float shieldRange = 1.5f; // 盾牌防御半径
    [SerializeField] private LayerMask enemyLayer;    

    private Transform playerTransform;
    private bool isFacingRight = true;

    private Vector2 GetshieldDirection()
    {
        return isFacingRight ? Vector2.right : Vector2.left;
    }

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        UpdateFacingDirection();
    }

    // 实时更新角色朝向
    private void UpdateFacingDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            isFacingRight = horizontal > 0;
        }
    }

    // 防御检测（由攻击系统调用）
    public bool CheckDefense(Vector2 attackOrigin)
    {
        // 计算敌人相对于玩家的方向
        Vector2 toEnemy = (attackOrigin - (Vector2)playerTransform.position).normalized;

        // 方向检测 + 距离检测
        return Vector2.Dot(toEnemy, GetshieldDirection()) > 0.7f &&
               Vector2.Distance(playerTransform.position, attackOrigin) < shieldRange;
    }
}