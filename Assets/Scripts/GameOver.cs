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
    
    public void Restart()
    {
    	Time.timeScale = 1f;
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Home(int sceneID)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneID);
	}
}
