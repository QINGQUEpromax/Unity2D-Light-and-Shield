using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public Transform trackStart;
    public Transform trackEnd;
    public float moveSpeed = 5;
    private Rigidbody2D rb;
    public bool isMoving = false;
    private Vector2 targetPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private Vector2 GetMousePositionOnTrack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        float t = InverseLerp(trackStart.position, trackEnd.position, mousePosition);
        t=Mathf.Clamp01(t);//限制t的范围在0-1之间
        return Vector2.Lerp(trackStart.position, trackEnd.position, t);
    }
    private float InverseLerp(Vector2 a,Vector2 b,Vector2 value)
    { 
        Vector2 delta = b - a;//计算两点之间的差值
        Vector2 deltaValue = value - a;//计算目标点与起始点之间的差值
        if (delta.sqrMagnitude<Mathf.Epsilon)
        { return 0.0f; }//避免除以0
        return Vector2.Dot(deltaValue, delta) / delta.sqrMagnitude;

    }
    private void Update()
    {
        if (isMoving)
        {
            Vector2 targetPosition = GetMousePositionOnTrack();//获取鼠标在轨道上的位置
            Vector2 currentPosition = rb.position;//获取当前位置
            Vector3 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
    }
}
