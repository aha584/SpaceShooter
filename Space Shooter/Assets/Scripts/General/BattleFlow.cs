using UnityEngine;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public GameObject playerObject;
    PlayerHealth playerHealth;
    public GameObject enemySpawnerGO;
    EnemySpawner enemySpawner;
    public GameObject bgMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        enemySpawner = enemySpawnerGO.GetComponent<EnemySpawner>();
        playerHealth.onDead += OnGameOver;
        playerHealth.onWin += OnGameWin;
    }
    private void Update()
    {
        if (playerObject == null) return;
        if (enemySpawner.IsEndWave()) return;
        playerHealth.CheckWin();
    }
    private void OnGameOver()
    {
        gameOverUI.SetActive(true);
        bgMusic.SetActive(false);
    }
    private void OnGameWin()
    {
        gameWinUI.SetActive(true);
        bgMusic.SetActive(false);
    }
}
