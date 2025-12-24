using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]private float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y += bulletSpeed * Time.deltaTime;
        transform.position = newPos;
        if(transform.position.y > 9.6)
        {
            Destroy(gameObject);
        }
    }
}