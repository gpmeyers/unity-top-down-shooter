using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Reference to the Enemy Prefab we would like to spawn. (Can change to an array if I add more enemy types)
    public GameObject enemy;
    public GameObject boss;

    // Reference to player object to determine if enemy spawn is too close
    public PlayerController player;

    // Fields that will contain randomly generated X and Z positions for the enemy to spawn
    private int xPos;
    private int zPos;

    // Field that will contain the current number of enemies
    public int enemyCount;

    // End Game UI
    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
    }

    // Corountine that spawns X enemies at the beginning of the game
    IEnumerator EnemySpawnX()
    {
        while(enemyCount < 22) // Value given in statement is "X"
        {
            // Get a Random position for the enemy to be spawned (x,z) (y is fixed to 1)
            xPos = UnityEngine.Random.Range(-23, 23);
            zPos = UnityEngine.Random.Range(-23, 23);

            // Get the current position of the player and the random position generated for the enemy
            Vector3 playerPos = player.transform.position;
            Vector3 enemySpawnPos = new Vector3(xPos, 1, zPos);

            // If the enemy is not too close to the player, spawn it
            if(Math.Abs(playerPos.x - enemySpawnPos.x) > 4 && Math.Abs(playerPos.z - enemySpawnPos.z) > 4){
                GameObject newEnemy = Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
                EnemyController newController = newEnemy.GetComponent<EnemyController>();
                newController.player = player;
            }

            yield return new WaitForSeconds(0.1f);

            // IF an enemy was spawned, increment the enemy count
            if (Math.Abs(playerPos.x - enemySpawnPos.x) > 4 && Math.Abs(playerPos.z - enemySpawnPos.z) > 4)
            {
                enemyCount += 1;
            }
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(EnemySpawnX());
    }

    // Function that spawns one enemy when an enemy is killed to endlessly spawn enemies
    // GameManager will have this function called upon an enemy death
    public void EnemySpawn()
    {
        // Get a Random position for the enemy to be spawned (x,z) (y is fixed to 1)
        xPos = UnityEngine.Random.Range(-23, 23);
        zPos = UnityEngine.Random.Range(-23, 23);

        // Get the current position of the player and the random position generated for the enemy
        Vector3 playerPos = player.transform.position;
        Vector3 enemySpawnPos = new Vector3(xPos, 1, zPos);

        // If the enemy is not too close to the player, spawn it
        if (Math.Abs(playerPos.x - enemySpawnPos.x) > 4 && Math.Abs(playerPos.z - enemySpawnPos.z) > 4)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            EnemyController newController = newEnemy.GetComponent<EnemyController>();
            newController.player = player;
        }
        else
        {
            EnemySpawn();
        }
    }

    // Function will despawn the enemies when the player goes into the home area
    public void DespawnEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        enemyCount = 0;
    }

    // Function will spawn the boss once the player walks into the final arena
    public void BossEnemySpawn()
    {
        GameObject newBoss = Instantiate(boss, new Vector3(0, 4, 85), Quaternion.identity);
        newBoss.GetComponent<BossController>().player = player;
        newBoss.GetComponent<BossController>().manager = this;
        newBoss.GetComponent<BossHealthManager>().endGameUI = endGameUI;
        newBoss.GetComponent<BossHealthManager>().manager = this;
    }
}
