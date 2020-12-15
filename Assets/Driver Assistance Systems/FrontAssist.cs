using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontAssist : MonoBehaviour
{
    private Drive _drive;
    private Radar _radar;

    [SerializeField] private decimal farDistance = 20;
    [SerializeField] private decimal normalDistance = 15;
    [SerializeField] private decimal closeDistance = 10;

    void Start()
    {
        _drive = GetComponent<Drive>();
        _radar = GetComponent<Radar>();
    }
    
    void Update()
    {
        if (_radar.objectDetected)
        {
            if (_radar.Distance <= closeDistance)
            {
                _drive.Brake();
                Debug.Log("Close");
            }
            else if (_radar.Distance <= normalDistance)
            {
                Debug.Log("Normal");
            }
            else if (_radar.Distance <= farDistance)
            {
                Debug.Log("Far");
            }
        }
        else Debug.Log("No objects deteceted");
        
    }
}
