using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCityBossController : HealthController
{
    [SerializeField] VoidEventChannel bossGateExitEventChannel;

    Rigidbody2D rb;
    Animator anim;

    BossLaserPool LaserPool;
    BossMucusPool MucusPool;
    BossEnemyPool EnemyPool;

    float waveInternal = 1f;
    bool isFirstWave = false;
    bool isSecondWave = false;
    bool isThirdWave = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LaserPool = GetComponentInChildren<BossLaserPool>();
        MucusPool = GetComponentInChildren<BossMucusPool>();
        EnemyPool = GetComponentInChildren<BossEnemyPool>();

        EnemyPool.gameObject.SetActive(false);
        MucusPool.gameObject.SetActive(false);
        LaserPool.gameObject.SetActive(false);
    }

    private void Update()
    {
        FirstWave();
        SecondWave();
        ThirdWave();
        if (currentHealth <=0 && !isDie)
        {
            Die();
        }
    }

    //ÈýÖÖ¹¥»÷·½Ê½£º¼¤¹â¹¥»÷£¬ÂÌÇòÕ³Òº×·×Ù¹¥»÷£¬ÕÙ»½Ð¡¹Ö
    #region ¼¤¹â¹¥»÷
    void LaserAttack()
    {
        LaserPool.gameObject.SetActive(true);
    }
    #endregion

    #region ÂÌÇòÕ³Òº×·×Ù¹¥»÷
    void MucusAttack()
    {
        MucusPool.gameObject.SetActive(true);
    }
    #endregion

    #region ÕÙ»½Ð¡¹Ö
    void SpawnEnemyAttack()
    {
        EnemyPool.gameObject.SetActive(true);
    }
    #endregion

    //ÑªÁ¿ÔÚ75µ½100Ê¹ÓÃÂÌÇòÕ³Òº¹¥»÷£¬ÔÚ25µ½75ÕÙ»½±¬Õ¨Ð¡¹Ö£¬ÔÚ0µ½25ÕÙ»½±¬Õ¨Ð¡¹ÖµÄÍ¬Ê±Æô¶¯¼¤¹â¹¥»÷
    #region Èý²¨¹¥»÷
    void FirstWave()
    {
        if (currentHealth >= 75 && currentHealth <= 100 && !isFirstWave)
        {
            Debug.Log("FirstWave");
            StartCoroutine(nameof(FirstWaveCoroutine));
            isFirstWave = true;
        }
    }

    IEnumerator FirstWaveCoroutine()
    {
        yield return new WaitForSeconds(waveInternal);
        MucusAttack();
    }

    void SecondWave()
    {
        if(currentHealth >= 25 && currentHealth < 75 && !isSecondWave)
        {
            Debug.Log("SecondWave");
            StartCoroutine(nameof(SecondWaveCoroutine));
            isSecondWave = true;
        }
    }

    IEnumerator SecondWaveCoroutine()
    {
        MucusPool.gameObject.SetActive(false);
        yield return new WaitForSeconds(waveInternal);
        SpawnEnemyAttack();
    }

    void ThirdWave()
    {
        if (currentHealth >= 0 && currentHealth < 25 && !isThirdWave)
        {
            Debug.Log("ThirdWave");
            StartCoroutine(nameof(ThirdWaveCoroutine));
            isThirdWave = true;
        }
    }

    IEnumerator ThirdWaveCoroutine()
    {
        MucusPool.gameObject.SetActive(false);
        yield return new WaitForSeconds(waveInternal);
        LaserAttack();
        SpawnEnemyAttack();
    }
    #endregion

    //BossÊÜÉË
    #region ÊÜÉË
    public void BossHurt(float damage)
    {
        TakeDamage(damage);
        anim.SetTrigger("Hurt");
        isHurt = true;
    }

    public void SetHurt()
    {
        isHurt = false;
    }
    #endregion

    #region ËÀÍö
    void Die()
    {
        isDie = true;
        anim.Play("Die");
        bossGateExitEventChannel.Broadcast();
        Destroy(gameObject,1f);
    }
    #endregion

    #region ¶¯»­¿ØÖÆ
    #endregion
}
