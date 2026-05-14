using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    public GameObject PlayerB;
    private SpriteRenderer sr;
    private void Start()
    {
        sr= GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        sr.flipX = PlayerB.GetComponent<SpriteRenderer>().flipX;

    }
    private void OnEnable()
    {
        if (PlayerB.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.transform.position = new Vector2((-1)*Mathf.Abs(transform.position.x), transform.position.y);
        }
        else
            gameObject.transform.position = new Vector2(Mathf.Abs(transform.position.x), transform.position.y);
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
