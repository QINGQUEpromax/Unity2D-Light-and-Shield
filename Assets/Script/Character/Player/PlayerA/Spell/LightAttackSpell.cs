using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class LightAttackSpell : Spell
{
    public float radius = 5;//施法范围
    private GameObject attackEffectInstance;//特效实例   
    public override void CastSpell(Transform casterTransform)
    {
        if (isReady)
        {
            //实例化回血特效
            attackEffectInstance = Instantiate(spellPrefab, casterTransform.position, casterTransform.rotation);
            isReady = false;
            currentCooldown = cooldown;
        }
    }
    public override void UpdateCoolDown(float deltaTime)
    {
        if (attackEffectInstance != null)
        {
            HealPlayersInRange(attackEffectInstance.transform.position, radius);
        }
        else
        {
            base.UpdateCoolDown(deltaTime);
        }
    }
    public void Destroy_LightAttackSpell()
    {
        Destroy(gameObject);
        attackEffectInstance = null;
        //isReady = true;
    }
    private void HealPlayersInRange(Vector3 center, float radius)//回血
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);//获取范围内的碰撞体
        foreach (var hitCollider in hitColliders)//遍历碰撞体
        {
            if (hitCollider.CompareTag("PlayerB"))//如果碰撞体是玩家
            {
                hitCollider.GetComponent<PlayerAttack>().StrengthenPower();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
