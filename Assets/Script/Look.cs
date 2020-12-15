using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private float _x, _y;
    public Transform bodyTransform;
    [SerializeField] private float verticalSensitivity = 5f;
    [SerializeField] private float horizontalSensitivty = 5f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _y = transform.rotation.y;
    }
    
    void Update()
    {
        _x = Input.GetAxis("Mouse X") * Time.deltaTime * horizontalSensitivty;
        _y -= Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSensitivity;
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(_y, -90, 90), 0 , 0);
        bodyTransform.Rotate(Vector3.up * _x);
    }
}
