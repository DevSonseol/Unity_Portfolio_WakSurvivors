using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWand : Weapon
{
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        CanCast = true;
    }
    void Start()
    {


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
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        float degree = 0;
        float deltadegree = 0;

        for (int i = 0; i < bulletCount; i++)
        {
            degree = (i % 2 == 0 ) ? (degree += deltadegree) : (degree -= deltadegree);

            Shoot(degree);

            deltadegree += 10;
        }


        yield return new WaitForSeconds(coolTime);

        CanCast = true;
    }


    private void Shoot(float degree)
    {
        if (MonsterPool.Instance.nerestTarget == null)
            return;

        Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;

        var bullet = ObjectPool.GetBullet(BulletCategory.FireWand) as FireWandBullet;
        bullet.transform.position = transform.position;
        bullet.SetBulletStat(damage, duration, speed);
        bullet.SetDegree(degree);
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
                    damage += 3;
                    break;
                case 3:
                    bulletCount++;
                    break;
                case 4:
                    damage += 4;
                    break;
                case 5:
                    bulletCount++;
                    break;
                case 6:
                    damage += 5;
                    break;
                case 7:
                    bulletCount++;
                    break;
                case 8:
                    damage += 5;
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    CanEvolve = true;
                    break;
            }

        }
    }


    public override void UpdateDesc()
    {
        base.UpdateDesc();
    }


}
