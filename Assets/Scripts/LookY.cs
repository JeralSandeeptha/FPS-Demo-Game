using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 3.5f;

    void Start()
    {

    }

    private void Update()
    {
        CalculateMouseY();
    }

    private void CalculateMouseY()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - (_mouseY * _sensitivity), transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
