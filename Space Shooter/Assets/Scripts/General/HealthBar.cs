using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.maxHealth;
        health.onHealthChanged += UpdateHealthValue;
    }

    // Update is called once per frame
    void UpdateHealthValue()
    {

        healthBar.value = health.currentHealth;
        if (healthBar.value <= 0f)
        {
            GameObject fillArea = this.transform.Find("Fill Area").gameObject;
            fillArea.SetActive(false);
        }
    }
}
