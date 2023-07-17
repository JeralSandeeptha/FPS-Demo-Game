using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float _shootRange = 300f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerShoot();
        }
    }

    private void PlayerShoot() 
    {
        RaycastHit _hitinfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitinfo, _shootRange))//this is a bool
        {
            print("I shoot " + _hitinfo.transform.name);
            Destroy(_hitinfo.transform.gameObject);
        }
        else {
            return;
        }
    }
}
