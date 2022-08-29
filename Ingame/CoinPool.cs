using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public static CoinPool Instance;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject CoinPrefab;

    [SerializeField]
    private Queue<Coin> poolingCoinQueue = new Queue<Coin>();

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
        var coin = CoinPool.GetCoin();
        //monster.SetMonster(MonsterCount, 10, 10);
        //monster.name = "Monster" + MonsterCount.ToString();
        //MonsterCount++;
    }

    private void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            poolingCoinQueue.Enqueue(CreateCoin());
        }
    }

    private Coin CreateCoin()
    {
        var newCoin = Instantiate(CoinPrefab, transform).GetComponent<Coin>();
        newCoin.gameObject.SetActive(false);
        return newCoin;

    }

    public static Coin GetCoin()
    {
        if (Instance.poolingCoinQueue.Count > 0)
        {
            Coin coin = Instance.poolingCoinQueue.Dequeue();
            coin.transform.SetParent(CoinPool.Instance.transform);
            coin.gameObject.SetActive(true);
            return coin;
        }
        else
        {
            Coin coin = Instance.CreateCoin();
            coin.transform.SetParent(MonsterPool.Instance.transform);
            coin.gameObject.SetActive(true);
            return coin;
        }

    }

    public static void ReturnCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        coin.transform.SetParent(Instance.transform);
        Instance.poolingCoinQueue.Enqueue(coin);
    }

}
