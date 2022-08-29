using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighteningBullet : Bullet
{

    public Sprite[] sparks;

    private SpriteRenderer sr;


    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

    }

    public void Shoot(Monster targetMonster)
    {
        //이미지 변경
        int rand = Random.Range(0, 8);
        sr.sprite = sparks[rand];

        //위치 이동
        transform.position = targetMonster.transform.position;
        Invoke("DestroyBullet", duration);

        //번개 소리

        //타겟에 데미지
        targetMonster.TakeDamage(damage);
    }







}
