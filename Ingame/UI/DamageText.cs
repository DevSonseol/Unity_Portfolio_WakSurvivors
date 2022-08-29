using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{

    public float movingSpeed; // 텍스트 이동속도
    public float alphaSpeed; //투명도 변환속도
    TextMeshPro text;
    Color alpha;
    public int damage;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        alpha = text.color;
        damage = 10;
    }

    void Start()
    {
    }

  
    void Update()
    {
        transform.Translate(new Vector3(0, movingSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a,0,Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    public void SetText(int Damage , Vector3 Position)
    {
        this.gameObject.transform.position = new Vector3(Position.x, Position.y, Position.z);
        this.damage = Damage;
        this.alpha.a = 1f;
        this.text.color = alpha;
        text.text = damage.ToString();

        Invoke("ReturnToPooling", 1f);
    }

    public void ReturnToPooling()
    {
        DamageTextPool.ReturnText(this);
    }

}
