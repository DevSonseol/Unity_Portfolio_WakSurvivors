using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Whip, MagicWand, Knife, Axe, Cross, Bible, FireWand, Garlic, SantaWater, RuneTracer, LightingRing, Pentagram, Gun , Peachone // ��¥ ����
    , BACKCHUNSIK, WAKPAGO, HZ, NEGATIVE, BK, SHRIMP, SOPHIA, HRS, HIKIKING, WT, PRITER, KIMCHI, REUN, CC ,EDS //���� ����


}


public class WeaponSystem : MonoBehaviour
{
    public static WeaponSystem Instance;

    public const int MAXWEAPONCOUNT = 7;

    [SerializeField]
    private List<Weapon> weaponList = new List<Weapon>();

    public Weapon HPUP_Weapon;

    [SerializeField]
    private List<Weapon> subWeaponList = new List<Weapon>();

    public List<Weapon> MaxLevelWeapons = new List<Weapon>();

    public List<Weapon> MaxLevelSubWeapons = new List<Weapon>();

    //���� ����
    public List<Weapon> WeaponList { get { return weaponList; } }

    public List<Weapon> playerWeaponList = new List<Weapon>();

    //���� ���� (�ɷ�ġ�� ���������� )
    public List<Weapon> SubWeaponList { get { return subWeaponList; } }

    public List<Weapon> playerSubWeaponList = new List<Weapon>();



    private void Awake()
    {
        Instance = this;
    }

    public void Add_MaxWeapons(Weapon weapon)
    {
        //���� �ʰ� �����ʰ� �ߺ����� ������ �߰�
        if(MaxLevelWeapons.Count <= MAXWEAPONCOUNT && !MaxLevelWeapons.Contains(weapon))
            MaxLevelWeapons.Add(weapon);
    }


    public void Add_Weapon(Weapon _weapon)
    {
        //hpȸ���� ���
        if(_weapon == HPUP_Weapon)
        {
            var wp = Instantiate(_weapon, GameObject.Find("WeaponSystem").transform);
            return;
        }


        if (_weapon.isWeapon)//���� ����
        {
            int index = 0;

            //������ ������
            foreach (Weapon weapon in playerWeaponList)
            {

                if (weapon.weaponType == _weapon.weaponType)
                {
                    //���� ������
                    weapon.LevelUp();
                    weapon.UpdateDesc();

                    //UI������Ʈ
                    IngameUIManager.Instance.WeaponUI.UpdateUI(index, weapon);
                    return;
                }

                index++;
            }

            //������
            foreach (Weapon weapon in weaponList)
            {
                if (weapon == _weapon)
                {
                    //���� �߰�
                    var wp = Instantiate(weapon, GameObject.Find("WeaponSystem").transform);
                    playerWeaponList.Add(wp);
                    wp.gameObject.SetActive(true);

                    IngameUIManager.Instance.WeaponUI.AddWeaponUI(wp);
                    wp.UpdateDesc();
                }
            }

        }
        else//���� ����
        {
            int index = 0;

            //������ ������
            foreach (Weapon weapon in playerSubWeaponList)
            {
                if (weapon.weaponType == _weapon.weaponType)
                {
                    //���� ������
                    weapon.LevelUp();

                    //UI������Ʈ
                    IngameUIManager.Instance.WeaponUI.UpdateUI(index, weapon);
                    return;
                }

                index++;
            }

            //������
            foreach (Weapon weapon in subWeaponList)
            {
                if (weapon == _weapon)
                {

                    //���� �߰�
                    var wp = Instantiate(weapon, GameObject.Find("WeaponSystem").transform);
                    playerSubWeaponList.Add(wp);
                    wp.UpdateDesc();
                    wp.gameObject.SetActive(true);

                    IngameUIManager.Instance.WeaponUI.AddSubWeaponUI(wp);
                }

            }
        }
    }

    public void UpdateWeaponsStat()
    {
        foreach(Weapon wp in playerWeaponList)
        {
            //wp.


        }





    }



}
