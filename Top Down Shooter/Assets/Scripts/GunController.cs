using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    // Boolean to record if the gun is firing
    public bool isFiring;

    // Fields that fold data regarding the bullet
    public BulletController bullet;
    public float bulletSpeed;

    // Fields that hold data regarding the type of gun (fire rate)
    public float fireRate; // Fire Rate here is measured in time between shots so lower = more bullets per second
    private float shotCounter;

    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (isFiring) // If the player is firing
        {
            shotCounter -= Time.deltaTime; // Determine how much time is left before another shot is fired

            if(shotCounter <= 0) // If a shot should be fired
            {
                shotCounter = fireRate; // Reset timer for next shot

                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController; // Create a bullet object in front of the gun
                newBullet.speed = bulletSpeed; // Set the speed of the bullet
            }
        }
        else
        {
            shotCounter = 0; // Reset shot timer
        }
    }
}
