using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleBullet : Bullet
{

    [SerializeField]
    private float distFromPlayer;

    private float degree;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;
        //공전
        MoveAround();
    }

    public override void Shoot(Vector3 dir)
    {
        direction = new Vector3(dir.x, dir.y, 0);
       
        Invoke("DestroyBullet", duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //충돌 후 데미지 주기
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }


    private void MoveAround()
    {
        degree += speed * Time.deltaTime;

        Vector3 direction = transform.up; 

        var quaternion = Quaternion.Euler(0, 0, degree);
        Vector3 newDirection = quaternion * direction;

        transform.position = player.transform.position + distFromPlayer * newDirection;

    }


    public void SetDistFromPlayerAndDegree(float dist,float _degree)
    {
        distFromPlayer = dist;
        degree = _degree;
    }
}
