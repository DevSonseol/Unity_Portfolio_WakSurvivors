using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private int[] weights = { 80, 15, 5 }; //È®·ü °¡ÁßÄ¡
    [SerializeField] private int weaponCount;
    public GameObject go;
    public GameObject particle;
    public SlotMachineSlot[] slots;
    public Text wonText;


    public void OpenSlotMachineUI()
    {
        go.SetActive(true);
        particle.SetActive(true);
        GameSystem.Instance.CanActiveGO = false;
        //Time.timeScale = 0f;

        startSlot();

    }


    void startSlot()
    {
        //¸î°³ »ÌÀ»Áö È®·ü Á¤ÇÏ±â
        weaponCount = 3;
        int randNum = Random.Range(0, 100);
        //if (randNum > weights[0])
        //    weaponCount = 2;
        //else if (randNum > weights[0] + weights[1])
        //    weaponCount = 3;

        StartCoroutine(RollingSpin(weaponCount));
        StartCoroutine(RollingText(randNum * weaponCount));
        StartCoroutine(WaittingDone());
    }



    IEnumerator RollingSpin(int num)
    {
        switch (num)
        {
            case 1:
                slots[1].StartSpin();
                break;
            case 2:
                slots[1].StartSpin();
                yield return new WaitForSeconds(1f);
                slots[2].StartSpin();
                break;
            case 3:
                slots[1].StartSpin();
                yield return new WaitForSeconds(1f);
                slots[0].StartSpin();
                yield return new WaitForSeconds(1f);
                slots[2].StartSpin();
                break;
        }
    }


    IEnumerator RollingText(int num)
    {
        float temp = 0;
        while(temp <= num)
        {
            temp += 0.1f;
            yield return new WaitForEndOfFrame();
            wonText.text = ((int)temp).ToString();
        }
    }

    IEnumerator WaittingDone()
    {
        yield return new WaitForSeconds(3f);

        while (!slots[2].isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        CloseSlotMachine();
    }


    public void CloseSlotMachine()
    {
        foreach (SlotMachineSlot slot in slots)
            slot.DeleteImages();

        particle.SetActive(false);
        go.SetActive(false);
        GameSystem.Instance.CanActiveGO = true;
    }


}
