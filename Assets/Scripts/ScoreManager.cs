using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
	public Text scoreText;
	private float score;
	private float xp;
	public float scoreMultiplier;
	public Text finalScoreText;
	public Text xpText;

    // Update is called once per frame
    void Update()
    {
    	if(GameObject.FindGameObjectWithTag("Player") != null)
    	{
    		score += scoreMultiplier * Time.deltaTime;
    		scoreText.text = ((int)score).ToString();    	
    		finalScoreText.text = "Score: " + ((int)score).ToString();   
    		xp = score / 10;
    		xpText.text = "XP: " + ((int)xp).ToString();   
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
}
