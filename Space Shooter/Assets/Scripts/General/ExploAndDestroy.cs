using UnityEngine;

public class ExploAndDestroy : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Explo(bool isBoss)
    {
        if (isBoss)
        {
            GameObject exploCloneBoss = Instantiate(explosionPrefab, transform.position, transform.rotation);
            exploCloneBoss.transform.localScale = explosionPrefab.transform.localScale * 3;
            Destroy(exploCloneBoss, 1);
            return;
        }
        GameObject exploClone = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploClone, 1);
    }
}