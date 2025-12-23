using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval;
    private float lastBulletTime;

    private void Start()
    {
        lastBulletTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        if (Time.time - lastBulletTime < shootingInterval) return;
        ShootBullet();
        lastBulletTime = Time.time;
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
