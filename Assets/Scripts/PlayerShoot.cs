using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.3f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bulletSpeed;
            Destroy(bullet, 3f);
        }
    }
}