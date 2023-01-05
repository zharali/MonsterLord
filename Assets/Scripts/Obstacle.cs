using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float verticalSpeed;
	public float horizontalSpeed;
	private Rigidbody2D rb;
	private Vector2 obstacleDirection;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	float directionX = 0;
    	float directionY = 1;
        obstacleDirection = new Vector2(directionX, directionY).normalized;
    }
    
    void FixedUpdate()
    {
    	rb.velocity = new Vector2(obstacleDirection.x * horizontalSpeed, obstacleDirection.y * verticalSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.tag == "Border")
    	{
            Destroy(this.gameObject);
    	}
    }

    private void OnDestroy()
    {
        SpawnObstacles.RemoveObstacle(this.gameObject);
    }
}
