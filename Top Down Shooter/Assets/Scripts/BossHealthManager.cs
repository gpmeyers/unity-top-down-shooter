using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    // Fields for enemy max health and current health
    public int health;
    public int currentHealth;

    // Reference to Game Manager
    public EnemySpawner manager;

    // End Game UI
    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
     
        manager = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Death Mechanic
        if (currentHealth <= 0)
        {
            manager.DespawnEnemies();

            endGameUI.SetActive(true);

            Time.timeScale = 0f;

            Destroy(gameObject);
        }
    }

    // Function allows the player to damage enemies
    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
