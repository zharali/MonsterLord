using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
	public Text scoreText;
	public Text finalScoreText;
	public Text xpText;
	public Text currentLevelText;
	
	private float score;
	private float xp;
	public float scoreMultiplier;
	private uint currentLevel = 1;
	private uint upLevelScore = 300;
	private float gameSpeed = 1f;
	public MusicManager musicManager;
	
	void Start()
	{
		currentLevel = 1;
		gameSpeed = 1f;
	}
	
	
    // Update is called once per frame
    void Update()
    {
    	if(GameObject.FindGameObjectWithTag("Player") != null)
    	{
    		//maybe some things here could be moved so that they are only calculated upon dying.
    		score += scoreMultiplier * Time.deltaTime;
    		scoreText.text = "Score: " + ((int)score).ToString();    	
    		finalScoreText.text = "Score: " + ((int)score).ToString();   
    		xp = score / 10;
    		xpText.text = "XP: " + ((int)xp).ToString();   
    	}
    	
    	if(score > (currentLevel * upLevelScore)) 
    	{
    		UpLevel();
    	}
    }
    
    public float GetScore()
    {
    	return score;
    }
    
    public float GetXp()
    {
    	return xp;
    }
    
    public void UpScore(float up)
    {
    	score += up;
    }
    
    public float GetGameSpeed()
    {
    	return gameSpeed;
    }
    
    public uint GetCurrentLevel()
    {
    	return currentLevel;
    }
    
    private void UpLevel()
    {
    	//maybe here call boss or something (?)
    	currentLevel += 1;
    	currentLevelText.text = "Lv: " + currentLevel.ToString();
    	//this function seems alright for the speed progression.
    	gameSpeed = 1 + (float) Math.Log(currentLevel, 2);
    	//change background music
    	musicManager.PlayNextBGM();
    	
    	//Time.timeScale = gameSpeed; 
    	//better not to touch timeScale, i think it would mess up too many things XD
    }
}
