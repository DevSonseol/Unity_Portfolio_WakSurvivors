using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool Instance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject bulletPrefab;
    private Queue<Bullet> poolingBulletQueue = new Queue<Bullet>();


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

    private void Initialize(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            poolingBulletQueue.Enqueue(CreateBullet());
        }
    }

    private Bullet CreateBullet()
    {
        var newBullet = Instantiate(bulletPrefab, transform).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false);
        return newBullet;

    }

    public static Bullet GetBullet()
    {
        if (Instance.poolingBulletQueue.Count > 0)
        {
            Bullet bullet = Instance.poolingBulletQueue.Dequeue();
            bullet.transform.SetParent(BulletObjectPool.Instance.transform);
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            Bullet bullet = Instance.CreateBullet();
            bullet.transform.SetParent(BulletObjectPool.Instance.transform);
            bullet.gameObject.SetActive(true);
            return bullet;
        }

    }

    public static void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingBulletQueue.Enqueue(bullet);
    }

}
