using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LvCounter : MonoBehaviour
{
    private Image image;

    public bool isLevelUp;

    private void Awake()
    {
        isLevelUp = false;
        image = gameObject.GetComponent<Image>();
    }


    public void ChangeImage()
    {
        if(isLevelUp)
        {
            image.color = Color.red;
        }else
            image.color = Color.gray;
    }

}
