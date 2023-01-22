using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnObstacles : MonoBehaviour
{
	public GameObject[] obstacleDesigns;
	private int animation = 1;
	private float obstacleSpeed = -2;
    private static List<GameObject> obstacles = new List<GameObject>();
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	private float timeBetweenSpawn = 3;
	private float spawnTime;


	/*void Start()
	{
		for (int i = 0; i < obstacleDesigns.Length; i++) 
		{
			obstacleDesigns[i].SetVerticalSpeed(-(2 + (float) Math.Log(i, 2)));		
		}
	
	}*/
	
	
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
    	float randomX = UnityEngine.Random.Range(minX, maxX);
    	float randomY = UnityEngine.Random.Range(minY, maxY);
    	GameObject instance = Instantiate(obstacleDesigns[(animation-1)%obstacleDesigns.Length], transform.position + new Vector3(randomX, randomY, 0), transform.rotation) as GameObject;
    	instance.SendMessage("SetVerticalSpeed", obstacleSpeed);
    	//instance.SendMessage("ChangeAnimation", animation);
    	//Debug.Log("obstacle animation: "+ animation.ToString());
    	obstacles.Add(instance);
    }

    public static void RemoveObstacle(GameObject obstacle)
    {
        obstacles.Remove(obstacle);
    }

    public static void DestroyAllObstacles()
    {
        foreach(GameObject obstacle in obstacles) Destroy(obstacle);
    }
    
    public void SetObstacleSpeed(float s)
    {
    	obstacleSpeed = s;
    }
    
    public void SetAnimation(int a)
    {
    	animation = a;
    }
    
    public void SetTimeBetweenSpawns(float t)
    {
    	timeBetweenSpawn = t;
    
    }
    
    public float GetTimeBetweenSpawns()
    {
    	return timeBetweenSpawn;
    }
}

