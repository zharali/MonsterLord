using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class which will be taken by all the bosses
public class Boss : MonoBehaviour
{
    public float timer; // In seconds
    public ulong level;
    public long currentHealth;

    // Boss should have a health bar and a timer bar
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15; // seconds
        level = Player.instance.bossBeaten + 1;
        currentHealth = StatFunctions.BossHealth(level);
        // healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Time management
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            // TODO : decreate the timer bar
        } else  // end of the timer, we kill the character
        {
            Player.instance.TakeDamage(Player.instance.currentHealth);
        }
    }

    public void TakeDamage(long damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        
        // If the boss has been defeated
        if (currentHealth < 0)
        {
            // We can award a certain amount of score

            Player.instance.score += 25;

            Player.instance.bossBeaten++;
            // Then self destruction
            //Destroy(this.gameObject);
        }
    }
}
