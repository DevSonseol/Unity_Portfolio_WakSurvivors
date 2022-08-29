using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pentagram : Weapon
{

    private SpriteRenderer sr;
    Color alpha;

    [SerializeField]
    private Text text;

    [SerializeField]
    float ImageAlpha = 0.7f;

    float time = 0f;

    private CircleCollider2D cc;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        sr = gameObject.GetComponent<SpriteRenderer>();
        alpha = sr.color;
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
        ////모든 몬스터 정지
        StartCoroutine(FadeIn());
        Monster.CanMovingAll = false;

        yield return new WaitForSeconds(duration);

        StartCoroutine(FadeOut());

        Monster.CanMovingAll = true;

        yield return new WaitForSeconds(coolTime);
        //FadeOut();
        CanCast = true;
    }

    IEnumerator FadeIn()
    {
        time = 0;
        alpha.a = 0;
        while (time <= ImageAlpha)
        {
            time += Time.deltaTime ;
            alpha.a = time;
            yield return new WaitForEndOfFrame();
            sr.color = alpha;
        }

        
    }

    IEnumerator FadeOut()
    {
        time = ImageAlpha;
        alpha.a = ImageAlpha;
        while (alpha.a >= 0)
        {
            time -= Time.deltaTime;
            alpha.a = time;
            yield return new WaitForEndOfFrame();
            sr.color = alpha;
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
