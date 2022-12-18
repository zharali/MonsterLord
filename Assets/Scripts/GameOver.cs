using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.currentHealth <= 0)
        {
        	gameOver.SetActive(true);
        	Time.timeScale = 0f;
        }
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
