using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ACC : MonoBehaviour
{
    private Radar _radar;
    private Drive _drive;
    private decimal _pastDistance;
    private bool _pastDetected = false;
    
    [SerializeField] private float speed;

    public decimal deltaDistance;
    public decimal deltaVelocity;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        _radar = GetComponent<Radar>();
        _drive = GetComponent<Drive>();

        if (_radar.objectDetected)
        {
            _pastDistance = _radar.Distance;
        }
    }
    
    void Update()
    {
        if (_radar.objectDetected)
        {
            if (!_pastDetected)
            {
                _pastDistance = _radar.Distance;
                _pastDetected = true;
            }
            else
            {
                deltaDistance = _pastDistance - _radar.Distance;
                deltaVelocity = deltaDistance / (decimal)Time.deltaTime;
                _pastDistance = _radar.Distance;
                Debug.Log(_drive.realSpeed);

                _drive.CruiseControl((float)Math.Round(_drive.realSpeed - deltaVelocity));
            }
        }
    }
}
