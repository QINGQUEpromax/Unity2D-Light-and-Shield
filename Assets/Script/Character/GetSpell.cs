using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GetSpell : MonoBehaviour
{
    public Spell spell;
    public GameObject Panel;
    public GameObject SpellIcon;
    private bool playerAIn=false;
    private GameObject PlayerA;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAIn=true;
            PlayerA=collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA"))
        {
            playerAIn = false;
        }
    }
    private void Update()
    {
        if (playerAIn && Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerA.GetComponent<SpellManager>().spells.Add(spell);
            Panel.SetActive(true);
            SpellIcon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
