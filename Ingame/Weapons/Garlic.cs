using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlic : Weapon
{


    [SerializeField]
    private List<Monster> inCircleMonsters = new List<Monster>();



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

    private void FixedUpdate()
    {
        if (CanCast)
        {
            
            CanCast = false;
            StartCoroutine(Active());
        }
    }


    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        //플레이어 위치로 이동
        transform.position = player.transform.position;

    }

    private IEnumerator Active()
    {
        isActiveMonster();

        foreach (Monster monster in inCircleMonsters)
        {
            monster.TakeDamage(damage);
        }

        yield return new WaitForSeconds(coolTime);

        CanCast = true;
    }

    private void isActiveMonster()
    {
        foreach(Monster monster in inCircleMonsters)
        {
            if(monster.gameObject.activeSelf == false)
            {
                inCircleMonsters.Remove(monster);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            inCircleMonsters.Add(collision.GetComponent<Monster>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            inCircleMonsters.Remove(collision.GetComponent<Monster>());
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
                    CanEvolve = true;
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    break;
            }

        }
    }
}
