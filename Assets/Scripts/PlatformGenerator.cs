using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public GameObject coinPrefab;

    public float distanceBetweenPlatforms = 4f;
    public float spawnAheadDistance = 25f;

    private float nextZ = 5f;

    void Start()
    {
        // Create platforms immediately in front of the player
        while (nextZ < player.position.z + spawnAheadDistance)
        {
            CreatePlatform();
        }
    }

    void Update()
    {
        // Keep creating platforms ahead of the player
        while (nextZ < player.position.z + spawnAheadDistance)
        {
            CreatePlatform();
        }
    }

    void CreatePlatform()
    {
        // Random platform position
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(1f, 1.5f);

        Vector3 position = new Vector3(x, y, nextZ);

        // Create platform
        Instantiate(platformPrefab, position, Quaternion.identity);

        // Create coin above the platform
        Vector3 coinPosition = new Vector3(
            x,
            y + 0.8f,
            nextZ
        );

        Instantiate(coinPrefab, coinPosition, Quaternion.identity);

        // Move to the next platform position
        nextZ += distanceBetweenPlatforms;
    }
}