using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public GameObject interactionPrompt; // 交互提示UI
    public float detectionRadius = 2f; // 检测半径
    public float promptOffset = 1.5f;  // 提示UI与物体的垂直偏移量

    private RectTransform promptRectTransform; // 引用UI的RectTransform
    private Canvas canvas; // 引用Canvas组件

    private void Start()
    {
        // 获取UI的RectTransform和Canvas引用
        promptRectTransform = interactionPrompt.GetComponent<RectTransform>();
        canvas = interactionPrompt.GetComponentInParent<Canvas>();

        // 确保Canvas的渲染模式为Screen Space - Camera
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            Debug.LogError("Canvas render mode must be Screen Space - Camera.");
        }
    }

    private void Update()
    {
        // 检测玩家周围是否有可交互物体
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Controller")) // 确保检测到的是可交互物体
            {
                // 计算提示UI的世界空间位置
                Vector3 worldPosition = hit.transform.position + Vector3.up * promptOffset;

                // 将世界空间位置转换为屏幕空间位置
                Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

                // 将屏幕空间位置转换为UI的局部坐标
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform,
                    screenPosition,
                    Camera.main,
                    out Vector2 localPosition
                );

                // 更新UI的位置（使用anchoredPosition）
                promptRectTransform.anchoredPosition = localPosition;

                // 显示交互提示
                interactionPrompt.SetActive(true);
                return;
            }
        }

        // 如果没有检测到可交互物体，隐藏UI
        interactionPrompt.SetActive(false);
    }
}