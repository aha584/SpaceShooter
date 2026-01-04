using UnityEngine;
using TMPro;

public class BossHealth : EnemyHealth
{
    public GameObject healthSlider;
    public string bossName;

    private bool oneTimeInvoke = true;

    private void Awake()
    {
        currentEnemyCount++;
        Debug.Log("Boss Awake:" + currentEnemyCount);
        onDead += () => { currentEnemyCount--; };
    }
    private void Update()
    {
        if (healthSlider == null) return;
        if (oneTimeInvoke)
        {
            healthSlider = GameObject.Find("Boss Health");
            BossHealthBar healthBarScript = healthSlider.GetComponent<BossHealthBar>();
            healthBarScript.health = this;

            var containerTransform = healthSlider.transform.Find("Container");

            Transform bossNameTextTransform = containerTransform.Find("Name");
            TMP_Text bossNameText = bossNameTextTransform.GetComponent<TMP_Text>();
            bossNameText.text = bossName;
            bossNameText.ForceMeshUpdate();

            containerTransform.gameObject.SetActive(true);
            oneTimeInvoke = false;
        }
    }
    protected override void Die()
    {
        Debug.Log("Boss Die:" + currentEnemyCount);
        ExploAndDestroy exploScript = transform.gameObject.GetComponent<ExploAndDestroy>();
        exploScript.Explo(true);
        onDead?.Invoke();
        gameObject.SetActive(false);
    }
}
