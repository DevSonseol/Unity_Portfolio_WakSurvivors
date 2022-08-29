using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    protected Vector3 direction;

    [SerializeField]
    protected float speed = 1;

    [SerializeField]
    protected BulletCategory category;

    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float duration;

    public virtual void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestroyBullet", duration);
    }


    protected void DestroyBullet()
    {
        ObjectPool.ReturnBullet(this, this.category);

        //StartCoroutine(WaitDestroyBullet());

    }

    protected IEnumerator WaitDestroyBullet()
    {
        yield return new WaitForEndOfFrame();
        ObjectPool.ReturnBullet(this, this.category);
    }



    protected virtual void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;

    }

    public void SetBulletStat(float _damage, float _duration , float _speed)
    {
        speed = _speed;
        damage = _damage;
        duration = _duration;
    }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

}
