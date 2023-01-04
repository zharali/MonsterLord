using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public GameObject gameOver;
	public MusicManager musicManager;

    // Now player does this. calls ShowGameOver
    /*void Update()
    {
        if(Player.instance.currentHealth <= 0)
        {
        	gameOver.SetActive(true);
        	Time.timeScale = 0f;
        	musicManager.PauseBGM();
        	musicManager.PlayGameOver();
        }
    }*/
    
    public void ShowGameOver()
    {
    	gameOver.SetActive(true);
        Time.timeScale = 0f;
        musicManager.PauseBGM();
        musicManager.PlayGameOver();   
    }
    
    public void Restart(int sceneID)
    {
    	gameOver.SetActive(false);
    	Time.timeScale = 1f;
    	SceneManager.LoadScene(sceneID);
    }
    
    public void Home(int sceneID)
	{
		gameOver.SetActive(false);
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneID);
	}
}
