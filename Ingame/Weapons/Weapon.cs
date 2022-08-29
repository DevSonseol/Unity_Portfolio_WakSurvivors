using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    public bool isWeapon;

    [SerializeField]
    protected GameObject player;

    public Sprite _sprite;

    public string _name;

    public string _desc;

    public string _levelDesc;

    public Weapons weaponType;

    [SerializeField]
    protected int MaxLevel = 8;

    [SerializeField]
    protected int Level = 1;

    public int LV {
        get { return Level; } 
    }

    protected bool CanEvolve = false;

    [SerializeField]
    [Tooltip("subweapon�� �̰͸�ŭ �ɷ�ġ����")]
    protected float damage; //subweapon�� �̰͸�ŭ �ɷ�ġ����

    [SerializeField]
    protected float duration;

    [SerializeField]
    protected float coolTime;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int maxBulletCount = 8;
    [SerializeField]
    protected float castdelayTime = 0.05f;

    [SerializeField]
    protected GameObject BulletPrefab;

    [SerializeField]
    protected int bulletCount = 1;

    [SerializeField]
    protected bool CanCast = true;

    void Start()
    {
        
    }


    protected virtual void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;
    }

    public virtual void LevelUp() { }

    public virtual void UpdateDesc() 
    {
        if (Level < MaxLevel)
        {

            switch (Level)
            {
                case 1:
                    _levelDesc = "����2�̸�����";
                    break;
                case 2:
                    _levelDesc = "����3�̸�����";
                    break;
                case 3:
                    _levelDesc = "����4�̸�����";
                    break;
                case 4:
                    _levelDesc = "����5�̸�����";
                    break;
                case 5:
                    _levelDesc = "����6�̸�����";
                    break;
                case 6:
                    _levelDesc = "����7�̸�����";
                    break;
                case 7:
                    _levelDesc = "����8�̸�����";
                    break;

            }

        }
    }


    public void UpdateStat(PlayerStat stat)
    {

        damage *= stat.Might; //subweapon�� �̰͸�ŭ �ɷ�ġ����

        duration += (stat.Duration - 1); ;

        coolTime -= (stat.CoolDown - 1); ;

        speed *= stat.Speed; ;

        bulletCount += (int)stat.Amount; ;





}


}
