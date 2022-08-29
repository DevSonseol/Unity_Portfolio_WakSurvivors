using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletCategory
{
    MagicWand , Knife , Axe ,Cross , Bible ,FireWand ,SantaWater , RuneTracer , Lightening ,Gun
}

public class ObjectPool :  MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject[] bulletPrefabs;

    private List<Queue<Bullet>> poolingBulletQueueList = new List<Queue<Bullet>>();

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
        for(int i =0; i < bulletPrefabs.Length ;i++)
        {
            poolingBulletQueueList.Add(new Queue<Bullet>());

            for (int j = 0; j < Count; j++)
            {
                poolingBulletQueueList[i].Enqueue(CreateBullet((BulletCategory)i));
            }
        }
    }

    private Bullet CreateBullet(BulletCategory bullets)
    {
        var newBullet = Instantiate(bulletPrefabs[(int)bullets], transform).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false);
        return newBullet;


    }

    public static Bullet GetBullet(BulletCategory _BC)
    {
        //Queue<Bullet> bulletpool = Instance.poolingBulletQueueList[(int)_BC];

        if (Instance.poolingBulletQueueList[(int)_BC].Count > 0)
        {
            var bullet = Instance.poolingBulletQueueList[(int)_BC].Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instance.CreateBullet(_BC);
            bullet.transform.SetParent(ObjectPool.Instance.transform);
            bullet.gameObject.SetActive(true);
            return bullet;
        }

    }

    public static void ReturnBullet(Bullet bullet , BulletCategory _BC)
    {
        Queue<Bullet> bulletpool = Instance.poolingBulletQueueList[(int)_BC];        
        bullet.gameObject.SetActive(false);
        bulletpool.Enqueue(bullet);

    }

}
