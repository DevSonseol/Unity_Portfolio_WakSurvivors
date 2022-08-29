using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public static MonsterPool Instance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject monsterPrefab;

    [SerializeField]
    private Queue<Monster> poolingMonsterQueue = new Queue<Monster>();

    //private bool isSpawn = true;

    public Monster nerestTarget;

    public int MonsterCount = 1;

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    void Start()
    {
        player = GameObject.Find("Player");

        InvokeRepeating("Spawn", 1f, 0.5f);
        InvokeRepeating("GetClosestEnemy", 1f, 1f);

    }

    void Update()
    {


    }

    private void Spawn()
    {
        var monster = MonsterPool.GetMonster();
        monster.SetMonster(player.transform.position, MonsterCount, 10);
        monster.name = "Monster"+MonsterCount.ToString();
        MonsterCount++;
    }

    private void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            poolingMonsterQueue.Enqueue(CreateMonster());
        }
    }

    private Monster CreateMonster()
    {
        var newMonster= Instantiate(monsterPrefab, transform).GetComponent<Monster>();
        newMonster.gameObject.SetActive(false);
        return newMonster;

    }

    public static Monster GetMonster()
    {
        if(Instance.poolingMonsterQueue.Count > 0)
        {
            Monster monster = Instance.poolingMonsterQueue.Dequeue();
            monster.transform.SetParent(MonsterPool.Instance.transform);
            monster.gameObject.SetActive(true);
            return monster;
        }
        else
        {
            Monster monster = Instance.CreateMonster();
            monster.transform.SetParent(MonsterPool.Instance.transform);
            monster.gameObject.SetActive(true);
            return monster;
        }

    }

    public static void ReturnMonster(Monster monster)
    {
        monster.gameObject.SetActive(false);
        monster.transform.SetParent(Instance.transform);
        Instance.poolingMonsterQueue.Enqueue(monster);
    }


    Monster GetClosestEnemy()
    {
        Monster bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 PlayerPosition = player.transform.position;

        Monster[] monsters = this.GetComponentsInChildren<Monster>();


        foreach (var potentialTarget in monsters)
        {
            potentialTarget.TestChangeColor(Color.white);
            Vector3 directionToTarget =  potentialTarget.transform.position  - PlayerPosition;
            float dSqrToTarget = directionToTarget.magnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        if(bestTarget != null)
        {
            nerestTarget = bestTarget;
            nerestTarget.TestChangeColor(Color.red);
        }

        return bestTarget;
    }


}
