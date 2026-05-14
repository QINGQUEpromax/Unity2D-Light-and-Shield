using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossVineSpread : MonoBehaviour
{
    public GameObject bossVine;
    public GameObject activedBossVineSpread;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LightBallSpell lightBall;
        if(collision.TryGetComponent<LightBallSpell>(out lightBall))
        {
            lightBall.DestroyLightBall();
            Destroy(lightBall.gameObject);
            gameObject.SetActive(false);
            bossVine.SetActive(true);
            activedBossVineSpread.SetActive(true);
        }
    }
}
