using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIcon : MonoBehaviour
{
    private SpriteRenderer spriteRender;

    public Sprite[] icons;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        var type = GameSystem.Instance.character;

        spriteRender.sprite = icons[(int)type];
    }

}
