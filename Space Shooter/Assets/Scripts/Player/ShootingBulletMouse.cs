using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingBulletMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval;
    public Vector3 bulletOffset;

    private float lastBulletTime;

    private void Start()
    {
        lastBulletTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        if (!mouse.leftButton.isPressed) return;
        if (Time.time - lastBulletTime < shootingInterval) return;
        ShootBullet();
        lastBulletTime = Time.time;
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);
    }
}