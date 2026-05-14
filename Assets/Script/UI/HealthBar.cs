using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float moveSpeed;
    public float currentHealth;
    public float maxHealth;
    private float health;
    private float health_Back;//背景血条(装饰用
    private float timer=0;
    private Slider healthSlider;
    public Slider healthSlider_Back;
    private void Start()
    {
        healthSlider = gameObject.GetComponent<Slider>();
    }
    private void Update()
    {
        if (Mathf.Abs(health-currentHealth)>0.1f)
            health+=(currentHealth-health)*Time.deltaTime*moveSpeed;
        if (health!=health_Back)
        {
            timer += Time.deltaTime;
            if (timer>0.4f)
            {
                health_Back += (health - health_Back) * Time.deltaTime * moveSpeed;
            }
        }
        if (Mathf.Abs(health-health_Back)<0.1f)
            timer = 0;
        healthSlider.value = health/maxHealth;
        healthSlider_Back.value = health_Back/maxHealth;
    }
}
