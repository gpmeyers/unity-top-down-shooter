using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopUp : MonoBehaviour
{
    // References to Game Objects to be used in script
    public Transform player;

    public GameObject shopPopUpUI;

    // Static Field that represents if the player is in range of the shop
    public static bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if(!isActive && player.position.x <= 21 && player.position.x >= 14 && player.position.z <= -30 && player.position.z >= -38)
        {
            shopPopUpUI.SetActive(true);
            isActive = true;
        }
        if (isActive && player.position.x >= 21 || player.position.x <= 14 || player.position.z >= -30 || player.position.z <= -38)
        {
            shopPopUpUI.SetActive(false);
            isActive = false;
        }
    }
}
