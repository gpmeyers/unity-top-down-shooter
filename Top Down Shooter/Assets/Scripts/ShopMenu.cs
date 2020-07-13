using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
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

    public void OpenShopMenu()
    {
        shopPopUpUI.SetActive(false);
        Time.timeScale = 0f;
        shopMenuUI.SetActive(true);
    }

    public void CloseShopMenu()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        shopPopUpUI.SetActive(true);
    }
}
