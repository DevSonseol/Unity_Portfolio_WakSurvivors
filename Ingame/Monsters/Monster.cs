using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterCategory
{

   Bat,Bird,Dog,Fox,Germ,Rani

}

public class Monster : MonoBehaviour
{
    public static bool CanMovingAll = true;

    bool isKnock = false;

    public Transform damageTextTrans;

    [SerializeField]
    private MonsterCategory monsterCategory;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float HP;

    [SerializeField]
    private float damage;

    [SerializeField]
    private bool CanDamage = true;

    [SerializeField]
    private float speed; //임시 스피드

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D rigid2D;
    private SpriteRenderer sr;

    [SerializeField]
    public Vector3 velo;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        velo = rigid2D.velocity;
    }

    void Start()
    {
        ChangeSprite();

        if (target == null)
            target = GameObject.Find("Player");

        InvokeRepeating("ChangeSprite",1,0.5f);
    }

  
    void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        if(HP <= 0)
        {
            //사망처리
            Debug.Log("Monster 사망처리");
            this.Die();
        }

        if(CanMovingAll)
            ChaseTarget();
    }

    void ChaseTarget()
    {
        if (target == null) //타겟이 없으면 리턴
            return;

        moveDirection = target.transform.position - transform.position; //방향벡터
      
        if(!isKnock)//만약 맞은상태면
            rigid2D.MovePosition(transform.position + moveDirection.normalized * Time.deltaTime * speed);
        else
            rigid2D.MovePosition(transform.position - moveDirection.normalized * Time.deltaTime * speed*2);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CanDamage)
            return;

        if (collision.collider.gameObject.GetComponent<Player>() == null)
        {
            return;
        }
        else
        {
            //Debug.Log("HitPlayer");

            CanDamage = false;
            //플레이어 데미지


            StartCoroutine(AttackDelay());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!CanDamage)
            return;

        if (collision.collider.gameObject.GetComponent<Player>() == null)
        {
            return;
        }
        else
        {
            //Debug.Log("HittingPlayer");

            CanDamage = false;
            //플레이어 데미지
            target.GetComponent<Player>().Get_Damage(damage);


            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        CanDamage = true;
    }

    public void TestChangeColor(Color color)
    {
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();

        renderer.color = color;

    }

    public void Die()
    {
        var coin = CoinPool.GetCoin();
        int randNum = Random.Range(1, 5);
        coin.SetCoin(randNum,transform.position);

        MonsterPool.ReturnMonster(this);
    }

    public void TakeDamage(float Damage)
    {
        HP -= Damage;

        //damage text
        DamageText dt = DamageTextPool.GetText();
        dt.SetText((int)Damage, damageTextTrans.position);

        //타격으로 인한 멈춤
        StartCoroutine(KnockBack(0.2f));
    }

    IEnumerator KnockBack(float time)
    {
        isKnock = true;
        yield return new WaitForSeconds(time);
        isKnock = false;
    }

    public void SetMonster(Vector3 playerPos,float HP,float Damage,float Speed = 5)
    {
        this.HP = HP;
        this.damage = Damage;
        this.speed = Speed;
        this.isKnock = false;

        Vector3 newPos;
        float dist = 8;
        float randRad = Random.Range(0f, 6.28f);
        float x = dist * Mathf.Cos(randRad);
        float y = dist * Mathf.Sin(randRad);
        newPos = new Vector2(x, y);

        this.transform.position = playerPos+ newPos;

    }

    public void SetMonsterCategory(MonsterCategory MC)
    {
        monsterCategory = MC;
    }


    void ChangeSprite()
    {
        switch (monsterCategory)
        {
            case MonsterCategory.Bat:

                if (sr.sprite != sprites[0])
                    sr.sprite = sprites[0];
                else
                    sr.sprite = sprites[1];

                break;
            case MonsterCategory.Bird:

                if (sr.sprite != sprites[2])
                    sr.sprite = sprites[2];
                else
                    sr.sprite = sprites[3];

                break;
            case MonsterCategory.Dog:

                if (sr.sprite != sprites[4])
                    sr.sprite = sprites[4];
                else
                    sr.sprite = sprites[5];

                break;
            case MonsterCategory.Fox:

                if (sr.sprite != sprites[6])
                    sr.sprite = sprites[6];
                else
                    sr.sprite = sprites[7];

                break;
            case MonsterCategory.Germ:

                if (sr.sprite != sprites[8])
                    sr.sprite = sprites[8];

                transform.Rotate(new Vector3(0, 0, 5));

                break;
            case MonsterCategory.Rani:

                if (sr.sprite != sprites[9])
                    sr.sprite = sprites[9];
                else
                    sr.sprite = sprites[10];


                break;

        }
    }
}
