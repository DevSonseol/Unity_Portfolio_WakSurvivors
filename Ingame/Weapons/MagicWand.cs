using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : Weapon
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

        var bullet = ObjectPool.GetBullet(BulletCategory.MagicWand);
        bullet.transform.position = transform.position + dir.normalized;
        bullet.SetBulletStat(damage, duration, speed);
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
                    _levelDesc = "마법을 발사한다";
                    break;
                case 2:
                    damage += 5;
                    bulletCount++;
                    _levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 3:
                    damage += 5;
                    _levelDesc = "데미지 5";
                    break;
                case 4:
                    damage += 5;
                    bulletCount++;
                    _levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 5:
                    damage += 5;
                    _levelDesc = "데미지 10";
                    break;
                case 6:
                    damage += 5;
                    bulletCount++;
                    _levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 7:
                    damage += 10;
                    bulletCount++;
                    _levelDesc = "데미지 10 ,총알 1증가";
                    break;
                case 8:
                    damage += 10;
                    bulletCount++;
                    _levelDesc = "데미지 10 ,총알 1증가";
                    CanEvolve = true;
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    break;
            }

        }
    }

    public override void UpdateDesc()
    {
        base.UpdateDesc();
    }



}
