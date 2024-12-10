using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject pointPrefab;
    public float spawnInterval = 2f; 
    public Vector2 spawnAreaSize;

    private void Start()
    {
        InvokeRepeating("SpawnPoint", 1f, spawnInterval);
    }

    private void SpawnPoint()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(x, y);

        Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
    }
}
