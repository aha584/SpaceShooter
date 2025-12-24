using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float bulletDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject damagedEnemy = other.gameObject;
        EnemyHealth enemyHealthScript = damagedEnemy.GetComponent<EnemyHealth>();
        if (enemyHealthScript == null) return;
        enemyHealthScript.TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
