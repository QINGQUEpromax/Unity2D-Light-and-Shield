using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public float moveSpeed;
    public float currentMana;
    public float maxMana=100;
    private float mana;
    private Slider manaSlider;
    private void Start()
    {
        manaSlider = gameObject.GetComponent<Slider>();
    }
    private void Update()
    {
        if (Mathf.Abs(mana - currentMana) > 0.1f)
            mana += (currentMana - mana) * Time.deltaTime * moveSpeed;
        manaSlider.value = mana / maxMana;
    }
}
