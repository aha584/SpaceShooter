using UnityEngine;
using System;

public class PlayerHealth : Health
{
    public Action onWin;
    protected override void Die()
    {
        base.Die();
    }
    public void CheckWin()
    {
        if (currentEnemyCount <= 0)
        {
            onWin?.Invoke();
        }
    }
}
