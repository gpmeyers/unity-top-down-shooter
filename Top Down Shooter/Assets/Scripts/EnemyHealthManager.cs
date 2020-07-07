using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    // Fields for enemy max health and current health
    public int health;
    private int currentHealth;

    // Reference to Game Manager
    private EnemySpawner manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<EnemySpawner>();

        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        // Death Mechanic
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            manager.EnemySpawn();
        }
    }

    // Function allows the player to damage enemies
    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
