using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouHuo : MonoBehaviour
{
    Animation anim;
    public GameObject portalPanel; // ����UI���
    public bool isActive;//�Ƿ񼤻�
    public bool isPanel;//�Ƿ��������
    public bool isRange;
    private bool PlayerAIn=false;
    private bool PlayerBIn=false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void Start()
    {
        isActive = false;
        isPanel = false;
    }
    private void Update()
    {
        if (PlayerBIn||PlayerAIn)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {

                isActive = true;
                portalPanel.SetActive(true);
                isPanel = true;
           
            }
        }
        if ((!PlayerAIn)&&(!PlayerBIn))
        {
            portalPanel.SetActive(false);
            isPanel = false;
    
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            PlayerAIn = true;
        }
        if (collision.CompareTag("PlayerB"))
        {
            PlayerBIn = true;
        }
    }
    //private void OnTriggerEnter2D(Collider other)
    //{
    //    if (other.CompareTag("PlayerA"))
    //    {
    //        PlayerAIn = true;
    //    }
    //    if (other.CompareTag("PlayerB"))
    //    {
    //        PlayerBIn = true;
    //    }
    //    //if ((other.CompareTag("PlayerA") || other.CompareTag("PlayerB")) && Input.GetKeyDown(KeyCode.P))
    //    //{

    //    //    isActive = true;
    //    //    portalPanel.SetActive(true);
    //    //    isPanel = true;
    //    //    input.enabled = false;
    //    //}
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            PlayerAIn = true;
        }
        if (collision.CompareTag("PlayerB"))
        {
            PlayerBIn = true;
        }
    }
    //private void OnTriggerExit2D(Collider other)
    //{
    //    if (other.CompareTag("PlayerA"))
    //    {
    //        PlayerAIn = true;
    //    }
    //    if (other.CompareTag("PlayerB"))
    //    {
    //        PlayerBIn = true;
    //    }
    //    //if (other.CompareTag("PlayerA")|| other.CompareTag("PlayerB"))
    //    //{
    //    //    portalPanel.SetActive(false);
    //    //    isPanel = false;
    //    //    input.enabled = true;
    //    //}
    //}
}
