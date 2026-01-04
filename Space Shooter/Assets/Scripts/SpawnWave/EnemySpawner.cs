using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public LevelInfo levelInfo;

    private List<EnemyWave> enemyWaves = new();
    public int currentLevel = 1;
    public HealthBar bossHealthBar;

    private int previousLevel = 1;
    private int currentWave = 0;
    private int numberEnemyInWave = 0;
    private float timerForEnemy = 0;

    //Load Level Through Resource
    //Level Made From Scriptable Object
    private void Start()
    {
        bossHealthBar.gameObject.SetActive(false);
        LoadLevel();
        /*var waveInfo = enemyWaves[currentWave];
        var flyPath = waveInfo.flyPath.GetComponent<FlyPath>();
        var startPosition = flyPath.waypoints[0].transform.position;

        var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
        var agent = enemy.GetComponent<FlyPathAgent>();
        agent.flyPathObject = waveInfo.flyPath;
        agent.duration = waveInfo.duration;

        numberEnemyInWave++;
        timerForEnemy = 0;*/
    }

    void Update()
    {
        if(previousLevel != currentLevel)
        {
            LoadLevel();
            previousLevel = currentLevel;
        }
        if (currentWave >= enemyWaves.Count && numberEnemyInWave == 0)
        {
            GameObject bossClone = Instantiate(levelInfo.bossPrefab);
            BossHealth bossHealth = bossClone.GetComponent<BossHealth>();
            bossHealthBar.health = bossHealth;
            bossHealthBar.gameObject.SetActive(true);
            bossHealth.healthSlider = bossHealthBar.gameObject;
            numberEnemyInWave++;
            return;
        }
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

    private void LoadLevel()
    {
        levelInfo = Resources.Load<LevelInfo>($"Levels/Level{currentLevel}");
        if (levelInfo == null) return;
        currentWave = 0;
        numberEnemyInWave = 0;
        timerForEnemy = 0;
        enemyWaves.Clear();

        enemyWaves = levelInfo.enemyWaves;
    }

    public bool IsRemainWave() => currentWave < enemyWaves.Count - 1; 
}
