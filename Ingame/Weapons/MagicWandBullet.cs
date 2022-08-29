using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandBullet : Bullet
{

    void Start()
    {

    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;
        transform.position += direction * speed * Time.deltaTime;
    }

    public override void Shoot(Vector3 dir)
    {
        direction = new Vector3(dir.x,dir.y,0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Invoke("DestroyBullet", duration);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            CancelInvoke("DestroyBullet");

            //충돌 후 데미지 주기
            collision.GetComponent<Monster>().TakeDamage(damage);

            DestroyBullet();
        }
    }



}
