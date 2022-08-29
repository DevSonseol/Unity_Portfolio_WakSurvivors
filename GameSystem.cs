using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powers
{
    Might, Armor, MaxHealth, Recovery, CoolDown, Area, Speed, Duration, Amount, MoveSpeed, Magnet, Luck, Growth, Greed
}

[System.Serializable]
public struct PlayerPower//파워 카운트 용도
{
    public int Might; // 랭크당 공격력 5% 증가(최대 랭크 5)
    public int Armor; //랭크당 피격 대미지 1 감소(최대 랭크 3)
    public int MaxHealth; //랭크당 체력 10% 증가(최대 랭크 3)
    public int Recovery; // 랭크당 0.1 증가(최대 랭크 3)
    public int CoolDown; // 랭크당 쿨타임 2.5% 감소(최대 랭크 2)
    public int Area; //  랭크당 범위 5% 증가(최대 랭크 2)
    public int Speed; //랭크당 투사체 속도 10% 증가(최대 랭크 2)
    public int Duration;//  랭크당 지속력 15% 증가(최대 랭크 2)
    public int Amount; // 투사체 개수 +1(최대 랭크 1)
    public int MoveSpeed;// 랭크당 이동속도 5% 증가(최대 랭크 2)
    public int Magnet; // 랭크당 획득반경 25% 증가(최대 랭크 2)
    public int Luck; //랭크당 행운 수치 10% 증가(최대 랭크 3)
    public int Growth;//랭크당 경험치 획득 3% 증가(최대 랭크 5)
    public int Greed; //랭크당 골드 획득 5% 증가(최대 랭크 5)
}

[System.Serializable]
public struct PlayerStat//기본 스탯 + 파워에 따른 플레어 스탯
{
    public float Might; // 랭크당 공격력 5% 증가(최대 랭크 5)
    public float Armor; //랭크당 피격 대미지 1 감소(최대 랭크 3)
    public float MaxHealth; //랭크당 체력 10% 증가(최대 랭크 3)
    public float Recovery; // 랭크당 피격 대미지 1 감소(최대 랭크 3)
    public float CoolDown; // 랭크당 쿨타임 2.5% 감소(최대 랭크 2)
    public float Area; //  랭크당 범위 5% 증가(최대 랭크 2)
    public float Speed; //랭크당 투사체 속도 10% 증가(최대 랭크 2)
    public float Duration;//  랭크당 지속력 15% 증가(최대 랭크 2)
    public float Amount; // 투사체 개수 +1(최대 랭크 1)
    public float MoveSpeed;// 랭크당 이동속도 5% 증가(최대 랭크 2)
    public float Magnet; // 랭크당 획득반경 25% 증가(최대 랭크 2)
    public float Luck; //랭크당 행운 수치 10% 증가(최대 랭크 3)
    public float Growth;//랭크당 경험치 획득 3% 증가(최대 랭크 5)
    public float Greed; //랭크당 골드 획득 5% 증가(최대 랭크 5)
}

public class GameSystem : MonoBehaviour
{
    private static GameSystem instance;
    public static GameSystem Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameSystem>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("GameSystem");
                    instance = instanceContainer.AddComponent<GameSystem>();
                }
            }

            return instance; 
        }

    }

    public  bool CanActiveGO = true;

    public PlayerCharacter character = PlayerCharacter.Wak;

    [SerializeField]
    private PlayerPower playerPowerData;

    [SerializeField]
    private PlayerStat playerStatData;

    public PlayerStat PlayerStatData
    {
        get { return playerStatData; }
    }
    public void SetPlayerStatData(PlayerStat _stat)
    {
        playerStatData = _stat;
    }

    public void SetCharacter(PlayerCharacter ch)
    {
        character = ch;
    }

    public PlayerPower PlayerPowerData
    {
        get { return playerPowerData; }
    }

    public void SetPlayerPowerLevel(Powers power,int level)
    {
        switch (power)
        {
            case Powers.Might:
                playerPowerData.Might = level;
                break;
            case Powers.Armor:
                playerPowerData.Armor = level;
                break;
            case Powers.MaxHealth:
                playerPowerData.MaxHealth = level;
                break;
            case Powers.Recovery:
                playerPowerData.Recovery = level;
                break;
            case Powers.CoolDown:
                playerPowerData.CoolDown = level;
                break;
            case Powers.Area:
                playerPowerData.Area = level;
                break;
            case Powers.Speed:
                playerPowerData.Speed = level;
                break;
            case Powers.Duration:
                playerPowerData.Duration = level;
                break;
            case Powers.Amount:
                playerPowerData.Amount = level;
                break;
            case Powers.MoveSpeed:
                playerPowerData.MoveSpeed = level;
                break;
            case Powers.Magnet:
                playerPowerData.Magnet = level;
                break;
            case Powers.Luck:
                playerPowerData.Luck = level;
                break;
            case Powers.Growth:
                playerPowerData.Growth = level;
                break;
            case Powers.Greed:
                playerPowerData.Greed = level;
                break;
        }
    }

    public void ResetPowerData()
    {
        playerPowerData.Might = 0;
        playerPowerData.Armor = 0;
        playerPowerData.MaxHealth = 0;
        playerPowerData.Recovery = 0;
        playerPowerData.CoolDown = 0;
        playerPowerData.Area = 0;
        playerPowerData.Speed = 0;
        playerPowerData.Duration = 0;
        playerPowerData.Amount = 0;
        playerPowerData.MoveSpeed = 0;
        playerPowerData.Magnet = 0;
        playerPowerData.Luck = 0;
        playerPowerData.Growth = 0;
        playerPowerData.Greed = 0;
    }

    private int coin = 50000;
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    private int cost = 0;
    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    private int lvUpCount;
    public int LvUpCount 
    {
        get { return lvUpCount; }
        set { lvUpCount = value; }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public PlayerPower GetGameData()
    {
        return new PlayerPower()
        {
            Might = playerPowerData.Might,
            Armor =  playerPowerData.Armor,
            MaxHealth = playerPowerData.MaxHealth,
            Recovery = playerPowerData.Recovery,
            CoolDown = playerPowerData.CoolDown,
            Area = playerPowerData.Area,
            Speed = playerPowerData.Speed,
            Duration = playerPowerData.Duration,
            Amount = playerPowerData.Amount,
            MoveSpeed = playerPowerData.MoveSpeed,
            Magnet = playerPowerData.Magnet,
            Luck = playerPowerData.Luck,
            Growth = playerPowerData.Growth,
            Greed = playerPowerData.Greed,
        };
    }

}
