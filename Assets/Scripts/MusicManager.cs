using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

	private AudioSource[] audioSources;
	private AudioSource menuBGM;
	private AudioSource gameOverMusic;
	private AudioSource damageSFX;
	private AudioSource bossMusic;
	public uint currentBGM;
	
    // Start is called before the first frame update
    void Start()
    {
		//gets audioSources from scene. to add more we just add them to the Music object in the scene
		audioSources = UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
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
