using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public PowerUpButton powerUpButton;


    public void OnClickBuyButton()
    {
        int cost = (int)(GameSystem.Instance.LvUpCount * 0.1 * powerUpButton.Cost * powerUpButton.Level + (powerUpButton.Cost * powerUpButton.Level));
        
        if(cost <= GameSystem.Instance.Coin)
        {
            powerUpButton.Level++;
            GameSystem.Instance.LvUpCount++;
            GameSystem.Instance.SetPlayerPowerLevel(powerUpButton.power, powerUpButton.Level-1);

            GameSystem.Instance.Coin -= cost;
            GameSystem.Instance.Cost += cost;

            powerUpButton.UpdateCheckers();
            powerUpButton.UpdateDetailPanel();
        }
    }

    void Start()
    {
        powerUpButton.UpdateDetailPanel();
    }

}
