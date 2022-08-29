
//public struct PlayerPower
//{
//    int MaxHealth; //랭크당 체력 10% 증가(최대 랭크 3)
//    int Recovery; // 랭크당 피격 대미지 1 감소(최대 랭크 3)
//    int Might; // 랭크당 공격력 5% 증가(최대 랭크 5)
//    int Armor; //랭크당 피격 대미지 1 감소(최대 랭크 3)
//    int CoolDown; // 랭크당 쿨타임 2.5% 감소(최대 랭크 2)
//    int Area; //  랭크당 범위 5% 증가(최대 랭크 2)
//    int Speed; //랭크당 투사체 속도 10% 증가(최대 랭크 2)
//    int Duration;//  랭크당 지속력 15% 증가(최대 랭크 2)
//    int Amount; // 투사체 개수 +1(최대 랭크 1)
//    int MoveSpeed;// 랭크당 이동속도 5% 증가(최대 랭크 2)
//    int Magnet; // 랭크당 획득반경 25% 증가(최대 랭크 2)
//    int Luck; //랭크당 행운 수치 10% 증가(최대 랭크 3)
//    int Growth;//랭크당 경험치 획득 3% 증가(최대 랭크 5)
//    int Greed; //랭크당 골드 획득 5% 증가(최대 랭크 5)
//}

//struct PlayerStat
//{
//    int HP;
//    int MoveSpeed;
//    int EXP;
//    int Rank;
//}//Player 캐릭터 기본 정보 

struct MonsterStat
{
    int HP;
    int MoveSpeed;
    int ATK;
}

struct AblilityStat
{
    int ATK; //공격력
    int Amount; //투사체 
    int Limit; // 투사체 제한
    int CoolTime; //쿨타임
    int penetration; //관통
    int DurationTime; //지속시간
    int Critical; //치명타 데미지 2배
}