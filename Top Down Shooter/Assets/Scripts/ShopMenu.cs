using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public PlayerController player;
    public GameObject shopPopUpUI;
    public GameObject shopMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(ShopPopUp.isActive && Input.GetKeyDown(KeyCode.LeftShift))
        {
            OpenShopMenu();
        }
    }

    // Function Opens the Shop Menu UI and Disables the Shop Pop-Up
    public void OpenShopMenu()
    {
        shopPopUpUI.SetActive(false);
        Time.timeScale = 0f;
        shopMenuUI.SetActive(true);
    }

    // Function Closes the Shop Menu UI and ReEnables the Shop Pop-Up
    public void CloseShopMenu()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        shopPopUpUI.SetActive(true);
    }

    // Function to Purchase Ability: Fire Rate Level 1
    public void BuyFireRate1()
    {
        if (player.playerCash >= 2000 && player.fireRateLevel < 1)
        {
            player.playerCash -= 2000;
            player.fireRateLevel = 1;
        }

        FindObjectOfType<GunController>().fireRate = 0.15f;
    }

    // Function to Purchase Ability: Fire Rate Level 2
    public void BuyFireRate2()
    {
        if (player.playerCash >= 5000 && player.fireRateLevel < 2)
        {
            player.playerCash -= 5000;
            player.fireRateLevel = 2;
        }

        FindObjectOfType<GunController>().fireRate = 0.1f;
    }

    // Function to Purchase Ability: Fire Rate Level 3
    public void BuyFireRate3()
    {
        if (player.playerCash >= 10000 && player.fireRateLevel < 3)
        {
            player.playerCash -= 10000;
            player.fireRateLevel = 3;
        }

        FindObjectOfType<GunController>().fireRate = 0.05f;
    }

    // Function to Purchase Ability: Damage Level 1
    public void BuyDamage1()
    {
        if (player.playerCash >= 2000 && player.damageLevel < 1)
        {
            player.playerCash -= 2000;
            player.damageLevel = 1;
        }

        FindObjectOfType<GunController>().bulletDamage = 30;
    }

    // Function to Purchase Ability: Damage Level 2
    public void BuyDamage2()
    {
        if (player.playerCash >= 5000 && player.damageLevel < 2)
        {
            player.playerCash -= 5000;
            player.damageLevel = 2;
        }

        FindObjectOfType<GunController>().bulletDamage = 40;
    }

    // Function to Purchase Ability: Damage Level 3
    public void BuyDamage3()
    {
        if (player.playerCash >= 10000 && player.damageLevel < 3)
        {
            player.playerCash -= 10000;
            player.damageLevel = 3;
        }

        FindObjectOfType<GunController>().bulletDamage = 50;
    }

    // Function to Purchase Ability: Health Level 1
    public void BuyHealth1()
    {
        if (player.playerCash >= 2000 && player.healthLevel < 1)
        {
            player.playerCash -= 2000;
            player.healthLevel = 1;
        }

        FindObjectOfType<PlayerHealthManager>().health = 100;
        FindObjectOfType<PlayerHealthManager>().currentHealth = 100;
        FindObjectOfType<HealthBar>().SetMaxHealth(100);
        FindObjectOfType<HealthBar>().SetHealth(100);
    }

    // Function to Purchase Ability: Health Level 2
    public void BuyHealth2()
    {
        if (player.playerCash >= 5000 && player.healthLevel < 2)
        {
            player.playerCash -= 5000;
            player.healthLevel = 2;
        }

        FindObjectOfType<PlayerHealthManager>().health = 150;
        FindObjectOfType<PlayerHealthManager>().currentHealth = 150;
        FindObjectOfType<HealthBar>().SetMaxHealth(150);
        FindObjectOfType<HealthBar>().SetHealth(150);
    }

    // Function to Purchase Ability: Health Level 3
    public void BuyHealth3()
    {
        if (player.playerCash >= 10000 && player.healthLevel < 3)
        {
            player.playerCash -= 10000;
            player.healthLevel = 3;
        }

        FindObjectOfType<PlayerHealthManager>().health = 200;
        FindObjectOfType<PlayerHealthManager>().currentHealth = 200;
        FindObjectOfType<HealthBar>().SetMaxHealth(200);
        FindObjectOfType<HealthBar>().SetHealth(200);
    }
}
