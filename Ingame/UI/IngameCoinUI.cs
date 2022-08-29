using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameCoinUI : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void Update()
    {
        text.text = PlayerData.Instance.totalCoin.ToString();
    }
}
