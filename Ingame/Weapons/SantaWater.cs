using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWater : Weapon
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
        transform.position = player.transform.position + new Vector3(-6,6,0);


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

        float rand1 = Random.Range(-6f, 6f);
        float rand2 =  Random.Range(-4f, 4f);

        Vector3 dest = player.transform.position + new Vector3(rand1,rand2,0);

        var bullet = ObjectPool.GetBullet(BulletCategory.SantaWater) as SantaWaterBullet;
        bullet.transform.position = transform.position;
        bullet.SetBulletStat(damage, duration, speed);
        bullet.SetDestination(dest);
        bullet.Shoot((dest - transform.position).normalized);
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
                    CanEvolve = true;
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    break;
            }

        }
    }
}
