using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : Weapon
{

    [SerializeField]
    private float distFromPlayer;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Start()
    {
        //첫번쨰꺼 작동
        CanCast = true;
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;
        //플레이어 위치로 이동
        transform.position = player.transform.position;


        if (CanCast)
        {
            CanCast = false;
            //공격
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        float degree = 360 / bulletCount + PlayerData.Instance.Stat.Amount ;

        for (int i = 0; i < bulletCount + PlayerData.Instance.Stat.Amount; i++)
        {
            yield return new WaitForSeconds(castdelayTime);

            Shoot(distFromPlayer * (1 + PlayerData.Instance.Stat.Area),degree * i);
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * (bulletCount + PlayerData.Instance.Stat.Amount)));

        CanCast = true;
    }


    private void Shoot(float dist, float degree)
    {
        if (MonsterPool.Instance.nerestTarget == null)
            return;

        Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;

        var bullet = ObjectPool.GetBullet(BulletCategory.Bible) as BibleBullet;
        bullet.transform.position = transform.position;

        bullet.SetBulletStat(damage, duration, speed);
        bullet.SetDistFromPlayerAndDegree(distFromPlayer, degree);

        bullet.Shoot(dir.normalized);
    }

    public override void LevelUp()
    {
        if (Level < MaxLevel)
        {
            Level++;

            switch (Level)
            {
                case 1:
                    damage = 10;
                    bulletCount = 2;
                    break;
                case 2:
                    damage = 10;
                    bulletCount = 3;
                    break;
                case 3:
                    damage = 15;
                    bulletCount = 3;
                    break;
                case 4:
                    damage = 15;
                    bulletCount = 4;
                    break;
                case 5:
                    damage = 20;
                    bulletCount = 4;
                    break;
                case 6:
                    damage = 20;
                    bulletCount = 5;
                    break;
                case 7:
                    damage = 25;
                    bulletCount = 5;
                    break;
                case 8:
                    damage = 30;
                    bulletCount = 6;
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    CanEvolve = true;
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
                    _levelDesc = "이빨 1 증가";
                    break;
                case 2:
                    _levelDesc = "데미지 5증가";
                    break;
                case 3:
                    _levelDesc = "이빨 1 증가";
                    break;
                case 4:
                    _levelDesc = "데미지 5증가";
                    break;
                case 5:
                    _levelDesc = "이빨 1 증가";
                    break;
                case 6:
                    _levelDesc = "데미지 5증가";
                    break;
                case 7:
                    _levelDesc = "데미지 5,이빨 1증가";
                    break;

            }

        }
    }


}
