using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAbility : MonoBehaviour
{
    [SerializeField] bool dash = false;
    [SerializeField] bool breath = false;
    [SerializeField] bool wallJump = false;
    [SerializeField] bool airJump = false;
    [SerializeField] bool umbrella = false;
    public GameObject Panel;

    bool isPlayerIn = false;
    bool isPlayerA = false;
    bool isPlayerB = false;

    PlayerAInput playerA;
    PlayerBInput playerB;

    private void Awake()
    {
        playerA = FindAnyObjectByType<PlayerAInput>();
        playerB = FindAnyObjectByType<PlayerBInput>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            isPlayerIn = true;
            isPlayerA = true;
        }
        if (collision.CompareTag("PlayerB"))
        {
            isPlayerIn = true;
            isPlayerB = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            isPlayerA = false;
        }
        if (collision.CompareTag("PlayerB"))
        {
            isPlayerB = false;
        }
        if (!isPlayerA && !isPlayerB)
        {
            isPlayerIn = false;
        }
    }

    private void Update()
    {
        if (isPlayerIn)
        {
            if ((isPlayerA && Input.GetKey(KeyCode.DownArrow)) || (isPlayerB && Input.GetKey(KeyCode.S)))
            {
                Panel.SetActive(true);
                if (dash) playerB.gameObject.GetComponent<PlayerController>().activeDash = true;

                if (breath) playerB.gameObject.GetComponent<PlayerController>().activeBreath = true;
                if (breath) playerB.gameObject.GetComponent<PlayerController>().activeBreath = true;

                if (wallJump) playerB.gameObject.GetComponent<PlayerController>().activeWallJump = true;

                if (airJump) playerB.gameObject.GetComponent<PlayerController>().activeAirJump = true;
                if (airJump) playerA.gameObject.GetComponent<PlayerController>().activeAirJump = true;

                if (umbrella) playerA.gameObject.GetComponent<PlayerController>().activeUseUmbrella = true;
                Destroy(gameObject);
            }
        }
    }
}
