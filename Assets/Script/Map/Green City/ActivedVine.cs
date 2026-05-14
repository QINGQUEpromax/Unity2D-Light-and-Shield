using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedVine : MonoBehaviour
{
    [SerializeField] VoidEventChannel bossVineVoidEventChannel;

    public GameObject bossVineSpreadUnactived;
    public GameObject bossVineSpreadUnactived1;

    public GameObject bossVineSpread;
    public GameObject bossVineSpread1;

    private void OnEnable()
    {
        if(CompareTag("BossVine")) bossVineVoidEventChannel.Addlistener(SetBossVineUnactive);
    }

    private void OnDisable()
    {
        if(CompareTag("BossVine")) bossVineVoidEventChannel.Removelistener(SetBossVineUnactive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if (collision.TryGetComponent<PlayerController>(out player))
        {
            player.canCornerCorrect = false;
            player.EnterClimb();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player;
        if (collision.TryGetComponent<PlayerController>(out player))
        {
            player.canCornerCorrect = true;
            player.ExitClimb();
        }
    }

    void SetBossVineUnactive()
    {
        gameObject.SetActive(false);

        bossVineSpread.SetActive(false);
        bossVineSpreadUnactived.SetActive(true);

        bossVineSpread1.SetActive(false);
        bossVineSpreadUnactived1.SetActive(true);
    }
}
