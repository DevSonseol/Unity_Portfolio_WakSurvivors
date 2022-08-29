using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Power : MonoBehaviour
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private Powers power;

    [SerializeField]
    private int MaxLevel = 5;

    [SerializeField]
    private int Level = 1;

    [SerializeField]
    private float percentPerLevel;


    void Start()
    {
       
    }

    public void UpdatePlayerStat()
    {
       
    }

  
    void Update()
    {
       
    }

    public void LevelUp_Power()
    {
        if(Level < MaxLevel)
        {
            Level++;
        }
    }

}
