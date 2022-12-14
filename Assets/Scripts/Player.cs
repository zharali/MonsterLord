using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
#if UNITY_STANDALONE
using UnityEngine.Windows.Speech;
#endif
public class Player : MonoBehaviour
{

	public float playerSpeed;
	//public int maxHealth; //could be used for healing items/events.
	public long currentHealth;
    public ulong atk;
    public ScoreManager scoreManager;
    //public ulong score; //retrieved from ScoreManager
    public uint bossBeaten; //
    public GameObject gameOverPanel;
    public HealthBar healthBar;
	private Rigidbody2D rb;
	private Vector2 playerDirection;
	public int sampleWindow = 64;
	//public AudioSource audioSource;
	public GameOver gameOver;
	public MusicManager musicManager;
	private AudioClip microphoneClip;
	private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    public GameObject character; 


#if UNITY_STANDALONE
	private KeywordRecognizer keywordRecognizer;
#endif

    #region Singleton
    public static Player instance; 
    // Start is called before the first frame update
    void Start()
    {
        //resume time. gameover was messing this up.
        Time.timeScale = 1f;
        // Singleton shenanigans
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

        //Vector3 startingPosition = new Vector3(608.06, -648, 44.125); // or any other desired position
        //character = Instantiate(GlobalData.instance.data.characterStyle, Quaternion.identity);

        currentHealth = StatFunctions.Health(GlobalData.instance.data.characterLevel); // Follows the HP(lvl) equation
        healthBar.SetMaxHealth(currentHealth);
        atk = StatFunctions.Attack(currentHealth);  // HP(lvl) / number of hits to beat a boss
        //score = 0; //handled in ScoreManager
        //gameLevel = 1; //handled in LevelManager
        bossBeaten = 0;
        rb = GetComponent<Rigidbody2D>();
#if UNITY_STANDALONE
        //for voice recognition
        MicrophoneToAudioClip(); //start the microphone
        keywordActions.Add("left", MoveLeft); //add words and methods to dictionary
        keywordActions.Add("right", MoveRight);
        
        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();        
        
        foreach (var device in Microphone.devices)
    	{
        	Debug.Log("Name: " + device);
    	}
    	/*
    	var audio = GetComponent< AudioSource > ();
		audio.clip = Microphone.Start("Default Input Device", true, 10, 44100);
		audio.loop = true;
		while (!(Microphone.GetPosition(null) > 0)) { }
		audio.Play();
		*/
#endif
    }
#endregion
    
    // Update is called once per frame
    void Update()
    {
        // Different controls modes : if the boss is there or not (and not paused)
        if (SpawnBoss.HasBossSpawned && Time.timeScale != 0f)
        { // Tap or click to deal damage
#if UNITY_ANDROID
            if (Input.GetTouch(0).tapCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SpawnBoss.GetBossInstance().TakeDamage((long) atk);
            }
#elif UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBoss.GetBossInstance().TakeDamage((long)atk);
            }
#endif
        } else
        {
            // Not moving vertically, only horizontally (could change in the future?).
            float directionX = Input.GetAxisRaw("Horizontal");
            playerDirection = new Vector2(directionX, 0).normalized;
        }
    }
#if UNITY_STANDALONE
    public void MicrophoneToAudioClip()
    {
    	string microphoneName = Microphone.devices[0];
    	microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }
    
    public float GetLoudnessFromMicrophone()
    {
    	return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
    
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
    	int startPosition = clipPosition - sampleWindow;
    	if (startPosition < 0) return 0; //for the start of the clip error.
    	float[] waveData = new float[sampleWindow];
    	clip.GetData(waveData, startPosition);
    	
    	//compute loudness
    	float totalLoudness = 0;
    	for (int i = 0; i < sampleWindow; i++)
    	{
    		totalLoudness += Mathf.Abs(waveData[i]);
    	}
    	return totalLoudness / sampleWindow;
    }
    
    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
    	Debug.Log("Keyword: " + args.text);
    	keywordActions[args.text].Invoke();
    }
    
    void MoveLeft()
    {
    	float loudness = GetLoudnessFromMicrophone();
    	//Debug.Log(loudness);
        playerDirection = new Vector2(-1, 0).normalized * loudness;
    	
    }
    
    void MoveRight()
    {
    	float loudness = GetLoudnessFromMicrophone();
    	//Debug.Log(loudness);
        playerDirection = new Vector2(1, 0).normalized * loudness;
    
    }
#endif
    void FixedUpdate()
    {
    	rb.velocity = new Vector2(playerDirection.x * playerSpeed , 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.tag == "Obstacle")
    	{
    		TakeDamage(scoreManager.GetCurrentLevel() * 10); // Will need to be fine-tuned	
    	}
    }

    public void AddScore(ulong score)
    {
        scoreManager.UpScore(score);
    }

    public void TakeDamage(long damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);  // Might need to be changed if we don't want to have a negative health bar
        musicManager.PlayDamageTaken();

        // Death condition - End game
        if (currentHealth <= 0)
        {
            // Display GAME OVER panel: GameOver class does this.
            gameOver.ShowGameOver();
            // Transform the score into xp for our character
            ulong currentXp = GlobalData.instance.data.levelxp;
            uint currentLevel = GlobalData.instance.data.characterLevel;

			//i think its easier to have score and XP in the ScoreManager script and access it.
			//(i was already using that script for showing scores in the UI).
			ulong score = Convert.ToUInt64(scoreManager.GetScore());
            ulong totalXpEarned = Convert.ToUInt64(scoreManager.GetXp());  // To be changed or fine-tuned

            ulong levelUpRequirement = StatFunctions.XpToLevelUp(currentLevel);

            while (currentXp + totalXpEarned > levelUpRequirement)  // While we level up
            {
                totalXpEarned -= levelUpRequirement - currentXp;  // XP diff
                levelUpRequirement = StatFunctions.XpToLevelUp(++currentLevel);
                currentXp = 0;
            }
            // Saving final data to the global instance
            GlobalData.instance.data.levelxp = totalXpEarned;
            GlobalData.instance.data.characterLevel = currentLevel;

            // Saving score if it beats the highscore
            if (score > GlobalData.instance.data.highscore) GlobalData.instance.data.highscore = score;
        }
    }


}
