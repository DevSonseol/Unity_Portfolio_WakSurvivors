using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTracerBullet : Bullet
{
    [SerializeField]
    private GameObject player;

    private bool canChange = true;

    enum side
    {
        Horizontal ,Vertical
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        //화면밖으로 안나가게하기
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x <= 0f)
        {
            pos.x = 0.01f;
            canChange = false;
            direction = new Vector3(-direction.x, direction.y, 0);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }
        if (pos.x >= 1f)
        {
            pos.x = 0.99f;
            canChange = false;
            direction = new Vector3(-direction.x, direction.y, 0);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if (pos.y <= 0f)
        {
            pos.y = 0.01f;
            canChange = false;
            direction = new Vector3(direction.x, -direction.y, 0);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if (pos.y >= 1f)
        {
            pos.y = 0.99f;
            canChange = false;
            direction = new Vector3(direction.x, -direction.y, 0);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        //이동
        transform.position += direction * speed * Time.deltaTime;

    }

    private void LateUpdate()
    {
        //화면밖으로 안나가게하기
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
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
            collision.gameObject.GetComponent<Monster>().TakeDamage(damage);

        }

    }

    private void Reflect(side s)
    {
        canChange = false;

        switch (s)
        {
            case side.Horizontal:
                direction = new Vector3(-direction.x, direction.y , 0);
                transform.position += new Vector3(-direction.x, direction.y, 0);
                break;
       
            case side.Vertical:
                direction = new Vector3(direction.x, -direction.y, 0);
                transform.position += new Vector3(direction.x, -direction.y, 0);
                break;
       
        }

        StartCoroutine(ChangeDelay());
    }

    private IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
