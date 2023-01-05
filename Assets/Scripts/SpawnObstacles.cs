using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
	public GameObject obstacle;
    private static List<GameObject> obstacles = new List<GameObject>();
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float timeBetweenSpawn;
	private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime && !SpawnBoss.HasBossSpawned)  // Add condition to avoid spawns during boss fight
        {
        	Spawn();
        	spawnTime = Time.time + timeBetweenSpawn;
            Debug.Log(obstacles.Count);
        }
    }
    
    void Spawn()
    {
    	float randomX = Random.Range(minX, maxX);
    	float randomY = Random.Range(minY, maxY);
    	
    	obstacles.Add(Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation));
    }

    public static void RemoveObstacle(GameObject obstacle)
    {
        obstacles.Remove(obstacle);
    }

    public static void DestroyAllObstacles()
    {
        foreach(GameObject obstacle in obstacles) Destroy(obstacle);
    }
    
}
