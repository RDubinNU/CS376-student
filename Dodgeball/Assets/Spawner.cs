using UnityEngine;

/// <summary>
/// Periodically spawns the specified prefab in a random location.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 20;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    public float timer = 0;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        // TODO

        if (Time.time > timer) {

            Vector2 spawnPoint = SpawnUtilities.RandomFreePoint(FreeRadius);
            GameObject enemy = Instantiate(Prefab, spawnPoint, Quaternion.identity);
           
            timer += SpawnInterval;
        }
    }
}
