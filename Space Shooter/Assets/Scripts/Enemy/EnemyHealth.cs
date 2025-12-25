using UnityEngine;

public class EnemyHealth : Health
{
    private void Awake()
    {
        currentEnemyCount++;
        onDead += () => { currentEnemyCount--; };
    }
    protected override void Die()
    {
        base.Die();
    }
}
