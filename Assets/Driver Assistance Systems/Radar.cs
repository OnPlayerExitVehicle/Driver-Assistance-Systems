using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    // Serialize'lar
    
    [SerializeField] private int maxDistance = 25;
    
    // Private değişkenler
    
    private Rigidbody _rigidbody;
    private decimal _distance;
    private RaycastHit _radarObject;
    
    // Public değişkenler

    public bool objectDetected = false;
    
    // Property'ler
    
    public decimal Distance
    {
        get => _distance;
        private set
        {
            if (value > 0)
            {
                _distance = value;
            }
            else _distance = 0;
        }
    }

    //----------------------------------------------------//
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RadarControl();
    }

    private void RadarControl()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out _radarObject, maxDistance + (transform.localScale.z / 2)))
        {
            objectDetected = true;
            Distance = (decimal)_radarObject.distance - (decimal)(transform.localScale.z / 2);
        }
        else objectDetected = false;
    }
}
