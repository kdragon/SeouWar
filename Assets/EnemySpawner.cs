using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.8f;
    public float spawnRangeX = 5f;
    public float spawnZ = 30f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, 0.5f, spawnZ);
        // 적이 플레이어를 바라보도록 180도 회전하여 생성
        Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(0, 180, 0));
    }
}