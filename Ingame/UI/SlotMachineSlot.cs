using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineSlot : MonoBehaviour
{
    [SerializeField] private RectTransform slotRect;
    [SerializeField] private int imageCount; //������ ����� �����ϱ�����
    [SerializeField] private int winningIndex;
    [SerializeField] private List<GameObject> imagesList = new List<GameObject>();
    [SerializeField] private float spinSpeed = 5; //ȸ�� �ӵ�
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
        //���� �� �� �� �ִ¹���� �ӽ� ����Ʈ 
        if (WeaponSystem.Instance.playerWeaponList.Count != WeaponSystem.MAXWEAPONCOUNT)
        {
            tempList = WeaponSystem.Instance.WeaponList.ToList(); //����Ʈ ���� ����
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

        //image�� ����
        Vector3 startPos = this.transform.position - new Vector3(0, sizeY, 0);

        for (int i = 0; i < imageCount; i++ , startPos.y += sizeY)
        {
            var go = Instantiate(itemPrefab, startPos, Quaternion.identity, this.transform);
            imagesList.Add(go);
            Image image = go.GetComponent<Image>();
            image.sprite = tempList[i]._sprite;
        }

        int tempCount = 7 - imageCount; //����ä��͵�
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
 
        if(tempList.Count() == 0) //���� �� �����϶�
        {
            //todo
            Debug.Log("HP++");
            WeaponSystem.Instance.Add_Weapon(WeaponSystem.Instance.HPUP_Weapon);
        }
        else//�ƴϸ� ����
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
            if(go.transform.position.y < -(sizeY*2)) //���� �Ʒ��ΰ��� ���� �̵�
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




