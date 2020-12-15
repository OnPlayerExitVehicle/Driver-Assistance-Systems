using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float _x, _y;
    [SerializeField] private float movementSpeed = 0.125f;
    [SerializeField] private float horizontalSpeed = 0.125f;
    void Start()
    {
        
    }

    void Update()
    {
        _x = Input.GetAxis("Horizontal") * horizontalSpeed;
        _y = Input.GetAxis("Vertical") * movementSpeed;
        Debug.Log("X = " + _x + " Y = " + _y);
        transform.position += (transform.forward * _y + transform.right * _x) * Time.deltaTime;
    }
}
