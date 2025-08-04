using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int treeCount = 10; // Количество деревьев
    public float spawnRadius = 20f;

    void Start()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                0,
                Random.Range(-spawnRadius, spawnRadius)
            );
            Instantiate(treePrefab, spawnPos, Quaternion.identity);
        }
    }
}
