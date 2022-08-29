using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSelectUI : MonoBehaviour
{


    public GameObject weaponSelectUI;

    public WeaponSelectButton[] buttons;

    List<int> weaponNumberList = new List<int>();

    bool[] checkbtn = new bool[3];

    public void Open_WSUI()
    {
        //WS_UI active = true;하고
        this.gameObject.SetActive(true);

        //게임 일시정지 
        Time.timeScale = 0f;

        //플레이어 레벨에 따라 3레벨마다 sub 아니면 무기
        if(PlayerData.Instance.PlayerLV%3 == 0)
        {
            SettingButtonsInSubWeapons();
        }else
            SettingButtonsInWeapons();

    }

    public void Close_WSUI()
    {
        //WS_UI active = false;하고
        this.gameObject.SetActive(false);

        //게임 다시 동작시키기
        Time.timeScale = 1f;

    }

    void SettingButtonsInWeapons()
    {
        List<Weapon> maxLvWL = WeaponSystem.Instance.MaxLevelWeapons;
        List<Weapon> playerWL = WeaponSystem.Instance.playerWeaponList.ToList();//깊은복사
        if(playerWL.Count == WeaponSystem.MAXWEAPONCOUNT) //플레이어 무기갯수 최대이면
        {
            foreach (Weapon wp in maxLvWL)
            {
                if (playerWL.Contains(wp))
                    playerWL.Remove(wp);
            }

            int LeftLevelUpWeapon = playerWL.Count - maxLvWL.Count;

            if(LeftLevelUpWeapon > 3)
            {
                CreateUnDuplicateRandom(playerWL, 3);
                for(int i = 0; i < 3; i++)
                    IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(playerWL[weaponNumberList[i]]);
              
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if(i< LeftLevelUpWeapon)
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(playerWL[i]);
                    else
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(WeaponSystem.Instance.HPUP_Weapon);
                }

            }
         


        }
        else//무기갯수가 최대가 아니면
        {

            List<Weapon> TempWL = WeaponSystem.Instance.WeaponList.ToList(); //임시 무기 리스트

            foreach (Weapon wp in maxLvWL)
            {
                if (TempWL.Contains(wp))
                    TempWL.Remove(wp);
            }

            CreateUnDuplicateRandom(TempWL,3);

            bool isHad = false;

            for (int i = 0; i < buttons.Length; i++)
            {
                isHad = false;
                foreach (Weapon wp in playerWL)
                {
                    if(wp.weaponType == TempWL[weaponNumberList[i]].weaponType)
                    {
                        isHad = true;
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(wp);
                        break;
                    }
                }
                if(!isHad)
                    IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(TempWL[weaponNumberList[i]]);
            }

        }

    }

    void SettingButtonsInSubWeapons()
    {
        List<Weapon> maxLvWL = WeaponSystem.Instance.MaxLevelSubWeapons;
        List<Weapon> playerWL = WeaponSystem.Instance.playerSubWeaponList.ToList();//깊은복사
        if(playerWL.Count == WeaponSystem.MAXWEAPONCOUNT) //플레이어 무기갯수 최대이면
        {
            foreach (Weapon wp in maxLvWL)
            {
                if (playerWL.Contains(wp))
                    playerWL.Remove(wp);
            }

            int LeftLevelUpWeapon = playerWL.Count - maxLvWL.Count;

            if(LeftLevelUpWeapon > 3)
            {
                CreateUnDuplicateRandom(playerWL, 3);
                for(int i = 0; i < 3; i++)
                    IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(playerWL[weaponNumberList[i]]);
              
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    if(i< LeftLevelUpWeapon)
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(playerWL[i]);
                    else
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(WeaponSystem.Instance.HPUP_Weapon);
                }

            }
         
        }
        else//무기갯수가 최대가 아니면
        {

            List<Weapon> TempWL = WeaponSystem.Instance.SubWeaponList.ToList(); //임시 무기 리스트

            foreach (Weapon wp in maxLvWL)
            {
                if (TempWL.Contains(wp))
                    TempWL.Remove(wp);
            }

            CreateUnDuplicateRandom(TempWL,3);

            bool isHad = false;

            for (int i = 0; i < buttons.Length; i++)
            {
                isHad = false;
                foreach (Weapon wp in playerWL)
                {
                    if(wp.weaponType == TempWL[weaponNumberList[i]].weaponType)
                    {
                        isHad = true;
                        IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(wp);
                        break;
                    }
                }
                if(!isHad)
                    IngameUIManager.Instance.WeaponSelectUI.buttons[i].SettingButton(TempWL[weaponNumberList[i]]);
            }

        }
    }


    public void SettingButtonsNotMAX()
    {
        //번호추첨
        //CreateUnDuplicateRandom();

        for (int i = 0; i < checkbtn.Length; i++)
        {
            buttons[i].SettingButton(WeaponSystem.Instance.WeaponList[weaponNumberList[i]]);

            //weaponsystems 플레이어가 들고있는 무기이면 수정
            foreach (Weapon wp in WeaponSystem.Instance.playerWeaponList)
            {
                if (wp.weaponType == WeaponSystem.Instance.WeaponList[weaponNumberList[i]].weaponType)
                {
                    buttons[i].SettingButton(wp);
                    break;
                }
            }
        }

    }

    void CreateUnDuplicateRandom(List<Weapon> tempList , int RandCount)
    {
        weaponNumberList.Clear();

        int currentNumber = Random.Range(0, tempList.Count);

        for (int i = 0; i < RandCount;)
        {
            if (weaponNumberList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, tempList.Count);
            }
            else
            {
                weaponNumberList.Add(currentNumber);
                i++;
            }
        }

    }



    public void SettingButtonsInMAX()
    {
        //번호추첨
        CreateUnDuplicateRandomInMAX();

        for (int i = 0; i < checkbtn.Length; i++)
        {
            buttons[i].SettingButton(WeaponSystem.Instance.playerWeaponList[weaponNumberList[i]]);
        }

    }



    void CreateUnDuplicateRandomInMAX()
    {
        weaponNumberList.Clear();



        int currentNumber = Random.Range(0, WeaponSystem.Instance.playerWeaponList.Count);

        for (int i = 0; i < 3;)
        {
            if (weaponNumberList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, WeaponSystem.Instance.playerWeaponList.Count);
            }
            else
            {
                weaponNumberList.Add(currentNumber);
                i++;
            }
        }

    }




}
