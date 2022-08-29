using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUISlot : MonoBehaviour
{
    public Image    icon;
    public Text     icon_Name;
    public Text     lvText;
    public Text     desc;


    public void SetWeaponUISlot(Weapon weapon)
    {
        icon.sprite = weapon._sprite;
        icon_Name.text = weapon._name;
        lvText.text = "Lv."+ weapon.LV;
        desc.text = weapon._desc;
    }


    public void SetSubWeaponUISlot(Weapon weapon)
    {
        icon.sprite = weapon._sprite;
        icon_Name.text = weapon._name;
        lvText.text = "Lv." + weapon.LV;
        desc.text = weapon._desc;
    }

}
