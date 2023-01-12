using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public static bool HasBossSpawned = false;
    private static uint ScoreFrequencyForBoss = 300;
    public ScoreManager ScoreManager;
    private static GameObject boss = null;
    private ulong currentScore;

    // Update is called once per frame
    void Update()
    {
        currentScore = (ulong)ScoreManager.GetScore();
        // Score > 0, hasn't already spawned and not in pause
        if (currentScore != 0 && currentScore % ScoreFrequencyForBoss == 0 && !HasBossSpawned && Time.timeScale != 0f) {
            Debug.Log("Destroying everything");
            SpawnObstacles.DestroyAllObstacles(); // Clearing all obstacles
            Spawn();  // Spawning the big boss
        }
    }

    void Spawn()
    {
        boss = Instantiate(bossPrefab, transform.position + new Vector3(0, 3, 0), transform.rotation);
        HasBossSpawned = true;
    }

    public static Boss GetBossInstance() => boss.GetComponent<Boss>();

    public static void DestroyBoss()
    {
        if (boss != null)
        {
            Debug.Log("So long, boss");
            HasBossSpawned = false;
            Destroy(boss);
            boss = null;
        }
    }
}
