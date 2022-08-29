using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text LevelText;


    void Start()
    {


    }

    void Update()
    {
        LevelText.text = "Lv" + PlayerData.Instance.PlayerLV.ToString();

        float exp = PlayerData.Instance.Coin; //coin == exp
        float NeedExp = (float)PlayerData.Instance.RequiredEXP;
        slider.value = exp / NeedExp;
    }


}
