using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerCharacter
{
    Wak,Ine,Jingburger,Lilpa,Jururu,Gosegu,Viichan
}

public class Player : MonoBehaviour
{
    private const float normalSize = 0.5f;

    //player 설정 할 것들

    public delegate void HP_Delegate(float MaxHP,float HP);
    public HP_Delegate hp_delegate;


    [SerializeField]
    private float hp;

    public float HP { get { return hp; } }

    [SerializeField]
    private float maxHP;

    public float MaxHP{ get { return maxHP; } }

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigid2D;
    private Animator animator;

    [HideInInspector]
    public Vector3 playerDir;

    void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();

        SoundManager.Instance.PlayBGM("WAKTAVERSE");

    }

    void Start()
    {
        playerDir = new Vector3(1, 0, 0);
        moveSpeed = 2f;//PlayerData.Instacne.Stat.MoveSpeed;
        hp = PlayerData.Instance.Stat.MaxHealth;
        maxHP = PlayerData.Instance.Stat.MaxHealth;

        circleCollider2D.radius = normalSize * PlayerData.Instance.Stat.Magnet;

        //기본무기 추가
        AddDefaultWeapon(GameSystem.Instance.character);
    }

    void AddDefaultWeapon(PlayerCharacter ch)
    {
        int number = 0;

        switch (ch)
        {
            case PlayerCharacter.Wak:
                number = (int)Weapons.Whip;
                break;

            case PlayerCharacter.Ine:
                number = (int)Weapons.Axe;
                break;

            case PlayerCharacter.Jingburger:
                number = (int)Weapons.RuneTracer;
                break;

            case PlayerCharacter.Lilpa:
                number = (int)Weapons.Gun;
                break;

            case PlayerCharacter.Jururu:
                number = (int)Weapons.Garlic;
                break;

            case PlayerCharacter.Gosegu:
                number = (int)Weapons.Whip;
                break;

            case PlayerCharacter.Viichan:
                number = (int)Weapons.Whip;
                break;

        }

        WeaponSystem.Instance.Add_Weapon(WeaponSystem.Instance.WeaponList[number]);
    }



    void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
        {
            rigid2D.velocity = new Vector3(0, 0, 0);
            return;
        }

        if (HP <= 0)
        {
            if (!IngameUIManager.Instance.GameEndUI.isOpened)
                IngameUIManager.Instance.GameEndUI.Open_UI();
            return;
        }
            

        Input_MovePlayer();
    }

    public void Input_MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //player방향벡터
        if(x != 0 || y != 0)
        {
            playerDir.x = x;
            playerDir.y = y;
        }


        bool isMove = false;
        
        if(x !=0 || y !=0)
        {
            isMove = true;
            rigid2D.velocity = new Vector3(x, y, 0).normalized * moveSpeed;
        }else
        {
            rigid2D.velocity = new Vector3(0, 0, 0);
        }
               
        animator.SetBool("isMove", isMove);

        //방향에 따라 이미지 좌우 반전해주기
        if (x < 0)
        {
            this.transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        else if (x > 0)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }

    }

    public void Get_Damage(float damage)
    {
        hp -= damage;
        hp_delegate(maxHP,hp);
    }

}
