using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDS : Weapon
{
    void Init()
    {
        isWeapon = false;
 
        damage = 25f;

        LevelUp();
        UpdateDesc();
    }

    void Awake()
    {
        Init();
        Destroy(this.gameObject);
    }


    public override void LevelUp()
    {
       var player = GameObject.Find("Player");
        player.GetComponent<Player>().Get_Damage(-25f);

    }

    public override void UpdateDesc()
    {
        _desc = "최력 25회복";
    }

}
