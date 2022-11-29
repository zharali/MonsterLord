﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float playerSpeed;
	private Rigidbody2D rb;
	private Vector2 playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	// Not moving vertically, only horizontally (could change in the future?).
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
    }
    
    void FixedUpdate()
    {
    	rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);
    }
}
