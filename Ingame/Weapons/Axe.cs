using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
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
        for (int i = 0; i < bulletCount; i++)
        {
            yield return new WaitForSeconds(castdelayTime);
            Shoot();
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;
    }


    private void Shoot()
    {
        if (MonsterPool.Instance.nerestTarget == null)
            return;

        Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;
        dir.y = 0;
        dir.z = 0;

        var bullet = ObjectPool.GetBullet(BulletCategory.Axe);
        bullet.transform.position = transform.position;
        bullet.SetDamage(damage);
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
                    damage = 5;
                    bulletCount = 1;
                    break;
                case 2:
                    damage = 10;
                    bulletCount = 1;
                    break;
                case 3:
                    damage = 10;
                    bulletCount = 2;
                    break;
                case 4:
                    damage = 20;
                    bulletCount = 2;
                    break;
                case 5:
                    damage = 20;
                    bulletCount = 3;
                    break;
                case 6:
                    damage = 30;
                    bulletCount = 3;
                    break;
                case 7:
                    damage = 30;
                    bulletCount = 4;
                    break;
                case 8:
                    damage = 40;
                    bulletCount = 4;
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
                    _levelDesc = "데미지 5증가";
                    break;
                case 2:
                    _levelDesc = "도끼 1개 증가";
                    break;
                case 3:
                    _levelDesc = "데미지 10증가";
                    break;
                case 4:
                    _levelDesc = "도끼 1개 증가";
                    break;
                case 5:
                    _levelDesc = "데미지 10증가";
                    break;
                case 6:
                    _levelDesc = "도끼 1개 증가";
                    break;
                case 7:
                    _levelDesc = "데미지 10증가";
                    break;

            }

        }
    }

}
