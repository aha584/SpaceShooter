using UnityEngine;

public class EnemyHealth : Health
{
    private void Awake()
    {
        currentEnemyCount++;
        Debug.Log("Enemy Awake: " + currentEnemyCount);
        onDead += () => { currentEnemyCount--; };
    }
    protected override void Die()
    {
        Debug.Log("Enemy Die: " + currentEnemyCount);
        base.Die();
    }
}
