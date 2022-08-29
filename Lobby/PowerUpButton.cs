using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpButton : MonoBehaviour
{
    [SerializeField]
    public Powers power;

    [SerializeField]
    private Text PowerName;

    [SerializeField]
    private Image PowerImage;

    [SerializeField]
    private string PowerDetail;

    [SerializeField]
    private int cost;

    public int Cost
    {
        get { return cost; }
    }


    private int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }


    [SerializeField]
    private int MaxLevel;

    [SerializeField]
    private GameObject prefab;

    private List<LvCounter> LvCounters = new List<LvCounter>();

    //디테일 파넬
    [SerializeField]
    private Text detailName;

    [SerializeField]
    private Image detailImage;

    [SerializeField]
    private Text detailIText;

    [SerializeField]
    private Text detailCostText;

    [SerializeField]
    private BuyButton buyButton;


    private void SetLvCounters()
    {
        int imgWidth = 16;
        int startWidth = (MaxLevel-1) * (-imgWidth / 2);
        
        for (int i = 0; i < MaxLevel; i++)
        {
            var lvCounter = Instantiate(prefab).GetComponent<LvCounter>();
            LvCounters.Add(lvCounter);
            LvCounters[i].transform.SetParent(this.transform);
            LvCounters[i].transform.position = this.transform.position + new Vector3(startWidth + imgWidth * i, -48, 0);
        }
    }

    public void UpdateLvCounter()
    {

    }

    public void UpdateDetailPanel()
    {
        buyButton.powerUpButton = this;

        detailName.text = PowerName.text;
        detailImage.sprite = PowerImage.sprite;
        detailIText.text = PowerDetail;

        bool isMax;
        isMax = LvCounters[MaxLevel-1].isLevelUp;
        
        if(isMax)
        {
            detailCostText.text = "최대강화";
            buyButton.gameObject.SetActive(false);
        }else
        {
            detailCostText.text = (GameSystem.Instance.LvUpCount * 0.1 * cost * Level + (cost * Level)).ToString();
            buyButton.gameObject.SetActive(true);
        }

    }

    public void UpdateCheckers()
    {
        LvCounters[Level -2].isLevelUp = true;
        LvCounters[Level -2].ChangeImage();
    }

    public void ResetCheckers()
    {
        foreach(var LvCounter in LvCounters)
        {
            LvCounter.isLevelUp = false;
            LvCounter.ChangeImage();
        }
    }


    private void Awake()
    {
        SetLvCounters();
    }


    void Start()
    {
    }

  
    void Update()
    {
        
    }
}
