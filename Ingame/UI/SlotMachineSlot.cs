using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineSlot : MonoBehaviour
{
    [SerializeField] private RectTransform slotRect;
    [SerializeField] private int imageCount; //아이템 몇개인지 저장하기위한
    [SerializeField] private int winningIndex;
    [SerializeField] private List<GameObject> imagesList = new List<GameObject>();
    [SerializeField] private float spinSpeed = 5; //회전 속도
    [SerializeField] private float spinTime = 3;
    [SerializeField] private float sizeY;
    public GameObject itemPrefab; //slotItemImage
    public bool isDone = false;

    bool isSpin = false;


    void Awake()
    {
        slotRect = GetComponent<RectTransform>();
        sizeY = slotRect.rect.height / 4;
    }

    void Start()
    {
        sizeY = slotRect.rect.height / 4;
    }

    void Update()
    {
        if(isSpin)
            Spining();
    }


    public void StartSpin()
    {
        isDone = false;

        ReadySpin();

        StartCoroutine(Spin());

    }

    void ReadySpin()
    {
        List<Weapon> tempList;
        //레벨 업 할 수 있는무기들 임시 리스트 
        if (WeaponSystem.Instance.playerWeaponList.Count != WeaponSystem.MAXWEAPONCOUNT)
        {
            tempList = WeaponSystem.Instance.WeaponList.ToList(); //리스트 깊은 복사
        }else
        {
            tempList = WeaponSystem.Instance.playerWeaponList.ToList();
        }

        foreach (Weapon wp in WeaponSystem.Instance.MaxLevelWeapons)
        {
            if (tempList.Contains(wp))
                tempList.Remove(wp);
        }

        imageCount = tempList.Count();
        winningIndex = Random.Range(0, imageCount);

        //image들 생성
        Vector3 startPos = this.transform.position - new Vector3(0, sizeY, 0);

        for (int i = 0; i < imageCount; i++ , startPos.y += sizeY)
        {
            var go = Instantiate(itemPrefab, startPos, Quaternion.identity, this.transform);
            imagesList.Add(go);
            Image image = go.GetComponent<Image>();
            image.sprite = tempList[i]._sprite;
        }

        int tempCount = 7 - imageCount; //떔빵채울것들
        if(tempCount > 0)
        {
            for (int i = 0; i < tempCount; i++, startPos.y += sizeY)
            {
                var go = Instantiate(itemPrefab, startPos, Quaternion.identity, this.transform);
                imagesList.Add(go);
                Image image = go.GetComponent<Image>();
                image.sprite = WeaponSystem.Instance.HPUP_Weapon._sprite;
            }

            imageCount = 7;
        }
 
        if(tempList.Count() == 0) //무기 다 레업일때
        {
            //todo
            Debug.Log("HP++");
            WeaponSystem.Instance.Add_Weapon(WeaponSystem.Instance.HPUP_Weapon);
        }
        else//아니면 렙업
        {
            WeaponSystem.Instance.Add_Weapon(tempList[winningIndex]);
        }


    }

    IEnumerator Spin()
    {
        isSpin = true;
        yield return new WaitForSeconds(spinTime);
        StartCoroutine(StopSpin());
    }

    void Spining()
    {

        foreach(GameObject go in imagesList)
        {
            go.transform.position += Vector3.down * spinSpeed; 
            if(go.transform.position.y < -(sizeY*2)) //만약 아래로가면 위로 이동
            {
                go.transform.position = new Vector3(transform.position.x , sizeY * (imageCount - 2) ,0);
            }
        }

    }

    IEnumerator StopSpin()
    {
        RectTransform rect = imagesList[winningIndex].GetComponent<RectTransform>();

        while (rect.position.y >= (Camera.main.pixelHeight/2) + spinSpeed || rect.position.y <= (Camera.main.pixelHeight / 2) - spinSpeed)
        {
            yield return null; 
        }

        isSpin = false;
        isDone = true;

    }

    public void DeleteImages()
    {
        foreach(GameObject go in imagesList)
        {
            Destroy(go);
        }

        imagesList.Clear();
    }

}




