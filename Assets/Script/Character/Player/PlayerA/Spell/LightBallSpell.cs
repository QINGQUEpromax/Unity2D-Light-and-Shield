using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


[System.Serializable]
public class LightBallSpell : Spell
{
    public float duration = 30;//持续时间
    public GameObject lightBallPrefab;//光球预制体
    public float speed;//光球速度
    private GameObject lightBallInstance;//光球实例
    private float timer = 0;//计时器
    public Action onLightBallDestroyed;//   光球被摧毁委托
    private Rigidbody2D rb;//光球刚体
    private Vector2 direction;//光球方向
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void CastSpell(Transform casterTransform)
    {
        if (isReady)
        {
            //实例化光球
            lightBallInstance = Instantiate(lightBallPrefab, casterTransform.position, casterTransform.rotation);
            timer = 0;//重制计时器
            isReady = false;
        }
    }
    public override void UpdateCoolDown(float deltaTime)
    {
        if (lightBallInstance!=null)
        {
            //更新光球位置到鼠标位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            direction = (mousePosition - lightBallInstance.transform.position).normalized;
            lightBallInstance.GetComponent<Rigidbody2D>().velocity = direction * speed;
            //计时
            timer += deltaTime;
            if (timer>=duration)
            {
                DestroyLightBall();
            }
            //提前摧毁光球(光球至少存在三秒)
            if (timer >= 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DestroyLightBall();
                }
            }
        }
        else
        {
            base.UpdateCoolDown(deltaTime);
        }
    }
    public void DestroyLightBall()
    {
        //摧毁光球
        Destroy(lightBallInstance);
        lightBallInstance = null;

        //重置冷却时间
        timer = 0;
        isReady = false;
        currentCooldown = cooldown;
        //告知其他脚本光球已经被摧毁
        onLightBallDestroyed?.Invoke();
    }
}
