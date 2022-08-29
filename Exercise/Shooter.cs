using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bulletPrefab;

    Camera mainCam;

    Vector3 mouseDir;

    void Start()
    {
        mainCam = Camera.main;
    }

  
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    mouseDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.transform.position.z));
        //    mouseDir -=transform.position;

        //    var bullet = BulletObjectPool.GetBullet();
        //    bullet.transform.position = transform.position + mouseDir.normalized;
        //    bullet.Shoot(mouseDir.normalized);
        //}

        if (Input.GetMouseButton(0))
        {
            mouseDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            mouseDir -= transform.position;

            var bullet = ObjectPool.GetBullet(BulletCategory.Knife);
            bullet.transform.position = transform.position + mouseDir.normalized;
            bullet.Shoot(mouseDir.normalized);
        }

        if (Input.GetMouseButton(1))
        {
            mouseDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            mouseDir -= transform.position;

            var bullet = ObjectPool.GetBullet(BulletCategory.MagicWand);
            bullet.transform.position = transform.position + mouseDir.normalized;
            bullet.Shoot(mouseDir.normalized);
        }


    }
}
