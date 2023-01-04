using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

	public AudioSource[] audioSources;
	public AudioSource menuBGM;
	public AudioSource gameOverMusic;
	public AudioSource damageSFX;
	public AudioSource bossMusic;
	public uint currentBGM;
	
    // Start is called before the first frame update
    void Start()
    {
		//gets audioSources from scene. to add more we just add them to the Music object in the scene
		//i changed it so we set them from GUI. easier this way :)
		//audioSources = UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		audioSources[0].Play();
		currentBGM = 0;
    }
    
    public void PlayNextBGM()
    {
    	audioSources[currentBGM].Stop();
    	currentBGM = (currentBGM + 1) % (uint)audioSources.Length; //ensure index is never out of range.
    	audioSources[currentBGM].Play();    
    }
    
    public void PlayBGM(uint index)
    {
    	audioSources[currentBGM].Stop();
    	currentBGM = index % (uint)audioSources.Length; //ensure index is never out of range.
    	audioSources[currentBGM].Play();
    
    }
    
    public void PauseBGM()
    {
       	audioSources[currentBGM].Pause();
    }
    
    public void ResumeBGM()
    {
    	audioSources[currentBGM].Play();
    }
    
    public void PlayMenuBGM()
    {
    	
    
    }
    
    public void PlayGameOver()
    {
    	gameOverMusic.Play();
    }
    
    public void PlayDamageTaken()
    {
    	damageSFX.Play();
    }
    
    public void PlayBossMusic()
    {
    
    }
}
