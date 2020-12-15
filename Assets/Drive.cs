using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private TextMesh _text;
    
    [SerializeField] private float startingSpeed = 3;

    public decimal realSpeed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _text = GetComponentInChildren<TextMesh>();
        CruiseControl();
    }

    void Update()
    {
        realSpeed = (decimal)Mathf.Abs(_rigidbody.velocity.z);
        _text.text = "V = " + realSpeed;
    }
    
    public void Brake()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void CruiseControl()
    {
        _rigidbody.velocity = -transform.forward * startingSpeed;
    }
    
    public void CruiseControl(float speed)
    {
        _rigidbody.velocity = -transform.forward * speed;
    }

    
}
