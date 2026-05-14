using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class LightHealingSpell : Spell
{
    public float duration=3;
    public float healAmountPerSecond = 10;//每秒回血量
    public float radius = 5;//回血范围
    private GameObject healingEffectInstance;//回血特效实例   
    public override void CastSpell(Transform casterTransform)
    {
        if (isReady)
        {
            //实例化回血特效
            healingEffectInstance = Instantiate(spellPrefab, casterTransform.position, casterTransform.rotation);
            isReady = false;
        }
    }
    public override void UpdateCoolDown(float deltaTime)
    {
        if (healingEffectInstance != null)
        {

            HealPlayersInRange(healingEffectInstance.transform.position, radius, healAmountPerSecond * deltaTime);
        }
        else
        {
            base.UpdateCoolDown(deltaTime);
        }
    }
    public void Destroy_LightHealingSpell()
    {
        Destroy(gameObject);
        healingEffectInstance = null;
        //isReady = true;
    }
    private void HealPlayersInRange(Vector3 center, float radius, float healAmount)//回血
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);//获取范围内的碰撞体
        foreach (var hitCollider in hitColliders)//遍历碰撞体
        {
            if (hitCollider.CompareTag("PlayerA")|| hitCollider.CompareTag("PlayerB"))//如果碰撞体是玩家
            {
                hitCollider.GetComponent<HealthController>().Heal(healAmount);//回血
                Debug.Log("回血");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
