using System.Collections;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject gunPrefab; // Assign your gun prefab in the inspector
    public float spawnInterval = 2f; // Time between spawns
    public float xMin = -8f; // Minimum x position (adjust based on your screen size)
    public float xMax = 8f;  // Maximum x position
    public float spawnHeight = 6f; // Y position for spawning (just above the screen)

    private void Start()
    {
        StartCoroutine(SpawnGuns());
    }

    IEnumerator SpawnGuns()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Generate a random x position within bounds
            float randomX = Random.Range(xMin, xMax);

            // Spawn the gun at the random position
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);
            Instantiate(gunPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
