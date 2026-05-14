using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenMucus : MonoBehaviour
{
    protected Animator anim;

    protected PlayerAInput playerA;
    protected PlayerBInput playerB;
    protected BossMucusPool bossMucusPool;

    protected int playerObject;

    protected float speed;

    protected virtual void OnEnable()
    {
        playerA = FindAnyObjectByType<PlayerAInput>();
        playerB = FindAnyObjectByType<PlayerBInput>();

        bossMucusPool = FindAnyObjectByType<BossMucusPool>();
        
        anim = GetComponent<Animator>();

        speed = bossMucusPool.mucusSpeed;

        anim.Play("MucusMove");
    }

    private void Update()
    {
        ChaseToPlayer();
    }

    protected virtual void ChaseToPlayer()
    {
        if(playerObject == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerA.transform.position, speed * Time.deltaTime);
        }
        else if(playerObject == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerB.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if(collision.TryGetComponent<PlayerController>(out player))
        {
            anim.SetTrigger("Hurt");
            player.PlayerHurt(1);
        }
    }

    public void ChaseToPlayerA()
    {
        playerObject = 1;
    }

    public void ChaseToPlayerB()
    {
        playerObject = 2;
    }

    public void SetMucusActive()
    {
        gameObject.SetActive(false);
    }
}
