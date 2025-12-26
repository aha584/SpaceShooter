using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyWave> enemyWaves = new();

    private int currentWave = 0;
    private int numberEnemyInWave = 0;
    private float timerForEnemy = 0;

    private void Start()
    {
        var waveInfo = enemyWaves[currentWave];
        var flyPath = waveInfo.flyPath.GetComponent<FlyPath>();
        var startPosition = flyPath.waypoints[0].transform.position;

        var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
        var agent = enemy.GetComponent<FlyPathAgent>();
        agent.flyPathObject = waveInfo.flyPath;
        agent.duration = waveInfo.duration;

        numberEnemyInWave++;
        timerForEnemy = 0;
    }

    void Update()
    {
        if (currentWave >= enemyWaves.Count) return;
        var waveInfo = enemyWaves[currentWave];
        var flyPath = waveInfo.flyPath.GetComponent<FlyPath>();
        var startPosition = flyPath.waypoints[0].transform.position;
        timerForEnemy += Time.deltaTime;
        if (timerForEnemy < waveInfo.spawnDelay) return;
        if (numberEnemyInWave >= waveInfo.numberOfEnemys)
        {
            currentWave++;
            timerForEnemy = 0;
            numberEnemyInWave = 0;
        }
        else
        {
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
            var agent = enemy.GetComponent<FlyPathAgent>();
            agent.flyPathObject = waveInfo.flyPath;
            agent.duration = waveInfo.duration;

            numberEnemyInWave++;
            timerForEnemy = 0;
        }
    }

    public bool IsEndWave() => currentWave < enemyWaves.Count; 
}
