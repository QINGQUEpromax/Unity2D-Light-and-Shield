using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform topPosition;//电梯的顶部位置
    public Transform bottomPosition;//电梯的底部位置
    public float moveSpeed=5;//电梯移动速度
    public bool isUnlocked = false;//电梯是否解锁
    private bool isMoving = false;//电梯是否在移动
    private Rigidbody2D rb;
    private float moveTime; // 移动时间
    public int floor = 0;//电梯当前所在楼层(0为第一层)(别改)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveElevator()
    {
        if (!isUnlocked)
            return;
        if (!isMoving)
        {
            isMoving = true;
            floor = (floor+1)%2;//切换楼层
            moveTime = 0;
        }
    }
    private void Update()
    {
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            //电梯移动
            Vector3 targetPosition = (floor==1) ? topPosition.position : bottomPosition.position;//检测电梯位置
            Vector2 currentPosition = transform.position;
            Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, moveTime * moveSpeed);
            Vector2 direction = (targetPosition - transform.position).normalized;
            rb.MovePosition(newPosition);
            //检测是否到达目标位置
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Debug.Log("电梯到达目标位置");
            }
        }
    }
}
