using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Field containing Player Movement Speed 
    public float movementSpeed;

    // Field containing a reference to the player Rigidbody
    private Rigidbody myRigidbody;

    // Input Data for player movement
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Reference to camera for player look controls
    private Camera mainCamera;

    public GunController gun;

    // Field Maintaining Player Position
    private bool isHome = true;

    // Field Maintaining the Player's Cash
    public int playerCash = 0;

    // Fields Maintaining the Player's Ability Levels
    public int fireRateLevel = 0;
    public int damageLevel = 0;
    public int healthLevel = 0;

    // Reference to wall for final encounter
    public GameObject wall;

    // Check to see if boss is spawned
    private Boolean bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // For player movement controls
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movementSpeed;

        // For player look controls
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // For player combat controls
        if (Input.GetMouseButtonDown(0))
        {
            if(Time.timeScale != 0)
            {
                gun.isFiring = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }

        // For TransLoc
        if(Input.GetMouseButtonDown(1) && !gun.transLocFired)
        {
            gun.transLocFired = true;
            gun.FireTranslocator();
        }

        // Determining Player Position
        if(!isHome && transform.position.z <= -25)
        {
            FindObjectOfType<EnemySpawner>().DespawnEnemies();
            isHome = true;
        }
        if (isHome && transform.position.z >= -25)
        {
            FindObjectOfType<EnemySpawner>().StartSpawn();
            isHome = false;
        }
        if (!isHome && transform.position.z >= 25.5)
        {
            FindObjectOfType<EnemySpawner>().DespawnEnemies();
            isHome = true;
        }
        if (isHome && transform.position.z <= -25.5)
        {
            FindObjectOfType<EnemySpawner>().StartSpawn();
            isHome = false;
        }
        if(transform.position.z >= 61 && !bossSpawned)
        {
            FindObjectOfType<EnemySpawner>().BossEnemySpawn();
            wall.SetActive(true);
            bossSpawned = true;
        }
    }

    // FixedUpdate is used for physics
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
