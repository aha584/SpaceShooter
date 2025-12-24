using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    [SerializeField] private float collideDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth == null) return;
        playerHealth.TakeDamage(collideDamage);
    }
}
