using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFire = 0f;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if (transform.position.y < -7f)
            Destroy(gameObject);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * 5f;
            Destroy(bullet, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerBullet"))
        {
            GameManager.instance.AddScore(100);
            GameManager.instance.PlayExplosionSound();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}