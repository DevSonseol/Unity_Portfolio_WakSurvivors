using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : Weapon
{
    void Init()
    {
        isWeapon = false;
        Level = 1;
        MaxLevel = 2;
        damage = 1f;

        LevelUp();
        UpdateDesc();
    }

    void Awake()
    {
        Init();
    }


    public override void LevelUp()
    {
        if (Level < MaxLevel)
        {
            Level++;

            switch (Level)
            {
                case 1:
                    PlayerData.Instance.UpdatePlayerData(Powers.Amount, damage);
                    break;
                case 2:
                    PlayerData.Instance.UpdatePlayerData(Powers.Amount, damage);
                    WeaponSystem.Instance.MaxLevelSubWeapons.Add(this);
                    break;

            }

        }
    }

    public override void UpdateDesc()
    {
        if (Level < MaxLevel)
        {

            switch (Level)
            {
                case 1:
                    _levelDesc = "투사체 1증가";
                    break;
            }

        }
    }
}
