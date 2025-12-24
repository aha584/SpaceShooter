using UnityEngine;

public class ExploAndDestroy : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other) => Explo();

    public void Explo()
    {
        GameObject exploClone = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploClone, 1);
    }
}