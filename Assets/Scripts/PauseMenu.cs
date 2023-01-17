using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;
	public MusicManager musicManager;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 0) // If it's already paused
            {
				Debug.Log("To the menu scene");
				Home(0); // To the menu scene
            } else
            {
				Debug.Log("Escape -> pausing the game");
				Pause();
            }
        }
    }
	
	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		musicManager.PauseBGM();
	}
	
	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		musicManager.ResumeBGM();
	}
	
	public void Home(int sceneID)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(sceneID);
	
	}

}
