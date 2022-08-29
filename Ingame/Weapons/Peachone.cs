using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peachone : MonoBehaviour
{
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if (!GameSystem.Instance.CanActiveGO)
            return;
    }
}
