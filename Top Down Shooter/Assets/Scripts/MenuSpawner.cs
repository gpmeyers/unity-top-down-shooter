using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    // References to the prefabs to spawn
    public GameObject enemy;
    public GameObject player;

    // Fields maintining the time between menu animations
    public float waitTime;
    private float timer;

    // Fields holding data for z position
    private float zPos;
    private int zLoc;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1.0f;
        zPos = 4.0f;
        zLoc = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = waitTime;

            GameObject newPlayer = Instantiate(player, new Vector3(-13, 1, zPos), Quaternion.identity);

            GameObject newEnemy = Instantiate(enemy, new Vector3(-17, 1, zPos), Quaternion.identity);
            newEnemy.transform.LookAt(newPlayer.transform.position);

            if(zLoc == 1)
            {
                zLoc = 2;
                zPos = -4.0f;
            }
            else if(zLoc == 2)
            {
                zLoc = 3;
                zPos = 0.0f;
            }
            else
            {
                zLoc = 1;
                zPos = 4.0f;
            }
        }
    }
}
