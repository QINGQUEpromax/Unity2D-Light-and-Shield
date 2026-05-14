using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor_CannotClose : MonoBehaviour
{
    public Sprite closedDoorSprite;//关闭的门的贴图
    public Sprite openDoorSprite;//打开的门的贴图
    public bool isOpen = false;//门是否打开
    public SpriteRenderer SpriteRenderer;//门的贴图渲染器
    public BoxCollider2D boxCollider2D;//门的碰撞体
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer.sprite = closedDoorSprite;//初始贴图为关闭的门
    }
    public virtual void OpenDoor()
    {
        isOpen = true;//设置为打开状态
        SpriteRenderer.sprite = openDoorSprite;//切换贴图为打开的门
        boxCollider2D.enabled = false;//关闭碰撞体
    }
}
