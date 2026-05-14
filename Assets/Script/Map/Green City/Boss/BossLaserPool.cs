using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossLaserPool : MonoBehaviour
{
    [Header("Laser Settings")]
    public float laserTimeDuration = 1f;
    public float laserCoolDownTime = 2f;
    public float laserHurt = 0.5f;
    float lastLaserTime;
    bool isCoolDown = false;

    public LineRenderer laserToPlayerA;
    public LineRenderer laserToPlayerB;

    PlayerAInput playerA;
    PlayerBInput playerB;

    PlayerController playerAController;
    PlayerController playerBController;

    private void OnEnable()
    {
        lastLaserTime = laserTimeDuration;

        laserToPlayerA.gameObject.SetActive(true);
        laserToPlayerB.gameObject.SetActive(true);

        playerA = FindAnyObjectByType<PlayerAInput>();
        playerB = FindAnyObjectByType<PlayerBInput>();

        playerAController = playerA.gameObject.GetComponent<PlayerController>();
        playerBController = playerB.gameObject.GetComponent<PlayerController>();

        InitLaser();
    }

    private void Update()
    {
        LaserAttack();
    }

    void InitLaser()
    {
        laserToPlayerA.SetPosition(0, transform.position);
        laserToPlayerB.SetPosition(0, transform.position);
    }

    void LaserAttack()
    {
        if (!isCoolDown)
        {
            if (Time.time - lastLaserTime <= laserTimeDuration)
            {
                laserToPlayerA.SetPosition(1, playerA.transform.position);
                laserToPlayerB.SetPosition(1, playerB.transform.position);
                SetLaserActiveTrue();

                playerAController.PlayerHurt(laserHurt);
                playerBController.PlayerHurt(laserHurt);
            }
            else
            {
                SetLaserActiveFalse();
                StartCoroutine(LaserCoolDownCoroutine());
            }
        }
    }
    IEnumerator LaserCoolDownCoroutine()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(laserCoolDownTime);
        isCoolDown = false;
        lastLaserTime = Time.time;
    }
    public void SetLaserActiveTrue()
    {
        laserToPlayerA.gameObject.SetActive(true);
        laserToPlayerB.gameObject.SetActive(true);
    }

    public void SetLaserActiveFalse()
    {
        laserToPlayerA.gameObject.SetActive(false);
        laserToPlayerB.gameObject.SetActive(false);
    }
}
