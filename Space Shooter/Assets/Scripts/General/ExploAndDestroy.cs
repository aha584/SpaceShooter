using UnityEngine;

public class ExploAndDestroy : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Explo()
    {
        GameObject exploClone = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploClone, 1);
    }
}