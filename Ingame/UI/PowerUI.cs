using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUI : MonoBehaviour
{
    //power subpower�� �� ������ ī������ ����
    public int powerCount = 0;
    public int subPowerCount = 0;
    //�ִ� ���� 7���� ����
    int maxPowerCount = 7;

    //���Ե�
    public PowerUISlot[] powerUISlots;

    public PowerUISlot[] subPowerUISlots;

    //ó�� �߰��ϴ°Ÿ� 
    public void AddWeaponUI(Weapon weapon)
    {
        //���� �ʰ��� ����
        if (powerCount >= maxPowerCount)
            return;


        //Ȱ��ȭ
        powerUISlots[powerCount].gameObject.SetActive(true);
        powerUISlots[powerCount].SetWeaponUISlot(weapon);

        powerCount++;

    }


    public void AddSubWeaponUI(Weapon weapon)
    {
        if (subPowerCount >= maxPowerCount)
            return;


        //Ȱ��ȭ
        subPowerUISlots[subPowerCount].gameObject.SetActive(true);
        subPowerUISlots[subPowerCount].SetSubWeaponUISlot(weapon);

        subPowerCount++;
    }


    //������ �ִ��Ÿ�
    public void UpdateUI(int index,Weapon weapon)
    {
        if(weapon.isWeapon)
            powerUISlots[index].SetWeaponUISlot(weapon);
        else
            subPowerUISlots[index].SetSubWeaponUISlot(weapon);


    }




}
