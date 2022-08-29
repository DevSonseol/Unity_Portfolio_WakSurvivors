using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWaterBullet : Bullet
{
    [SerializeField]
    private GameObject paticle;

    private Vector3 dest;

    private float rotateZ;

    private bool isInDest;

    private float damageTime = 1f; // 데미지가 들어갈 딜레이 (매 프레임마다가 아닌 일정 시간마다 데미지를 주기 위하여)
    private float currentDamageTime;

    void Start()
    {
    }

    protected override void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

        if (transform.position.y < dest.y && !isInDest)
        {
            isInDest = true;
            paticle.SetActive(true);
            Invoke("DestroyBullet", duration);
            return;
        }
        else if(!isInDest)
        {
            //회전
            rotateZ += 5;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ);

            //이동
            Vector3 move = direction * speed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }

        if (isInDest && currentDamageTime > 0)
        {
            currentDamageTime -= Time.deltaTime;
        }

    }

    public override void Shoot(Vector3 dir)
    {
        currentDamageTime = 0;
        paticle.SetActive(false);
        isInDest = false;
        direction = new Vector3(dir.x , dir.y, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isInDest)
            return;

        if (collision.gameObject.tag == "Monster")
        {

            if(currentDamageTime <= 0)
            {
                //충돌 후 데미지 주기
                Debug.Log(collision.name);
                collision.gameObject.GetComponent<Monster>().TakeDamage(damage);
                StartCoroutine(ResetDamageTime());
            }

        }

    }

    private IEnumerator ResetDamageTime()
    {
        yield return null;
        currentDamageTime = damageTime; 
    }

    public void SetDestination(Vector3 _dest)
    {
        dest = _dest;

    }

}
