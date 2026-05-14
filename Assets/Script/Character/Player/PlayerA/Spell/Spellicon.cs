using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spellicon : MonoBehaviour
{
    public Spell spell;
    private void Update()
    {
        if (spell.currentCooldown<spell.cooldown&&spell.currentCooldown>0)
        { 
            gameObject.GetComponent<Image>().color = Color.gray;
        }
        else
            gameObject.GetComponent<Image>().color = Color.white;
    }
}
