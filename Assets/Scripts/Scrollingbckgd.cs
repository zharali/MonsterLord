﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrollingbckgd : MonoBehaviour
{

    private float bgSpeed;
    public float baseSpeed;
    public Renderer bgRend;
    public Texture[] bgs;
    public uint currentBg;

    // Start is called before the first frame update
    void Start()
    {
        SetBg(0);
        currentBg = 0;
        bgSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
    }
    
    public void SetBg(uint index)
	{
    	//Texture tex = Resources.Load(textureName, typeof(Texture)) as Texture;
    	Renderer renderer = GetComponent<Renderer>();
    	renderer.material.SetTexture("_MainTex", this.bgs[index % (uint) bgs.Length]);
    	currentBg = index % (uint) bgs.Length;
	}
	
	public void NextBg()
	{
		Renderer renderer = GetComponent<Renderer>();
    	renderer.material.SetTexture("_MainTex", this.bgs[(currentBg + 1) % (uint) bgs.Length]);
    	currentBg += 1;
	}
	
	public void SetSpeed(float s)
	{
		bgSpeed = s;
	}
	
	public void SpeedUp(uint currentLevel)
	{
		bgSpeed = bgSpeed + (float) 0.3;
	}

}
