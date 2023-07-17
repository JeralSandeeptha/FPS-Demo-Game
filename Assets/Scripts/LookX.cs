using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 3.5f;

    void Start()
    {
        
    }

    private void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (_mouseX * _sensitivity), transform.localEulerAngles.z);
    }
}