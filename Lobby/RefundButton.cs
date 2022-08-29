using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundButton : MonoBehaviour
{
    [SerializeField]
    private List<PowerUpButton> buttons = new List<PowerUpButton>();

    public void OnclickRefundBtn()
    {
        foreach(var button in buttons)
        {
            button.Level = 1;
            button.ResetCheckers();
        }

        GameSystem.Instance.Coin += GameSystem.Instance.Cost;
        GameSystem.Instance.Cost = 0;
        GameSystem.Instance.ResetPowerData();
    }


}
