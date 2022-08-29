using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void Update()
    {
        text.text = GameSystem.Instance.Coin.ToString();
    }
}
