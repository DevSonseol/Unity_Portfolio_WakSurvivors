using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player.hp_delegate += UpdateHP;
    }

    void UpdateHP(float MaxHP , float HP)
    {
        float size = (HP / (MaxHP*2f));
        size = Mathf.Max(0, size);
        transform.localScale = new Vector3(size, transform.localScale.y,1);
    }
}
