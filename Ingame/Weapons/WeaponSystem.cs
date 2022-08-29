using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Whip, MagicWand, Knife, Axe, Cross, Bible, FireWand, Garlic, SantaWater, RuneTracer, LightingRing, Pentagram, Gun , Peachone // 진짜 무기
    , BACKCHUNSIK, WAKPAGO, HZ, NEGATIVE, BK, SHRIMP, SOPHIA, HRS, HIKIKING, WT, PRITER, KIMCHI, REUN, CC ,EDS //서브 웨폰


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

    //메인 웨폰
    public List<Weapon> WeaponList { get { return weaponList; } }

    public List<Weapon> playerWeaponList = new List<Weapon>();

    //서브 웨폰 (능력치만 변동시켜줌 )
    public List<Weapon> SubWeaponList { get { return subWeaponList; } }

    public List<Weapon> playerSubWeaponList = new List<Weapon>();



    private void Awake()
    {
        Instance = this;
    }

    public void Add_MaxWeapons(Weapon weapon)
    {
        //갯수 초과 하지않고 중복이지 않을때 추가
        if(MaxLevelWeapons.Count <= MAXWEAPONCOUNT && !MaxLevelWeapons.Contains(weapon))
            MaxLevelWeapons.Add(weapon);
    }


    public void Add_Weapon(Weapon _weapon)
    {
        //hp회복일 경우
        if(_weapon == HPUP_Weapon)
        {
            var wp = Instantiate(_weapon, GameObject.Find("WeaponSystem").transform);
            return;
        }


        if (_weapon.isWeapon)//메인 웨폰
        {
            int index = 0;

            //기존에 있을때
            foreach (Weapon weapon in playerWeaponList)
            {

                if (weapon.weaponType == _weapon.weaponType)
                {
                    //무기 레벨업
                    weapon.LevelUp();
                    weapon.UpdateDesc();

                    //UI업데이트
                    IngameUIManager.Instance.WeaponUI.UpdateUI(index, weapon);
                    return;
                }

                index++;
            }

            //없을때
            foreach (Weapon weapon in weaponList)
            {
                if (weapon == _weapon)
                {
                    //무기 추가
                    var wp = Instantiate(weapon, GameObject.Find("WeaponSystem").transform);
                    playerWeaponList.Add(wp);
                    wp.gameObject.SetActive(true);

                    IngameUIManager.Instance.WeaponUI.AddWeaponUI(wp);
                    wp.UpdateDesc();
                }
            }

        }
        else//서브 웨폰
        {
            int index = 0;

            //기존에 있을때
            foreach (Weapon weapon in playerSubWeaponList)
            {
                if (weapon.weaponType == _weapon.weaponType)
                {
                    //무기 레벨업
                    weapon.LevelUp();

                    //UI업데이트
                    IngameUIManager.Instance.WeaponUI.UpdateUI(index, weapon);
                    return;
                }

                index++;
            }

            //없을때
            foreach (Weapon weapon in subWeaponList)
            {
                if (weapon == _weapon)
                {

                    //무기 추가
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
