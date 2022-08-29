using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBullet : Bullet
{

    [SerializeField]
    private float force;

    private const float fixedforce = 5;

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
        transform.rotation = Quaternion.Euler(0, 0, rotateZ);

        //이동
        force -= gravity * Time.deltaTime;//점점 떨구기
        Vector3 move = new Vector3(force * direction.x, force * direction.y, 0) * speed *Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    public override void Shoot(Vector3 dir)
    {
        //중력 초기화
        ResetForce();
      
        direction = new Vector3(dir.x , dir.y , 0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Invoke("DestroyBullet", duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void ResetForce()
    {
        force = fixedforce;

    }




}
