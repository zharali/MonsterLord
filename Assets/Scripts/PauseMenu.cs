using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;
	public MusicManager musicManager;
	
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
