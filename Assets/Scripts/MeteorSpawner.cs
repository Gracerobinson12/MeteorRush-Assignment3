using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 4f;
    private float nextSpawn = 2f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float randomX = Random.Range(-6f, 6f);
            float spawnY = Random.Range(-1f, -2f);
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0);
            Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        }
    }
}