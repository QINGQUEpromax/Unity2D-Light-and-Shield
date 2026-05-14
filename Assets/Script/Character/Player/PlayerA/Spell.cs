using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Spell:MonoBehaviour
{
    public string spellName;//魔法名
    public GameObject spellPrefab;//魔法预制体
    public float manaCost;//魔法消耗
    public float cooldown;//冷却时间
    public float currentCooldown;//当前冷却时间
    public bool isReady = true;//是否准备好

    public virtual void CastSpell(Transform casterTransform)//释放魔法
    {
        if (isReady)
        {
            isReady = false;
            Instantiate(spellPrefab, casterTransform.position, casterTransform.rotation);//生成魔法
            currentCooldown=cooldown;
        }
    }
    public virtual void UpdateCoolDown(float deltaTime)//更新冷却时间
    {
        if (!isReady)
        {
            currentCooldown -= deltaTime;
            if (currentCooldown <= 0)
            {
                isReady = true;
            }
        }
    }
}

