using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{
    public float collideDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject enemy = other.gameObject;
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth == null) return;
        enemyHealth.TakeDamage(collideDamage);
    }
}
