using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Global parameter variable
    public static uint ScoreFrequencyForBoss = 100;


	public float playerSpeed;
	public int maxHealth = 100;
	public long currentHealth;
    public ulong atk;
    public ulong score;
    public uint gameLevel;
    public uint bossBeaten;
    public GameObject gameOverPanel;
    public HealthBar healthBar;
	private Rigidbody2D rb;
	private Vector2 playerDirection;

    #region Singleton
    public static Player instance; 
    // Start is called before the first frame update
    void Start()
    {
        // Singleton shenanigans
        if (instance == null) instance = this;
        else Destroy(this.gameObject);


        currentHealth = StatFunctions.Health(GlobalData.instance.data.characterLevel); // Follows the HP(lvl) equation
        healthBar.SetMaxHealth(currentHealth);
        atk = StatFunctions.Attack(currentHealth);  // HP(lvl) / number of hits to beat a boss
        score = 0;
        gameLevel = 1;
        bossBeaten = 0;
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
    	// Not moving vertically, only horizontally (could change in the future?).
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
    }
    
    void FixedUpdate()
    {
    	rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.tag == "Obstacle")
    	{
    		TakeDamage(gameLevel * 10); // Will need to be fine-tuned	
    	}
    }

    public void TakeDamage(long damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);  // Might need to be changed if we don't want to have a negative health bar

        // Death condition - End game
        if (currentHealth <= 0)
        {
        	// Display GAME OVER panel: GameOver class does this.
        	
            // Transform the score into xp for our character
            ulong currentXp = GlobalData.instance.data.levelxp;
            uint currentLevel = GlobalData.instance.data.characterLevel;

            ulong totalXpEarned = score / 10;  // To be changed or fine-tuned

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
