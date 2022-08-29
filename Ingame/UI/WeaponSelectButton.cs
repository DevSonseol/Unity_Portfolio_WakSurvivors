using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectButton : MonoBehaviour
{

    public Weapon weapon;

    public Text text;

    public Image image;

    public void SettingButton(Weapon _weapon )
    {
        bool isthere = false;
        foreach(Weapon wp in WeaponSystem.Instance.playerWeaponList)
        {
            if (_weapon == wp)
            {
                isthere = true;
                weapon = wp;
                break;
            }
        }

        if(isthere)
        {
            image.sprite = weapon._sprite;
            text.text = weapon._levelDesc;
        }
        else
        {
            weapon = _weapon;
            image.sprite = _weapon._sprite;
            text.text = _weapon._levelDesc;
        }
    }
 
    public void SelectButton()
    {
        WeaponSystem.Instance.Add_Weapon(weapon);
        IngameUIManager.Instance.WeaponSelectUI.Close_WSUI();
    }




}
