using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightening : Weapon
{

    private int countMonster;

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
            Shoot(i);
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;
    }


    private void Shoot(int index)
    {
        //초기화
        countMonster = 0;

        Transform[] monsters = MonsterPool.Instance.gameObject.GetComponentsInChildren<Transform>();

        int childCount = MonsterPool.Instance.gameObject.transform.childCount;

        Monster target = null; 

        foreach(Transform mon in monsters)
        {
            if(mon.gameObject.activeSelf == true )
            {
                if(index == countMonster)
                {
                    target = mon.gameObject.GetComponent<Monster>();

                    break;
                }

                countMonster++;
            }
        }

        if (target == null)
            return;
        else
        {
            Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;

            var bullet = ObjectPool.GetBullet(BulletCategory.Lightening) as LighteningBullet;
            bullet.SetBulletStat(damage, duration, speed);
            bullet.Shoot(target);
        }

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
