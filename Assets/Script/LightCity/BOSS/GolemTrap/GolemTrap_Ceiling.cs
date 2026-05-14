using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class GolemTrap_Ceiling : MonoBehaviour
{
    public float damage;
    private GameObject Manager;
    public Vector3 startPosition;
    private float timer;
    private void Awake()
    {
        startPosition = gameObject.transform.position;
    }
    private void Start()
    {
        timer = 0;
        GolemTrapManager_Ceiling parentObject = this.transform.parent.gameObject.GetComponent<GolemTrapManager_Ceiling>();
        parentObject.Arrow.Add(gameObject);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
       gameObject.transform.position = startPosition;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        { timer = 0;
            gameObject.SetActive(false); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerB"))
        {
            timer = 0;
            collision.GetComponent<PlayerController>().PlayerHurt(damage);
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("GolemTrap"))
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
