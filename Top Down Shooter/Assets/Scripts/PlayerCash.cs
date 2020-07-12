using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCash : MonoBehaviour
{
    // References to GameObjects that will be used to maintain the player's cash
    public PlayerController player;

    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + player.playerCash.ToString();
    }

    // Function that is called whenever an Enemy is destroyed and will add cash to the player, and represent that value on the screen
    public void AddCash()
    {
        player.playerCash += 100;
    }
}
