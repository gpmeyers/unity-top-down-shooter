using Boo.Lang.Runtime.DynamicDispatching;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Reference to the Enemy Prefab we would like to spawn. (Can change to an array if I add more enemy types)
    public GameObject enemy;

    // Reference to player object to determine if enemy spawn is too close
    public PlayerController player;

    // Fields that will contain randomly generated X and Z positions for the enemy to spawn
    private int xPos;
    private int zPos;

    // Field that will contain the current number of enemies
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;

        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < 10)
        {
            // Get a Random position for the enemy to be spawned (x,z) (y is fixed to 1)
            xPos = UnityEngine.Random.Range(1, 23);
            zPos = UnityEngine.Random.Range(1, 23);

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
}
