using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HZ : Weapon
{

    void Init()
    {
        isWeapon = false;
        Level = 0;
        MaxLevel = 5;
        damage = 0.5f;

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
                    PlayerData.Instance.UpdatePlayerData(Powers.Recovery, damage);
                    break;
                case 2:
                    PlayerData.Instance.UpdatePlayerData(Powers.Recovery, damage);
                    break;
                case 3:
                    PlayerData.Instance.UpdatePlayerData(Powers.Recovery, damage);
                    break;
                case 4:
                    PlayerData.Instance.UpdatePlayerData(Powers.Recovery, damage);
                    break;
                case 5:
                    PlayerData.Instance.UpdatePlayerData(Powers.Recovery, damage);
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
                    _levelDesc = "회복력 0.5증가";
                    break;
                case 2:
                    _levelDesc = "회복력 0.5증가";
                    break;
                case 3:
                    _levelDesc = "회복력 0.5증가";
                    break;
                case 4:
                    _levelDesc = "회복력 0.5증가";
                    break;
            }

        }
    }
}
