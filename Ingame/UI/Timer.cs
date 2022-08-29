using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private Text TimeText;

    private static Timer instance;

    public static Timer Instance
    {
        get { return instance; }
    }

    public float TimeSec = 0;
    public float TimeMin = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

  
    void Update()
    {

        if(TimeSec >= 60)
        {
            TimeSec = 0;
            TimeMin++;
        }else
        {
            TimeSec += Time.deltaTime;
        }

        TimeText.text = string.Format("{0}:{1}", TimeMin, (int)TimeSec);
    }
}
