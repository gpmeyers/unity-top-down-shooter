using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    // Fields for the player's health
    public int health;
    public int currentHealth;

    // Fields for the length that the player will flash when receiving damage
    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    // Reference to Health Bar for UI support
    public HealthBar healthBar;

    // Reference for Death Screen UI for player death
    public GameObject deathScreenUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);

        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        // Logic to kill the player
        if(currentHealth <= 0)
        {
            deathScreenUI.SetActive(true);

            gameObject.SetActive(false);
        }

        // Logic to have the player flash when hit for a short amount of time
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;

            if(flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    // Function is called whenever the player collides with something that will cause damage
    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Logic to have the player flash white when damaged
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
