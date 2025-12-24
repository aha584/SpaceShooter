using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

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
        Destroy(gameObject);
    }
}