using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class which will be taken by all the bosses
public class Boss : MonoBehaviour
{
    public float timer; // In seconds
    public ulong level;
    public long currentHealth;
    public ulong bossDefeatedScore = 10;  // Also modify Boss prefab

    public HealthBar bossBar;
    public TimerBar timerBar; // Not really a health bar but has the same properties

    // Start is called before the first frame update
    void Start()
    {
        timer = 15; // seconds
        level = Player.instance.bossBeaten + 1;
        currentHealth = StatFunctions.BossHealth(level);
        bossBar = Instantiate(bossBar, GameObject.Find("UI").transform);
        bossBar.SetMaxHealth(currentHealth);
        timerBar = Instantiate(timerBar, GameObject.Find("UI").transform);
        timerBar.SetMaxTime((int)timer);
    }

    // Update is called once per frame
    void Update()
    {
        // Time management
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerBar.SetTime((int)timer);
            // TODO : decreate the timer bar
        } else  // end of the timer, we kill the character
        {
            Player.instance.TakeDamage(Player.instance.currentHealth);
        }
    }

    public void TakeDamage(long damage)
    {
        currentHealth -= damage;
        bossBar.SetHealth(currentHealth);
        // If the boss has been defeated
        if (currentHealth <= 0)
        {
            // We can award a certain amount of score

            //Player.instance.score += 25;
            Player.instance.AddScore(bossDefeatedScore);

            Player.instance.bossBeaten++;
            // Then self destruction
            Destroy(bossBar.gameObject);
            Destroy(timerBar.gameObject);
            SpawnBoss.DestroyBoss();
        }
    }
}
