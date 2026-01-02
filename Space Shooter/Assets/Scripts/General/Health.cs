using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Action onDead;
    public Action onHealthChanged;
    public static int currentEnemyCount = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        onHealthChanged?.Invoke();
        if (currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        ExploAndDestroy exploScript = transform.gameObject.GetComponent<ExploAndDestroy>();
        exploScript.Explo();
        onDead?.Invoke();
        gameObject.SetActive(false);
    }
}