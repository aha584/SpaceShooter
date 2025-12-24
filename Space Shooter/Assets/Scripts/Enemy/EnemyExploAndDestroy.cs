using UnityEngine;

public class EnemyExploAndDestroy : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other) => Die();

    private void Die()
    {
        GameObject exploClone = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploClone, 1);
        Destroy(gameObject);
    }
}
