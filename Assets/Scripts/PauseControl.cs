using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{

	public static bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        	gameIsPaused = !gameIsPaused; //just toggle the pause boolean.
        	PauseGame();        
        }
    }
    
    void PauseGame()
    {
    	if(gameIsPaused)
    	{
    		Time.timeScale = 0f; 	
    	}
    	else
    	{
    		Time.timeScale = 1;
    	}
    }
}
