using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
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
            Debug.Log("나이프");
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;

    }


    private void Shoot()
    {
        Vector3 dir = player.GetComponent<Player>().playerDir;

        var bullet = ObjectPool.GetBullet(BulletCategory.Knife);
        //약간 거리 벌리기 
        float rad1 = Random.Range(-0.5f, 0.5f);
        float rad2 = Random.Range(- 0.5f, 0.5f);

        bullet.transform.position = transform.position + new Vector3(rad1, rad2, 0);
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
                    //_levelDesc = "마법을 발사한다";
                    break;
                case 2:
                    damage += 5;
                    bulletCount++;
                    //_levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 3:
                    damage += 5;
                    //_levelDesc = "데미지 5";
                    break;
                case 4:
                    damage += 5;
                    bulletCount++;
                    //_levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 5:
                    damage += 5;
                    //_levelDesc = "데미지 10";
                    break;
                case 6:
                    damage += 5;
                    bulletCount++;
                    //_levelDesc = "데미지 5 ,총알 1증가";
                    break;
                case 7:
                    damage += 10;
                    bulletCount++;
                    //_levelDesc = "데미지 10 ,총알 1증가";
                    break;
                case 8:
                    damage += 10;
                    bulletCount++;
                    //_levelDesc = "데미지 10 ,총알 1증가";
                    CanEvolve = true;
                    WeaponSystem.Instance.MaxLevelWeapons.Add(this);
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
                    _levelDesc = "레벨2미리보기";
                    break;
                case 2:
                    _levelDesc = "레벨3미리보기";
                    break;
                case 3:
                    _levelDesc = "레벨4미리보기";
                    break;
                case 4:
                    _levelDesc = "레벨5미리보기";
                    break;
                case 5:
                    _levelDesc = "레벨6미리보기";
                    break;
                case 6:
                    _levelDesc = "레벨7미리보기";
                    break;
                case 7:
                    _levelDesc = "레벨8미리보기";
                    break;

            }

        }
    }
}
