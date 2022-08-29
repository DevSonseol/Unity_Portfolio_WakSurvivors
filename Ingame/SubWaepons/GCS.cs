using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCS : Weapon
{

    void Init()
    {
        isWeapon = false;
        Level = 0;
        MaxLevel = 5;
        damage = 0.2f;

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
                    PlayerData.Instance.UpdatePlayerData(Powers.MaxHealth, damage);
                    break;
                case 2:
                    PlayerData.Instance.UpdatePlayerData(Powers.MaxHealth, damage);
                    break;
                case 3:
                    PlayerData.Instance.UpdatePlayerData(Powers.MaxHealth, damage);
                    break;
                case 4:
                    PlayerData.Instance.UpdatePlayerData(Powers.MaxHealth, damage);
                    break;
                case 5:
                    PlayerData.Instance.UpdatePlayerData(Powers.MaxHealth, damage);
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
                    _levelDesc = "�ִ�ü�� 20% ����";
                    break;
                case 2:
                    _levelDesc = "�ִ�ü�� 20% ����";
                    break;
                case 3:
                    _levelDesc = "�ִ�ü�� 20% ����";
                    break;
                case 4:
                    _levelDesc = "�ִ�ü�� 20% ����";
                    break;
            }

        }
    }
}