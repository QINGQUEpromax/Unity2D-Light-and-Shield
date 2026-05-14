using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnterGate : MonoBehaviour
{
    public Vector3 offset = new Vector3(1f,0f,0f);

    public GameObject bossDoor;

    public GameObject boss;

    PlayerAInput playerA;
    PlayerBInput playerB;

    private void OnEnable()
    {
        playerA = FindAnyObjectByType<PlayerAInput>();
        playerB = FindAnyObjectByType<PlayerBInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bossDoor.SetActive(true);
        if (collision.CompareTag("PlayerA")) playerB.transform.position = playerA.transform.position + offset;
        else if (collision.CompareTag("PlayerB")) playerA.transform.position = playerB.transform.position + offset;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        boss.SetActive(true);
        Destroy(gameObject);
    }
}
