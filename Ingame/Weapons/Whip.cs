using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : Weapon
{
    private const int maxWhipCount = 4;
    private const float castdelayTinme = 0.15f;

    [SerializeField]
    private WhipBullet[] whips;

    [SerializeField]
    private bool[] isActive = new bool[4];

    [SerializeField]
    //private string[] desc = new string[8];

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Start()
    {
        //첫번쨰꺼 작동
        CanCast = true;
        isActive[0] = true;
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        //플레이어 위치로 이동
        transform.position = player.transform.position;
        if (player.transform.localScale.x > 0)
            transform.transform.localScale = new Vector3(1, 1, 1);
        else
            transform.transform.localScale = new Vector3(-1, 1, 1);


        if (CanCast)
        {
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        CanCast = false;

        for (int i = 0; i < isActive.Length; i++)
        {
            if(isActive[i])
            {
                StartCoroutine(FadeIn(whips[i]));
            }
            yield return new WaitForSeconds(castdelayTinme);
        }

        yield return new WaitForSeconds(coolTime-( castdelayTinme* maxWhipCount));

        CanCast = true;
    }


    private IEnumerator FadeIn(WhipBullet go)
    {
        go.gameObject.SetActive(true);
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        Color color = sr.material.color;
        color.a = 0;

        while (color.a < 1)
        {
            color.a += Time.deltaTime / duration;
            sr.material.color = color;
            yield return new WaitForSeconds(Time.deltaTime / duration);
        }

        color.a = 0;
        go.gameObject.SetActive(false);
    }



    public override void LevelUp()
    {
        if(Level < MaxLevel)
        {
            Level++;
            
            switch(Level)
            {
                case 1:
                    isActive[0] = true;
                    _levelDesc = "채찍으로 가격한다";
                    break;
                case 2:
                    damage+=5;
                    _levelDesc = "데미지 5증가";
                    break;
                case 3:
                    isActive[1] = true;
                    _levelDesc = "채찍 갯수 증가 ";
                    break;
                case 4:
                    damage += 5;
                    _levelDesc = "데미지 5증가";
                    break;
                case 5:
                    isActive[2] = true;
                    _levelDesc = "채찍 갯수 증가 ";
                    break;
                case 6:
                    damage += 10;
                    _levelDesc = "데미지 10증가";
                    break;
                case 7:
                    isActive[3] = true;
                    _levelDesc = "채찍 갯수 증가 ";
                    break;
                case 8:
                    damage += 10;
                    _levelDesc = "데미지 10증가";
                    WeaponSystem.Instance.Add_MaxWeapons(this);
                    CanEvolve = true;
                    break;
            }

        }
        else
        {
            Debug.Log(_name + "is MaxLevel");
        }

    }


    public override void UpdateDesc()
    {
        base.UpdateDesc();
    }

}
