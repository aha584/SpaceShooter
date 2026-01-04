using UnityEngine;

public class BossHealthBar : HealthBar
{
    private void Start()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.maxHealth;
        health.onHealthChanged += UpdateBossHealthValue;
    }
    void UpdateBossHealthValue()
    {
        healthBar.value = health.currentHealth;
        if (healthBar.value <= 0f)
        {
            GameObject fillArea = this.transform.Find("Container/Fill Area").gameObject;
            fillArea.SetActive(false);
        }
    }
}
