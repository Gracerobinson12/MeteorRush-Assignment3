using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randomX = Random.Range(-8f, 8f);
            Vector3 spawnPos = new Vector3(randomX, 7f, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}