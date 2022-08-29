using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBullet : Bullet
{

    [SerializeField]
    private float force;

    private const float fixedforce = 18;

    [SerializeField]
    private float gravity;

    private float rotateZ;
    void Start()
    {

    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        //회전
        rotateZ += 5;
        transform.rotation = Quaternion.Euler(0,0, rotateZ);

        //이동
        force -= gravity * Time.deltaTime;//점점 떨구기
        Vector3 move = new Vector3(speed * direction.x, force, 0) * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    public override void Shoot(Vector3 dir)
    {
        //중력 초기화
        ResetForce();
        //랜덤으로 살짝 어긋나게
        float random = Random.Range(0f, 2f);

        direction = new Vector3(dir.x * random, dir.y, 0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Invoke("DestroyBullet", duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //CancelInvoke("DestroyBullet");
            //충돌 후 데미지 주기
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void ResetForce()
    {
        force = fixedforce;
        force -= Random.Range(0f, 5f);
        
    }
}
