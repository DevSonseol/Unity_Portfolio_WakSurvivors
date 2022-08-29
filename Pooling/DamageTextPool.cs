using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : MonoBehaviour
{
    public static DamageTextPool Instance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject DamageTextPrefab;

    [SerializeField]
    private Queue<DamageText> poolingDamageTextQueue = new Queue<DamageText>();

    public int CoinCount = 1;

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
    }

    private void Spawn()
    {
        var text = DamageTextPool.GetText();
    }

    private void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            poolingDamageTextQueue.Enqueue(CreateText());
        }
    }

    private DamageText CreateText()
    {
        var newText = Instantiate(DamageTextPrefab, transform).GetComponent<DamageText>();
        newText.gameObject.SetActive(false);
        return newText;

    }

    public static DamageText GetText()
    {
        if (Instance.poolingDamageTextQueue.Count > 0)
        {
            DamageText dt = Instance.poolingDamageTextQueue.Dequeue();
            dt.transform.SetParent(DamageTextPool.Instance.transform);
            dt.gameObject.SetActive(true);
            return dt;
        }
        else
        {
            DamageText dt = Instance.CreateText();
            dt.transform.SetParent(MonsterPool.Instance.transform);
            dt.gameObject.SetActive(true);
            return dt;
        }

    }

    public static void ReturnText(DamageText dt)
    {
        dt.gameObject.SetActive(false);
        dt.transform.SetParent(Instance.transform);
        Instance.poolingDamageTextQueue.Enqueue(dt);
    }

}
