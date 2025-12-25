using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public Action onDead;
    public static int currentEnemyCount = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        ExploAndDestroy exploScript = transform.gameObject.GetComponent<ExploAndDestroy>();
        exploScript.Explo();
        onDead?.Invoke();
        Destroy(gameObject);
    }
}