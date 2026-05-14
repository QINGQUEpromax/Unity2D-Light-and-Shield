using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBShadowSprite : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("Time Settings")]
    public float activeTime;//激活的持续时间
    public float activeStart;//开始时间

    [Header("Alpha Settings")]
    public float alphaSet;
    [Range(0,1f)] public float alphaMultiplier;
    private float alpha;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("PlayerB").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        activeStart = Time.time;

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
    }
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1f, 1f, 1f, alpha);

        thisSprite.color = color;

        if(Time.time - activeStart > activeTime)
        {
            //返回对象池，在对象池代码中实现
            PlayerBShadowPool.Instance.ReturnPool(this.gameObject);
        }
    }
}
