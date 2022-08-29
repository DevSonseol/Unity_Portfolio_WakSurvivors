using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUI : MonoBehaviour
{
    //power subpower가 몇 개인지 카운팅할 변수
    public int powerCount = 0;
    public int subPowerCount = 0;
    //최대 갯수 7개로 제한
    int maxPowerCount = 7;

    //슬롯들
    public PowerUISlot[] powerUISlots;

    public PowerUISlot[] subPowerUISlots;

    //처음 추가하는거면 
    public void AddWeaponUI(Weapon weapon)
    {
        //갯수 초과면 리턴
        if (powerCount >= maxPowerCount)
            return;


        //활성화
        powerUISlots[powerCount].gameObject.SetActive(true);
        powerUISlots[powerCount].SetWeaponUISlot(weapon);

        powerCount++;

    }


    public void AddSubWeaponUI(Weapon weapon)
    {
        if (subPowerCount >= maxPowerCount)
            return;


        //활성화
        subPowerUISlots[subPowerCount].gameObject.SetActive(true);
        subPowerUISlots[subPowerCount].SetSubWeaponUISlot(weapon);

        subPowerCount++;
    }


    //기존에 있던거면
    public void UpdateUI(int index,Weapon weapon)
    {
        if(weapon.isWeapon)
            powerUISlots[index].SetWeaponUISlot(weapon);
        else
            subPowerUISlots[index].SetSubWeaponUISlot(weapon);


    }




}
